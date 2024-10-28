using Microsoft.Extensions.Logging;
using Progresstracker.Database;
using Progresstracker.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Quellen
{
    public partial interface IDataSource
    {
        Task<List<Achievement>> GetAchievementsAsync(long gameId, Profile profile);

        [LoggerMessage(Level = LogLevel.Warning, Message = "Profile is missing. Please use a valid profile or create a new one")]
        static partial void LogMissingProfile(ILogger logger);
    }
}
