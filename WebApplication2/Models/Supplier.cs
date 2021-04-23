using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Items = new HashSet<Item>();
        }

        public int SuplNo { get; set; }
        public string SuplName { get; set; }
        public string SuplAddr { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
