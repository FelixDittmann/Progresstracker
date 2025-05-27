using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Domain.DataObjects
{
    public class UserProfile
    {
        public int UserProfileID { get; set; }
        public string Name { get; set; }
        public string SteamApiKey { get; set; }
        public string SteamProfileID { get; set; }
        public List<string> Sources { get; set; }
    }
}
