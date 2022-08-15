using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class InvoiceItem
    {
        public decimal Id { get; set; }
        public decimal InvoiceId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
