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

            return await _profileService.CreateProfile(name, steamApiKey, steamProfileId);

        }
    }
}
