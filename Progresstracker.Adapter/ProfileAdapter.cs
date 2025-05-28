using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Progresstracker.Domain.DataObjects;
using Progresstracker.Application.DataObjectHandler;
using System.Diagnostics;

namespace Progresstracker.Adapter
{
    public interface IProfileAdapter
    {
        void CreateProfile(string name, string steamApiKey, string steamProfileId);
    }

    public class ProfileAdapter : IProfileAdapter
    {
        private readonly IProfileService _profileService;

        public ProfileAdapter(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public void CreateProfile(string name, string steamApiKey, string steamProfileId)
        {
            // Minimale Eingabevalidierung, kann bei Bedarf erweitert werden
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name darf nicht leer sein.");

            var profile = new UserProfile(name, steamApiKey, steamProfileId);
            _profileService.CreateProfile(profile);
        }
    }
}
