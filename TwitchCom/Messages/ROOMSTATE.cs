using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class ROOMSTATE : Message
    {
        public string broadcaster_lang { get; set; }
        public string r9k { get; set; }
        public string subs_only { get; set; }
        public string slow { get; set; }

        public ROOMSTATE()
        {
            Type = Type.ROOMSTATE;
        }
}
}
