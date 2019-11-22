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

namespace PlanC.Client.Pages.Competence
{
    public class EditModel : PageModel
    {
        private readonly PlanC.Client.Data.PCU001Context _context;

        public EditModel(PlanC.Client.Data.PCU001Context context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DisciplineId"] = new SelectList(_context.Departements, "Id", "Id");
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

            _context.Attach(Competences).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetencesExists(Competences.CompetenceId))
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

        private bool CompetencesExists(string id)
        {
            return _context.Competences.Any(e => e.CompetenceId == id);
        }
    }
}
