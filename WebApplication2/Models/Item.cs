using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Item
    {
        public string ItCode { get; set; }
        public string ItDesc { get; set; }
        public decimal ItRate { get; set; }
        public int SuplNo { get; set; }

        public virtual Supplier SuplNoNavigation { get; set; }
    }
}
