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
        public int Bits          { get; set; }
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

            int i = 3;
            if(tags[3] == "bits")
            {
                i += 2;
                Bits = Int32.Parse(tags[4]);
            }

            Color = ColorTranslator.FromHtml(tags[i]);
            Display_Name = tags[i+2];
            Emotes = tags[i+4];
            Id = tags[i+6];
            Mod = tags[i+8] == "1" ? true : false;
            Room_Id = tags[i+10];
            Subscriber = tags[i+12] == "1" ? true : false;
            Turbo = tags[i+14] == "1" ? true : false;
            User_Id = tags[i+16];
            User_Type = tags[i+18];
        }
    }
}
