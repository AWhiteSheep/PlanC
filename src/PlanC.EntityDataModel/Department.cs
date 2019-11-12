using PlanC.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PlanC.WebApi.Models
{
    public partial class Department
    {
        public Department()
        {
            Tpgm = new HashSet<Tpgm>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Policy { get; set; }
        //public DateTime? RcdCdttm { get; set; }
        public string TrackingUserId { get; set; }

        public ICollection<User> Users { get; set; }
        [JsonIgnore]
        public ICollection<Tpgm> Tpgm { get; set; }
    }
}
