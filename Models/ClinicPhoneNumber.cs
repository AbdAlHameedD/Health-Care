using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class ClinicPhoneNumber
    {
        public decimal Id { get; set; }
        public decimal ClinicId { get; set; }
        public decimal PhoneNumber { get; set; }

        public virtual Clinic Clinic { get; set; }
    }
}
