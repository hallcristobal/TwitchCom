using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    class CLEARCHAT : Message
    {
        private string _banDuration;
        private string _banReason;

        public string ban_duration { get { return _banDuration; } }
        public string ban_reason { get { return _banReason; } }

        public CLEARCHAT()
        {
            Type = Type.CLEARCHAT;
        }

        public override void ParseTags(string raw)
        {
            
        }
    }
}
