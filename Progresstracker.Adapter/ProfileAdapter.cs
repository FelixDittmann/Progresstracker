using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Progresstracker.Domain.DataObjects;
using Progresstracker.Application.DataObjectHandler;
using System.Diagnostics;
using System.Windows;

namespace Progresstracker.Adapter
{
    public interface IProfileAdapter
    {
        Task<(bool Success, string ErrorMessage)> CreateProfile(string name, string steamApiKey, string steamProfileId);
    }

    public class ProfileAdapter : IProfileAdapter
    {
        private readonly IProfileService _profileService;

        public ProfileAdapter(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<(bool Success, string ErrorMessage)> CreateProfile(string name, string steamApiKey, string steamProfileId)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                errors.Add("Der Profilname muss mindestens 3 Zeichen lang sein.");

            if (string.IsNullOrWhiteSpace(steamApiKey) || steamApiKey.Length != 32 || !steamApiKey.All(char.IsLetterOrDigit))
                errors.Add("Der Steam API Key muss 32 alphanumerische Zeichen enthalten.");

            if (string.IsNullOrWhiteSpace(steamProfileId) ||
                steamProfileId.Length != 17 ||
                !steamProfileId.All(char.IsDigit) ||
                !steamProfileId.StartsWith("7656119"))
            {
                errors.Add("Die Steam ID muss eine 17-stellige Zahl sein und mit '7656119' beginnen.");
            }

            if (errors.Any())
            {
                return (false, string.Join(Environment.NewLine, errors));
            }

            var profile = new UserProfile(name, steamApiKey, steamProfileId);
            await _profileService.CreateProfile(profile);

            return (true, null);
        }
    }
}
