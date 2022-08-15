using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            ClinicAddresses = new HashSet<ClinicAddress>();
            ClinicPhoneNumbers = new HashSet<ClinicPhoneNumber>();
            ClinicRates = new HashSet<ClinicRate>();
            Employees = new HashSet<Employee>();
            Invoices = new HashSet<Invoice>();
        }

        public decimal Id { get; set; }
        public string ClinicName { get; set; }
        public DateTime AdditionDate { get; set; }
        public string ClinicLogo { get; set; }

        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public virtual ICollection<ClinicAddress> ClinicAddresses { get; set; }
        public virtual ICollection<ClinicPhoneNumber> ClinicPhoneNumbers { get; set; }
        public virtual ICollection<ClinicRate> ClinicRates { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
