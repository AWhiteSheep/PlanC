using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Web.Models
{
    public class PlanCadre
    {
        [Display(Name = "Titre du cours")]
        public string titre_cours { get; set; }
        [Display(Name = "Code du cours")]
        public string code_cours { get; set; }
        [Display(Name = "Nombre d'unités")]
        public string nb_unite { get; set; }
        [Display(Name = "Pondération")]
        public string ponderation_cours { get; set; }
        [Display(Name = "Date d'adoption par le departement")]
        public DateTime date_adoption_plan_cadre { get; set; }
        [Display(Name = "Intentions éducatives")]
        public string intention_educatives_cours { get; set; }
        [Display(Name = "Description du cours")]
        public string description_cours { get; set; }
    }
}
