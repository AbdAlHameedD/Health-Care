using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountPhoneNumbers = new HashSet<AccountPhoneNumber>();
            Appointments = new HashSet<Appointment>();
            ClinicRates = new HashSet<ClinicRate>();
            CreditCards = new HashSet<CreditCard>();
            DoctorRates = new HashSet<DoctorRate>();
            Invoices = new HashSet<Invoice>();
            Logs = new HashSet<Log>();
        }

        public decimal Id { get; set; }
        [Remote("IsUsernameAvailable", "Accounts", ErrorMessage = "Username already exists")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }
        public DateTime Bod { get; set; }
        public string Status { get; set; }
        public string Permission { get; set; }
        public DateTime CreationDate { get; set; }
        public string ProfilePicture { get; set; }
        
        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public virtual AccountAddress AccountAddress { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Testimonial Testimonial { get; set; }
        public virtual ICollection<AccountPhoneNumber> AccountPhoneNumbers { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<ClinicRate> ClinicRates { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<DoctorRate> DoctorRates { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
