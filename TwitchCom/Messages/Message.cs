using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class Message : IMessage
    {
        public string Value { get; set; }
        public string User { get; set; }
        public Type Type { get; set; }
        public string Raw { get; set; }

        public Message()
        {
            Type = Type.NONE;
        }

        public virtual void ParseTags(string raw)
        {
            
        }

        public virtual List<string> SplitTags(string raw)
        {
            if (!raw.StartsWith("@"))
                return null;

            raw = raw.Remove(0, 1);
            string[] raw_split = raw.Split(';');

            List<string> tags = new List<string>();
            foreach (var s in raw_split)
            {
                tags.AddRange(s.Split('='));
            }

            return tags;
        }

    }
}
