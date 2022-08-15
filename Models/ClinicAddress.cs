using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class ClinicAddress
    {
        public decimal Id { get; set; }
        public decimal ClinicId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public decimal? BuildingNumber { get; set; }

        public virtual Clinic Clinic { get; set; }
    }
}
