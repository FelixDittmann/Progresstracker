﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Domain.DataObjects
{
    public class ReadActivity(int activityId, string name, string category, int wantedResult, List<int>? currentProg) : IActivity
    {
        public long Id { get; set; } = activityId;
        public string Name { get; set; } = name;
        public string Category { get; set; } = category;
        public int WantedResult { get; set; } = wantedResult;
        public List<int> CurrentProgress { get; set; } = currentProg ?? [];
    }
}
