using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class CreditCard
    {
        public decimal Id { get; set; }
        public decimal? AccountId { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public decimal ExpMonth { get; set; }
        public decimal ExpYear { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
