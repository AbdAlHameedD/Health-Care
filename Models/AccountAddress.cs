using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class AccountAddress
    {
        public decimal Id { get; set; }
        public decimal AccountId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public virtual Account Account { get; set; }
    }
}
