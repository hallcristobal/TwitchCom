using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class ROOMSTATE : Message
    {
        public enum ROOM_CHANGE
        {
            LANGUAGE,
            R9K,
            SUBSCRIBERS,
            SLOW
        }
        private ROOM_CHANGE _change;
        private string _Change_Value;

        public ROOM_CHANGE Change { get { return _change; } }
        public string Change_Value { get { return _Change_Value; } }

        public ROOMSTATE()
        {
            Type = Type.ROOMSTATE;
        }

        public override void ParseTags(string raw)
        {
            //TODO (cris) if statements for tags
            var tags = SplitTags(raw);

            if (tags[0] == "slow")
                _change = ROOM_CHANGE.SLOW;
            else if (tags[0] == "subs_only")
                _change = ROOM_CHANGE.SUBSCRIBERS;
            else if (tags[0] == "r9k")
                _change = ROOM_CHANGE.R9K;
            else if (tags[0] == "broadcaster_lang")
                _change = ROOM_CHANGE.LANGUAGE;
                
            _Change_Value = tags[1];


        }
    }
}
