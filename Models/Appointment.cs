using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class Appointment
    {
        public decimal Id { get; set; }
        public decimal? PatientId { get; set; }
        public decimal? DoctorId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Employee Doctor { get; set; }
        public virtual Account Patient { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
