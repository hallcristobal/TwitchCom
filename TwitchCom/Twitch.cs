using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom
{
    public class Twitch
    {
        private string _channel;
        private string _username;
        private string _oauth;

        public string Channel
        {
            get { return _channel; }
            set { _channel = value.ToLower(); }
        }
        public string UserName
        {
            get { return _username; }
            set { _username = value.ToLower(); }
        }
        public string OAuth
        {
            get { return _oauth; }
            set { _oauth = value; }
        }
        
        public Twitch(string _userName, string _oAuth, string _channel)
        {
            this._username = _userName.ToLower();
            this._oauth = _oAuth;
            this._channel = _channel.ToLower();
        }
    }
}
