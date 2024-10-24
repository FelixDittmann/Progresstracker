using Microsoft.EntityFrameworkCore;
using Progresstracker.Configuration;
using Progresstracker.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Database
{

public class ProgressTrackerDatabaseContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Profile> Profiles { get; set; } 
        public DbSet<SportActivity> SportActivities { get; set; }
        private ConfigurationSettingsHandler _configuration;

        public ProgressTrackerDatabaseContext(ConfigurationSettingsHandler configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.DatabasePath);
        }
    }
}
