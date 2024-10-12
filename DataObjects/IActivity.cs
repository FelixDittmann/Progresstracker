using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.DataObjects
{
    public interface IActivity
    {
        public long ActivityID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int WantedResult { get; set; }
        public int CurrentProgress { get; set; }
    }
}
