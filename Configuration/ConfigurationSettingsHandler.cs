using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Configuration
{
    public class ConfigurationSettingsHandler
    {
        public readonly string DatabasePath;

        public ConfigurationSettingsHandler()
        {
            DatabasePath = System.Configuration.ConfigurationManager.AppSettings["DbPath"] ?? "";
        }
    }
}
