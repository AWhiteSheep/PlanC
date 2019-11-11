using PlanC.EntityDataModel;
using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class CoursePlan
    {
        public CoursePlan()
        {
            NonFinalCertificativeExams = new HashSet<NonFinalCertificativeExam>();
            CourseActivities = new HashSet<CourseActivity>();
            CourseMaterials = new HashSet<CourseMaterial>();
        }

        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public string TrackingUserId { get; set; }

        public Semester Smstr { get; set; }
        public ICollection<NonFinalCertificativeExam> NonFinalCertificativeExams { get; set; }
        public ICollection<CourseActivity> CourseActivities { get; set; }
        public ICollection<CourseMaterial> CourseMaterials { get; set; }
    }
}
