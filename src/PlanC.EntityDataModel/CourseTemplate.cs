using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanC.WebApi.Models
{
    public partial class CourseTemplate
    {
        public CourseTemplate()
        {
            Tcrsreq = new HashSet<CourseRequirement>();
            Tcrssklelem = new HashSet<Course_SkillElement>();
            Tfnlexam = new HashSet<FinalCertificativeExam>();
        }

        public string Id { get; set; }
        public DateTime VsnCdttm { get; set; }
        public string PgmId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal? Units { get; set; }
        public string Description { get; set; }
        public string Intent { get; set; }
        public DateTime? DepartmentApprovalDate { get; set; }
        public DateTime? CommitteeApprovalDate { get; set; }
        public DateTime? BoardApprovalDate { get; set; }
        public string TrackingUserId { get; set; }
        //public DateTime? RcdCdttm { get; set; }

        public Tpgm Pgm { get; set; }
        public ICollection<CourseRequirement> Tcrsreq { get; set; }
        public ICollection<Course_SkillElement> Tcrssklelem { get; set; }
        public ICollection<FinalCertificativeExam> Tfnlexam { get; set; }
    }
}
