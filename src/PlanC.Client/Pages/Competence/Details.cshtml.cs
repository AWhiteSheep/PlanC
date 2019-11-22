using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client.Pages.Competence
{
    public class DetailsModel : PageModel
    {
        private readonly PlanC.Client.Data.PCU001Context _context;

        public DetailsModel(PlanC.Client.Data.PCU001Context context)
        {
            _context = context;
        }

        public Competences Competences { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Competences = await _context.Competences
                .Include(c => c.Discipline).FirstOrDefaultAsync(m => m.CompetenceId == id);

            if (Competences == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
