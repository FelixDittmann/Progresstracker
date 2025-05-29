using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Adapter.Steam
{
    public class SteamGameInfo
    {
        public string AppId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public TimeSpan Playtime { get; set; }
    }
}
