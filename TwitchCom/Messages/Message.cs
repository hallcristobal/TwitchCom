using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class Message : IMessage
    {
        public string Value { get; set; }
        public string User { get; set; }
        public Type Type { get; set; }
        public string Raw { get; set; }

        public Message()
        {
            Type = Type.NONE;
        }

        public virtual void ParseMessage(string raw)
        {
            
        }

    }
}
