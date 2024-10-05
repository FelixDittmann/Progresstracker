using Microsoft.EntityFrameworkCore;
using Progresstracker.Configuration;
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
        private ConfigurationSettingsHandler _configuration;

        public ProgressTrackerDatabaseContext(ConfigurationSettingsHandler configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite-Datenbankverbindung konfigurieren
            optionsBuilder.UseSqlite(_configuration.DatabasePath);
        }
    }
}
