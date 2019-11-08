using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Semester
    {
        public Semester()
        {
            CoursePlans = new HashSet<CoursePlan>();
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TrackingUserId { get; set; }

        public ICollection<CoursePlan> CoursePlans { get; set; }
    }
}
