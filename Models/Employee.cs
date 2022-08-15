using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Appointments = new HashSet<Appointment>();
            DoctorRates = new HashSet<DoctorRate>();
            Invoices = new HashSet<Invoice>();
        }

        public decimal Id { get; set; }
        public decimal? AccountId { get; set; }
        public decimal? ClinicId { get; set; }
        public decimal Salary { get; set; }

        public virtual Account Account { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<DoctorRate> DoctorRates { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
