using System;

namespace fitness_club.Data
{
    public class ClientFilter
    {
        public bool FilterMale { get; set; }
        public bool FilterFemale { get; set; }
        public bool FilterOther { get; set; }
        public bool FilterActive { get; set; }
        public bool FilterInactive { get; set; }

        public DateTime? RegistrationDateFrom { get; set; }
        public DateTime? RegistrationDateTo { get; set; }
    }
}
