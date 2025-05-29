using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Domain.Repository_Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?> GetByIdAsync(Guid id);
        Task<List<UserProfile>> GetAllAsync();
        Task AddAsync(UserProfile profile);
        Task UpdateAsync(UserProfile profile);
        Task DeleteAsync(int id);
    }
}
