using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanC.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlanC.Web.Client.Areas.Personnel.Pages.Competences
{
    public class NouvelleModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public Skill Competence { get; set; }
    }
}
