using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
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

        public ICollection<Tcrspln> Tcrspln { get; set; }
    }
}
