using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nex_FiveMServerLauncher.IServicers
{
    public class Root
    {
        public bool enhancedHostSupport { get; set; }
        public string icon { get; set; }
        public string requestSteamTicket { get; set; }
        public List<string> resources { get; set; }
        public string server { get; set; }
        public Vars vars { get; set; }
        public int version { get; set; }
    }

    public class Vars
    {
        public string gamename { get; set; }
        public string gametype { get; set; }
        public string locale { get; set; }
        public string onesync_enabled { get; set; }
        public string sv_enforceGameBuild { get; set; }
        public string sv_enhancedHostSupport { get; set; }
        public string sv_lan { get; set; }
        public string sv_licenseKeyToken { get; set; }
        public string sv_maxClients { get; set; }
        public string sv_projectDesc { get; set; }
        public string sv_projectName { get; set; }
        public string sv_pureLevel { get; set; }
        public string sv_scriptHookAllowed { get; set; }
        public string tags { get; set; }
    }
}
