using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class UserNotice : PrvMsg
    {
        private string _msg_id;
        private string _msg_param_months;
        private string _system_msg;
        private string _login;

        public string MsgId { get { return _msg_id; } }
        public string msg_param_months { get { return _msg_param_months; } }
        public string system_msg { get { return _system_msg; } }
        public string login { get { return _login; } }

        public UserNotice()
        {
            _type = Type.USERNOTICE;
        }
    }
}
