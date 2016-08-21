using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class UserState : PrvMsg
    {
        private string _emote_sets;
        public string emote_sets { get { return _emote_sets; } }

        public UserState()
        {
            _type = Type.USERSTATE;
        }
    }
}
