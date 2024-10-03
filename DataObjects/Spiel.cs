using Progresstracker.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.DataObjects
{
    public class Spiel
    {
        public int AppId { get; set; }
        public string Name { get; set; }
        public int Playtime { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
}
