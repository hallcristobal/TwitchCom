using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    class CLEARCHAT : Message
    {
        public string ban_duration { get; set; }
        public string ban_reason { get; set; }

        public CLEARCHAT()
        {
            Type = Type.CLEARCHAT;
        }
    }
}
