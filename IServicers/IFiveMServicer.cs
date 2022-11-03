using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace nex_FiveMServerLauncher.IServicers
{
    public class IFiveMServicer
    {
        // [!] Dynamic Variables
        public string ServerName { get; set; }
        public string ServerDescription { get; set; }
        public string ServerPlayerCount { get; set; }
        public string IconUrl { get; set; }

        public StringBuilder SB = new StringBuilder();

        public IFiveMServicer(string IPandPort)
        {
            SB.Clear();
            using (WebClient wc = new WebClient())
            {
                string FiveMJsonData = wc.DownloadString($"http://{IPandPort}/info.json");
                var FormattedData = JsonConvert.DeserializeObject<Root>(FiveMJsonData);

                ServerName = FormattedData.vars.sv_projectName;
                ServerDescription = FormattedData.vars.sv_projectDesc;
                IconUrl = FormattedData.icon;
                ServerPlayerCount = FormattedData.vars.sv_maxClients;
            }
            using (WebClient wc = new WebClient())
            {
                string FiveMJsonData = wc.DownloadString($"http://{IPandPort}/players.json");

                var FormattedData = JsonConvert.DeserializeObject<List<Players>>(FiveMJsonData);

                int count = 0;
                foreach (var Player in FormattedData)
                {
                    SB.AppendLine($"[{Player.id}] {Player.name.Replace("^", "").Replace("~", @"").Replace("<", "").Replace(">", "")} ({Player.ping}ms)");
                    count++;
                }
                ServerPlayerCount = count.ToString();
            }
        }
    }
}
