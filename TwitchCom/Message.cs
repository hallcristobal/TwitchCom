using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom
{
    public class Message
    {
        public enum Type { PRIVMSG, JOIN, PART, MODE, NOTICE, HOSTTARGET, CLEARCHAT, USERSTATE, RECONNECT, EXCEPTION, NONE };
        public string Value { get; set; }
        public string User { get; set; }
        public Type ID { get; set; }
        public string Raw { get; set; }

    }
}
