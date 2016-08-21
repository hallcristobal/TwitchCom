using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class Notice : Message
    {
        public Notice()
        {
            _type = Type.NOTICE;
        }
    }
}
