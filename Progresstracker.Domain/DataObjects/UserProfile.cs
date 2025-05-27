using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Domain.DataObjects
{
    public class UserProfile
    {
        public Guid UserProfileID { get; set; }
        public string Name { get; set; }
        public string SteamApiKey { get; set; }
        public string SteamProfileID { get; set; }
        // public List<string> Sources { get; set; }

        public UserProfile(Guid id, string name, string steamApiKey, string steamProfileId)
        {
            UserProfileID = id;
            Name = name;
            SteamApiKey = steamApiKey;
            SteamProfileID = steamProfileId;
        }
    }
}
