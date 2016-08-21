using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class Message : IMessage
    {
        protected string _value;
        protected string _user;
        protected Type _type;
        protected string _raw;

        public string Value { get { return _value; } set { _value = value; } }
        public string User { get { return _user; } set { _user = value; } }
        public Type Type { get { return _type; } set { _type = value; } }
        public string Raw { get { return _raw; } set { _raw = value; } }

        public Message()
        {
            _type = Type.NONE;
        }

        public virtual void ParseTags(string raw)
        {
            
        }

        protected List<string> SplitTags(string raw)
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
