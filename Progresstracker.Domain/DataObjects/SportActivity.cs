using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Domain.DataObjects
{
    public class SportActivity : IActivity
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public int WantedResult { get; set; }
        public int CurrentProgress { get; set; }
        List<int> IActivity.CurrentProgress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SportActivity(string name, string category, int wantedResult, int? currentProgress)
        {
            Name = name;
            Category = category;
            WantedResult = wantedResult;
            CurrentProgress = currentProgress ?? 0;
        }

        // Konstruktor für EF Core
        public SportActivity() { }
    }
}
