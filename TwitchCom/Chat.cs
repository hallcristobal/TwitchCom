using System.Net.Sockets;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using TwitchCom.Messages;

namespace TwitchCom
{
    public class Chat
    {

        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;
        private Twitch twitch;
        private bool connected = false;
        public bool Connected { get { return connected; } }
        public bool RequestTags { get; set; } = false;
        public bool RequestCommands { get; set; } = false;
        public bool RequestMembership { get; set; } = false;
        public bool RequestAll { get; set; } = false;

        public Chat(Twitch _t)
        {
            twitch = _t;
            tcpClient = new TcpClient();
            Connect();
        }

        public void Connect()
        {
            tcpClient.Connect("irc.chat.twitch.tv", 6667);

            if (tcpClient.Connected)
                connected = true;
            else
            {
                connected = false;
                return;
            }

            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());

            outputStream.WriteLine("PASS " + twitch.OAuth);
            outputStream.WriteLine("NICK " + twitch.UserName);
            outputStream.WriteLine("USER " + twitch.UserName + " 8 * :" + twitch.UserName);

            if (RequestMembership || RequestAll)
                outputStream.WriteLine("CAP REQ :twitch.tv/membership");
            if (RequestCommands || RequestAll)
                outputStream.WriteLine("CAP REQ :twitch.tv/commands");
            if (RequestTags || RequestAll)
                outputStream.WriteLine("CAP REQ :twitch.tv/tags");
        }

        public void ReConnect()
        {
            if(Connected)
            {
                tcpClient.Close();
                connected = false;
            }

            Connect();
        }

        public Message readMessage()
        {
            try
            {
                string message = inputStream.ReadLine();

                if (message.StartsWith("PING"))
                {
                    sendIrcMessage("PONG: tmi.twitch.tv");
                    Message output = new Message();
                    output.Type = Messages.Type.PONG;
                    output.Raw = message;
                    return output;
                }

                return parseMessage(message);
            }
            catch(Exception e)
            {
                Message output = new Message();
                output.Type = Messages.Type.EXCEPTION;
                output.Raw = e.ToString();
                output.User = "Exception";
                output.Value = String.Empty;
                return output;
            }
        }

        private Message parseMessage(string raw)
        {
            // 0 - tags, 1 - name; 2 - type, 3 - channel, 4 - message
            string[] split_raw = raw.Split(' ');
            Messages.Type type = Messages.Type.NONE;
            Message output;

            for (int i = 0; i < split_raw.Length; i++)
            {
                if (Char.IsLetter(split_raw[i][0]))
                {
                    type = GetType(split_raw[i]);
                    break;
                }
            }

            if (RequestTags || RequestAll)
            {
                switch (type)
                {
                    case Messages.Type.PRIVMSG:
                        PRVMSG pv_ret = new PRVMSG();
                        pv_ret.ParseTags(split_raw[0]);
                        output = pv_ret;
                        break;
                    case Messages.Type.NOTICE:
                        NOTICE note_ret = new NOTICE();
                        note_ret.ParseTags(split_raw[0]);
                        output = note_ret;
                        break;


                    case Messages.Type.HOSTTARGET:
                        // TODO: HOSTTARGET Class
                        output = new Message();
                        output.Type = Messages.Type.RECONNECT;
                        break;


                    case Messages.Type.CLEARCHAT:
                        CLEARCHAT clr_ret = new CLEARCHAT();
                        clr_ret.ParseTags(split_raw[0]);
                        output = clr_ret;
                        break;
                    case Messages.Type.USERSTATE:
                        USERSTATE usr_ret = new USERSTATE();
                        usr_ret.ParseTags(split_raw[0]);
                        output = usr_ret;
                        break;


                    case Messages.Type.RECONNECT:
                        // TODO: Reconnect Code
                        output = new Message();
                        output.Type = type;
                        break;


                    case Messages.Type.USERNOTICE:
                        USERNOTICE usrn_ret = new USERNOTICE();
                        usrn_ret.ParseTags(split_raw[0]);
                        output = usrn_ret;
                        break;
                    case Messages.Type.ROOMSTATE:
                        ROOMSTATE rs_ret = new ROOMSTATE();
                        rs_ret.ParseTags(split_raw[0]);
                        output = rs_ret;
                        break;
                    default:
                        output = new Message();
                        output.Type = type;
                        break;
                }
                output.User = split_raw[split_raw.Length - 3];
            }
            else
            {
                output = new Message();
                output.User = split_raw[0].Remove(0, 1).Split('!')[0];
            }

            output.Type = type;
            output.Raw = raw;
            output.Value = split_raw[split_raw.Length - 1].Remove(0, 1);
            return output;

        }

        private Messages.Type GetType(string raw)
        {
            foreach(Messages.Type t in Enum.GetValues(typeof(Messages.Type)))
            {
                if (raw == t.ToString())
                    return t;
            }

            return Messages.Type.NONE;
        }

        public void joinChannel()
        {
            sendIrcMessage("JOIN #" + twitch.Channel);
        }
        public void joinChannel(string channel)
        {
            twitch.Channel = channel.ToLower();
            sendIrcMessage("JOIN #" + twitch.Channel);
        }

        public void sendIrcMessage(string message)
        {
            outputStream.WriteLine(message);
            outputStream.Flush();
        }


    }
}
