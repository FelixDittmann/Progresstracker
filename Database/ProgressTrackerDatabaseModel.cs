using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Progresstracker.Database
{
    using System.Collections.Generic;

    public class Game
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string Name { get; set; }
        public int PlaytimeForever { get; set; }

        // Navigation Property: Eine Liste von Errungenschaften pro Spiel
        public List<Achievement> Achievements { get; set; }
    }

    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Achieved { get; set; }

        // Fremdschlüssel zum Spiel
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
    internal class ProgressTrackerDatabaseModel
    {
    }
}
