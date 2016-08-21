using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    class ClearChat : Message
    {
        private string _banDuration;
        private string _banReason;

        public string BanDuration { get { return _banDuration; } }
        public string BanReason { get { return _banReason; } }

        public ClearChat()
        {
            _type = Type.CLEARCHAT;
        }

        public override void ParseTags(string raw)
        {
            
        }
    }
}
