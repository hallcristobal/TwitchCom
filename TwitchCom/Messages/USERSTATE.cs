using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class USERSTATE : PRVMSG
    {
        public string emote_sets { get; set; }
    }
}
