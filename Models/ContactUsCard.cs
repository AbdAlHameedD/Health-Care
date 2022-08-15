using System;
using System.Collections.Generic;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class ContactUsCard
    {
        public decimal Id { get; set; }
        public string Icon { get; set; }
        public string ContactTitle { get; set; }
        public string ContactContent { get; set; }
        public string Link { get; set; }
    }
}
