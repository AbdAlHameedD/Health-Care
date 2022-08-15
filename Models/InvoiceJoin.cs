using System;

namespace Health_Care_V1._2.Models
{
    public class InvoiceJoin
    {
        public decimal InvoiceId { get; set; }
        public decimal InvoiceTotalPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
        public decimal AppointmentId { get; set; }
    }
}
