using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom
{
    public class TwitchUser
    {
        private string _username;
        private string _oauth;
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
        
        public TwitchUser(string _userName, string _oAuth)
        {
            this._username = _userName.ToLower();
            this._oauth = _oAuth;
        }
    }
}
