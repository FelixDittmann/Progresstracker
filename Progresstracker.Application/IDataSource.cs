using Microsoft.Extensions.Logging;
using Progresstracker.Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Application
{
    public partial interface IDataSource
    {
        Task<List<Achievement>> GetAchievementsAsync(Game game, UserProfile profile);

        [LoggerMessage(Level = LogLevel.Warning, Message = "Profile is missing. Please use a valid profile or create a new one")]
        static partial void LogMissingProfile(ILogger logger);
    }
}
