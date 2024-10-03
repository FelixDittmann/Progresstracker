using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite-Datenbankverbindung konfigurieren
            optionsBuilder.UseSqlite("Data Source=steam.db");
        }
    }
}
