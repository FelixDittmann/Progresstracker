using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using Progresstracker.DataObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace Progresstracker.Database
{
    

    public class Game(long appid, string name, int playtime, string source)
    {
        public long AppId { get; set; } = appid;
        public string Name { get; set; } = name;
        public int PlaytimeForever { get; set; } = playtime;
        public string Source { get; set; } = source;
    }

    public class Achievement(string name, string description, bool achieved, long gameid, long profileid, string source)
    {
        public long Id { get; set; }
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public bool Achieved { get; set; } = achieved;

        [ForeignKey("Game")]
        public long GameId { get; set; } = gameid;
        public string Source { get; set; } = source;
        [ForeignKey("Profile")]
        public long ProfileID { get; set; } = profileid;
    }
    internal class ProgressTrackerDatabaseModel
    {
    }
}
