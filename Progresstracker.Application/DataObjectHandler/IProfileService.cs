using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Progresstracker.Domain.DataObjects;
using Progresstracker.Domain.Repository_Interfaces;

namespace Progresstracker.Application.DataObjectHandler
{
    public interface IProfileService
    {
        void CreateProfile(UserProfile profile);
    }

    public class ProfileService : IProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public ProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public void CreateProfile(UserProfile profile)
        {
            _userProfileRepository.AddAsync(profile);
        }
    }
}
