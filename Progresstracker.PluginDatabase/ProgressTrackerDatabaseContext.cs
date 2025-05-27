using Microsoft.EntityFrameworkCore;
using Progresstracker.Adapter.Configuration.Progresstracker.Configuration;
using Progresstracker.Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Progresstracker.PluginDatabase
{

public class ProgressTrackerDatabaseContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserProfile> Profiles { get; set; } 
        public DbSet<SportActivity> SportActivities { get; set; }
        private ConfigurationSettingsHandler _configuration;

        public ProgressTrackerDatabaseContext(ConfigurationSettingsHandler configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasKey(g => g.Id);
            modelBuilder.Entity<Achievement>().HasKey(a => a.Id);
            // weitere Konfigurationen
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.DatabasePath);
        }
    }
}
