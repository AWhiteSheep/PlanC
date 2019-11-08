using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Tcrssklelem
    {
        public string CrsId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public string SklId { get; set; }
        public short SklelemSqnbr { get; set; }
        public string PrtlSklInd { get; set; }
        public string TxnmyCd { get; set; }

        public SkillElement Skl { get; set; }
        public CourseTemplate Tcrstmplt { get; set; }
    }
}
