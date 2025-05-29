using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Domain.DataObjects
{
    public interface IActivity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int WantedResult { get; set; }
        public List<int> CurrentProgress { get; set; }

        public void UpdateCurrentProgress(int newProgress)
        {
            CurrentProgress.Add(newProgress);
        }
    }
}
