using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Application.DataObjectHandler
{
    public interface IActivityHandler
    {
        public IActivity CreateNew(string name, string category, int wantedResult, int? currentProgress);
    }
}
