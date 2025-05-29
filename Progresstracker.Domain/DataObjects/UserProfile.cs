using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Domain.DataObjects
{
    public class UserProfile
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string SteamApiKey { get; set; }
        public string SteamProfileID { get; set; }
        // public List<string> Sources { get; set; }

        // Parameterloser Konstruktor für EF Core
        public UserProfile() { }
        public UserProfile(string name, string steamApiKey, string steamProfileId)
        {
            Name = name;
            SteamApiKey = steamApiKey;
            SteamProfileID = steamProfileId;
        }
    }
}
