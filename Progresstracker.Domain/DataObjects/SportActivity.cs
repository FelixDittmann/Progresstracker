using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Domain.DataObjects
{
    public class SportActivity(string name, string category, int wantedResult, int? currentProgress) : IActivity
    {
        public long ActivityID { get; set; }
        public string Name { get; set; } = name;
        public string Category { get; set; } = category;
        public int WantedResult { get; set; } = wantedResult;
        public int CurrentProgress { get; set; } = currentProgress ?? 0;
        List<int> IActivity.CurrentProgress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
