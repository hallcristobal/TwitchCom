using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class PRVMSG : Message
    {
        // Tags
        public string Badges        { get; set; }
        public string Color         { get; set; }
        public string Display_Name  { get; set; }
        public string Emotes        { get; set; }
        public string Id            { get; set; }
        public string Mod           { get; set; }
        public string Subscriber    { get; set; }
        public string Turbo         { get; set; }
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
            
        }
    }
}
