using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TwitchCom.Messages
{
    public class PRVMSG : Message
    {
        // Tags
        public string Badges        { get; set; }
        public Color Color         { get; set; }
        public string Display_Name  { get; set; }
        public string Emotes        { get; set; }
        public string Id            { get; set; }
        public bool Mod           { get; set; }
        public bool Subscriber    { get; set; }
        public bool Turbo         { get; set; }
        public string Room_Id       { get; set; }
        public string User_Id       { get; set; }
        public string User_Type     { get; set; }
        public string Bits          { get; set; }
        public PRVMSG()
        {
            Type = Type.PRIVMSG;
        }

        public override void ParseTags(string raw)
        {
            // @badges=broadcaster/1;color=#000000;display-name=C_MidKnight;emotes=;id=f2d2917b-b433-4494-afa3-d2be17c00240;mod=1;room-id=52956221;subscriber=0;turbo=0;user-id=52956221;user-type=mod
            if (!raw.StartsWith("@"))
                return;

            raw = raw.Remove(0, 1);
            string[] raw_split = raw.Split(';');

            List<string> tags = new List<string>();
            foreach (var s in raw_split)
            {
                tags.AddRange(s.Split('='));
            }

            Badges = tags[1];
            Color = ColorTranslator.FromHtml(tags[3]);
            Display_Name = tags[5];
            Emotes = tags[7];
            Id = tags[9];
            Mod = tags[11] == "1" ? true : false;
            Room_Id = tags[13];
            Subscriber = tags[15] == "1" ? true : false;
            Turbo = tags[17] == "1" ? true : false;
            User_Id = tags[19];
            User_Type = tags[21];
        }
    }
}
