using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client.Pages.PlanCadre
{
    public class DeleteModel : PageModel
    {
        private readonly PlanC.Client.Data.PCU001Context _context;

        public DeleteModel(PlanC.Client.Data.PCU001Context context)
        {
            _context = context;
        }

        [BindProperty]
        public PlansCadres PlansCadres { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlansCadres = await _context.PlansCadres.FirstOrDefaultAsync(m => m.CoursId == id);

            if (PlansCadres == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlansCadres = await _context.PlansCadres.FindAsync(id);

            if (PlansCadres != null)
            {
                _context.PlansCadres.Remove(PlansCadres);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
