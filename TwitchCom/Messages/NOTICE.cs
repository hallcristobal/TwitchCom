using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchCom.Messages
{
    public class NOTICE : Message
    {
        // Tags
        public string subs_on { get; set; }
        public string already_subs_on { get; set; }
        public string subs_off { get; set; }
        public string already_subs_off { get; set; }
        public string slow_on { get; set; }
        public string slow_off { get; set; }
        public string r9k_on { get; set; }
        public string already_r9k_on { get; set; }
        public string r9k_off { get; set; }
        public string already_r9k_off { get; set; }
        public string host_on { get; set; }
        public string bad_host_hosting { get; set; }
        public string host_off { get; set; }
        public string hosts_remaining { get; set; }
        public string emote_only_on { get; set; }
        public string already_emote_only_on { get; set; }
        public string emote_only_off { get; set; }
        public string already_emote_only_off { get; set; }
        public string msg_channel_suspended { get; set; }
        public string timeout_success { get; set; }
        public string ban_success { get; set; }
        public string unban_success { get; set; }
        public string bad_unban_no_ban { get; set; }
        public string already_banned { get; set; }
        public string unrecognized_cmd { get; set; }

        public NOTICE()
        {
            Type = Type.NOTICE;
        }
    }
}
