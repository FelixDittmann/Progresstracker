using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Progresstracker.Adapter.Configuration
{
    namespace Progresstracker.Configuration
    {
        public class ConfigurationSettingsHandler
        {
            public readonly string DatabasePath;

            public ConfigurationSettingsHandler(IConfiguration config)
            {
                DatabasePath = $"Data Source={Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "Debug\\net8.0-windows", "progress.db")}";
            }
        }
    }
}
