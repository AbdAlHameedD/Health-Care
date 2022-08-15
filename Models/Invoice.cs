using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }

        public decimal Id { get; set; }
        public decimal? AppointmentId { get; set; }
        public decimal? ClinicId { get; set; }
        public decimal? PatientId { get; set; }
        public decimal? DoctorId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual Employee Doctor { get; set; }
        public virtual Account Patient { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        
    }
}
