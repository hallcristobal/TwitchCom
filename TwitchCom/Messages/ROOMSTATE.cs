using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class RoomState : Message
    {
        public enum ROOM_CHANGE
        {
            LANGUAGE,
            R9K,
            SUBSCRIBERS,
            SLOW
        }
        private ROOM_CHANGE _change;
        private string _change_ammount;

        public ROOM_CHANGE Change { get { return _change; } }
        public string ChangeAmmount { get { return _change_ammount; } }

        public RoomState()
        {
            _type = Type.ROOMSTATE;
        }

        public override void ParseTags(string raw)
        {
            var tags = SplitTags(raw);

            if (tags[0] == "slow")
                _change = ROOM_CHANGE.SLOW;
            else if (tags[0] == "subs_only")
                _change = ROOM_CHANGE.SUBSCRIBERS;
            else if (tags[0] == "r9k")
                _change = ROOM_CHANGE.R9K;
            else if (tags[0] == "broadcaster_lang")
                _change = ROOM_CHANGE.LANGUAGE;
                
            _change_ammount = tags[1];


        }
    }
}
