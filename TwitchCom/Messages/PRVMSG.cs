using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TwitchCom.Messages
{
    public class PrvMsg : Message
    {
        private string _badges;
        private Color _color;
        private string _display_name;
        private string _emotes;
        private string _id;
        private bool _mod;
        private bool _subscriber;
        private bool _turbo;
        private string _room_id;
        private string _user_id;
        private string _user_type;
        private uint _bits;
        // Tags
        public string Badges            { get { return _badges; } }
        public Color Color              { get { return _color; } }
        public string Display_Name      { get { return _display_name; } }
        public string Emotes            { get { return _emotes; } }
        public string Id                { get { return _id; } }
        public bool Mod                 { get { return _mod; } }
        public bool Subscriber          { get { return _subscriber; } }
        public bool Turbo               { get { return _turbo; } }
        public string Room_Id           { get { return _room_id; } }
        public string User_Id           { get { return _user_id; } }
        public string User_Type         { get { return _user_type; } }
        public uint Bits                { get { return _bits; } }

        public PrvMsg()
        {
            _type = Type.PRIVMSG;
        }

        public override void ParseTags(string raw)
        {
            // @badges=broadcaster/1;color=#000000;display-name=C_MidKnight;emotes=;id=f2d2917b-b433-4494-afa3-d2be17c00240;mod=1;room-id=52956221;subscriber=0;turbo=0;user-id=52956221;user-type=mod

            var tags = SplitTags(raw);

            _badges = tags[1];

            int i = 3;
            if(tags[3] == "bits")
            {
                i += 2;
                _bits = UInt32.Parse(tags[4]);
            }

            _color = ColorTranslator.FromHtml(tags[i]);
            _display_name = tags[i+2];
            _emotes = tags[i+4];
            _id = tags[i+6];
            _mod = tags[i+8] == "1" ? true : false;
            _room_id = tags[i+10];
            _subscriber = tags[i+12] == "1" ? true : false;
            _turbo = tags[i+14] == "1" ? true : false;
            _user_id = tags[i+16];
            _user_type = tags[i+18];
        }
    }
}
