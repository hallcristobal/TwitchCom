using System.Net.Sockets;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;

namespace TwitchCom
{
    public class Chat
    {
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;
        private Twitch twitch;
        public bool Connected { get; set; }

        public Chat(Twitch _t)
        {
            twitch = _t;
            tcpClient = new TcpClient();
            tcpClient.Connect("irc.chat.twitch.tv", 6667);
            if (tcpClient.Connected)
                Connected = true;
            else
            {
                Connected = false;
                return;
            }
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());

            outputStream.WriteLine("PASS " + _t.OAuth);
            outputStream.WriteLine("NICK " + _t.UserName);
            outputStream.WriteLine("USER " + _t.UserName + " 8 * :" + _t.UserName);
            outputStream.WriteLine("CAP REQ :twitch.tv/membership");
            outputStream.WriteLine("CAP REQ :twitch.tv/commands");
            outputStream.WriteLine("CAP REQ :twitch.tv/tags");
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
                    output.ID = Message.Type.NONE;
                    output.Raw = message;
                    return output;
                }

                return parseMessage(message);
            }
            catch(Exception e)
            {
                Message output = new Message();
                output.ID = Message.Type.EXCEPTION;
                output.Raw = e.ToString();
                output.User = "Exception";
                output.Value = String.Empty;
                return output;
            }
        }

        private Message parseMessage(string raw)
        {
            /*
                :rinku249!rinku249@rinku249.tmi.twitch.tv PRIVMSG #cosmowright :SOO CLOSE
                :subbie_!subbie_@subbie_.tmi.twitch.tv PRIVMSG #abahbob :somethiong like that
                :tmi.twitch.tv NOTICE #c_midknight :This room is no longer in slow mode.
                @badges=broadcaster/1;color=#000000;display-name=C_MidKnight;emotes=;id=f2d2917b-b433-4494-afa3-d2be17c00240;mod=1;room-id=52956221;subscriber=0;turbo=0;user-id=52956221;user-type=mod :c_midknight!c_midknight@c_midknight.tmi.twitch.tv PRIVMSG #c_midknight :OK
            */

            char temp;
            
            bool nameParsed = false;
            bool messageType = false;
            bool atMessage = false;

            Message output = new Message();
            StringBuilder sBuilder = new StringBuilder();
            output.Raw = raw;

            if (raw != null)
            {
                for (int x = 0; x < raw.Length; x++)
                {
                    temp = raw[x];
                    //Parse Name
                    if (temp.Equals('!') && !nameParsed && x < raw.Length - 1)
                    {
                        x++;
                        temp = raw[x];
                        while (!temp.Equals('@') && x < raw.Length - 1)
                        {
                            sBuilder.Append(temp);
                            //temp = raw[x];
                            x++;
                            if (x < raw.Length)
                            {
                                temp = raw[x];
                            }
                        }

                        output.User = sBuilder.ToString();
                        sBuilder.Clear();
                        nameParsed = true;
                    }

                    if (temp.Equals(' ') && !messageType && x < raw.Length -1)
                    {
                        x++;
                        temp = raw[x];
                        while (!temp.Equals(' ') && x < raw.Length - 1)
                        {

                            sBuilder.Append(temp);
                            //temp = raw[x];
                            x++;
                            if (x < raw.Length)
                            {
                                temp = raw[x];
                            }
                        }
                        output.ID = GetType(sBuilder.ToString());
                        sBuilder.Clear();
                        messageType = true;
                    }

                    //Parse Message
                    //if ((temp.Equals(':') && serverParsed && nameParsed && messageType) || atMessage)
                    if ((temp.Equals(':') && messageType) ||　atMessage)
                    {
                        atMessage = true;
                        x++;
                        while (x < raw.Length)
                        {
                            if (x < raw.Length)
                            {
                                temp = raw[x];
                            }
                            sBuilder.Append(temp);
                            //temp = raw[x];
                            x++;
                        }
                        output.Value = sBuilder.ToString();
                        sBuilder.Clear();
                    }
                }
            }
            return output;

        }

        private Message.Type GetType(string raw)
        {
            foreach(Message.Type t in Enum.GetValues(typeof(Message.Type)))
            {
                if (raw == t.ToString())
                    return t;
            }

            return Message.Type.NONE;
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
