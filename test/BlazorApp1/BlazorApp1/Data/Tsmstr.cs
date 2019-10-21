using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public partial class Tsmstr
    {
        public Tsmstr()
        {
            Tcrspln = new HashSet<Tcrspln>();
        }

        public string SmstrId { get; set; }
        public string SmstrDesc { get; set; }
        public DateTime? SmstrSdt { get; set; }
        public DateTime? SmstrNdt { get; set; }

        public virtual ICollection<Tcrspln> Tcrspln { get; set; }
    }
}
