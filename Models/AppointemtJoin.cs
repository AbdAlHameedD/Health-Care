using System;

namespace Health_Care_V1._2.Models
{
    public class AppointemtJoin
    {
        // Appointment Table
        public decimal Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }

        // Account Table
        public decimal PatientAccountId { get; set; }
        public string PatientFname { get; set; }
        public string PatientMname { get; set; }
        public string PatientLname { get; set; }
        public string PatientEmail { get; set; }
        public string PatientGender { get; set; }
        public DateTime PatientBoD { get; set; }
        public string PatientProfilePicture { get; set; }

        // Employee Table
        public decimal DoctorId { get; set; }

        // Account Table
        public decimal DoctorAccountId { get; set; }
        public string DoctorFname { get; set; }
        public string DoctorMname { get; set; }
        public string DoctorLname { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorProfilePicture { get; set; }

        // Clinic Table
        public decimal ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string ClinicLogo { get; set; }
    }
}
