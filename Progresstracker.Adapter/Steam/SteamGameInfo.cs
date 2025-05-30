using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Adapter.Steam
{
    public class SteamGameInfo : Game
    {
        public string AppId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public TimeSpan Playtime { get; set; }
    }
}
