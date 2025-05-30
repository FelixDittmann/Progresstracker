using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Domain.DataObjects
{
    public class GameSourceIdentifier
    {
        public Guid Id { get; set; }
        public string Source { get; set; }
        public string ExternalId { get; set; }
    }
}
