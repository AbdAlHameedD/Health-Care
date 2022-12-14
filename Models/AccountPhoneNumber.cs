using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class AccountPhoneNumber
    {
        public decimal Id { get; set; }
        public decimal AccountId { get; set; }
        public decimal PhoneNumber { get; set; }

        public virtual Account Account { get; set; }
    }
}
