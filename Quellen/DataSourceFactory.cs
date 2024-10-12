using Progresstracker.Configuration;
using Progresstracker.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Quellen
{
    public static partial class DataSourceFactory
    {
        public static IDataSource CreateDataSource(string sourceType, ConfigurationSettingsHandler configuration, Profile profile)
        {
            switch (sourceType)
            {
                case "steam":
                    return new SteamAchievementPuller(configuration, profile);
                default:
                    throw new ArgumentException("Unknown data source type");
            }
        }
    }
}
