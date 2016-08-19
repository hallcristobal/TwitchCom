using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class NOTICE : Message
    {
        public NOTICE()
        {
            Type = Type.NOTICE;
        }
    }
}
