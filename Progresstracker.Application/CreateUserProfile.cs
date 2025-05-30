using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progresstracker.Domain.DataObjects;
using Progresstracker.Domain.Repository_Interfaces;

namespace Progresstracker.Application
{
    public class CreateUserProfile
    {
        private readonly IUserProfileRepository _repository;

        public CreateUserProfile(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(string displayName, string? steamKey = null, string? steamUserId = null)
        {
            var profile = new UserProfile
            {
                Name = displayName,
                SteamApiKey = steamKey,
                SteamProfileID = steamUserId
            };

            await _repository.AddAsync(profile);
        }
    }

}
