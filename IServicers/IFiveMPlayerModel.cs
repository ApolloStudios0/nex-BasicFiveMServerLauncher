using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nex_FiveMServerLauncher.IServicers
{
    public class Players
    {
        public string endpoint { get; set; }
        public int id { get; set; }
        public List<string> identifiers { get; set; }
        public string name { get; set; }
        public int ping { get; set; }
    }
}
