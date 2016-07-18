using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class USERNOTICE : PRVMSG
    {
        public string msg_id { get; set; }
        public string msg_param_months { get; set; }
        public string system_msg { get; set; }
        public string login { get; set; }

        public USERNOTICE()
        {
            Type = Type.USERNOTICE;
        }
    }
}
