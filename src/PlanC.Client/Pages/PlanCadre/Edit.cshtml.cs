using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client.Pages.PlanCadre
{
    public class EditModel : PageModel
    {
        private readonly PlanC.Client.Data.PCU001Context _context;

        public EditModel(PlanC.Client.Data.PCU001Context context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlansCadres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlansCadresExists(PlansCadres.CoursId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlansCadresExists(string id)
        {
            return _context.PlansCadres.Any(e => e.CoursId == id);
        }
    }
}
