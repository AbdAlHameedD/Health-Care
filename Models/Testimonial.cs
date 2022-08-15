using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class Testimonial
    {
        public decimal Id { get; set; }
        public decimal? AccountId { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
