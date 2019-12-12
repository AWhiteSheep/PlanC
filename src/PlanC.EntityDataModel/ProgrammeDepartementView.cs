using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class ProgrammeDepartementView
    {
        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(250)]
        public string Titre { get; set; }
    }
}
