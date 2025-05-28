using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Progresstracker.Domain.DataObjects;
using Progresstracker.Domain.Repository_Interfaces;
using System.Diagnostics;

namespace Progresstracker.PluginDatabase
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ProgressTrackerDatabaseContext _context;

        public UserProfileRepository(ProgressTrackerDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserProfile?> GetByIdAsync(Guid id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<UserProfile>> GetAllAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task AddAsync(UserProfile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(UserProfile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
        }
    }
}

