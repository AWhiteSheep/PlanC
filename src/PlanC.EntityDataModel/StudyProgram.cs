using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PlanC.WebApi.Models
{
    public partial class Tpgm
    {
        public Tpgm()
        {
            CourseTemplates = new HashSet<CourseTemplate>();
            Skills = new HashSet<Skill>();
        }

        public string PgmId { get; set; }
        public int DepartmentId { get; set; }
        public string PgmTitle { get; set; }
        public string PgmDesc { get; set; }
        public string Category { get; set; }
        public string TrackingUserId { get; set; }


        [JsonIgnore]
        public Department Department { get; set; }
        public ICollection<CourseTemplate> CourseTemplates { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
