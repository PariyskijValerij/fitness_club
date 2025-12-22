using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_club.Data
{
    public class MembershipTypeFilter
    {
        public bool FilterActive { get; set; } 
        public bool FilterInactive { get; set; }

        public bool FreezeAllowed { get; set; }

        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }

        public int? DurationFrom { get; set; }
        public int? DurationTo { get; set; }
    }
}
