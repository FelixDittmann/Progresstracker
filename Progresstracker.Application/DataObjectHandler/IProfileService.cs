using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Progresstracker.Domain.DataObjects;
using Progresstracker.Domain.Repository_Interfaces;
using System.Diagnostics;

namespace Progresstracker.Application.DataObjectHandler
{
    public interface IProfileService
    {
        Task CreateProfile(UserProfile profile);
    }

    public class ProfileService : IProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public ProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task CreateProfile(UserProfile profile)
        {
            await _userProfileRepository.AddAsync(profile);
        }
    }
}
