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
        public ElementsCompetence ElementsCompetence { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ElementsCompetence = await _context.ElementsCompetence
                .Include(e => e.Competences).FirstOrDefaultAsync(m => m.CompetenceId == id);

            if (ElementsCompetence == null)
            {
                return NotFound();
            }
           ViewData["CompetenceId"] = new SelectList(_context.Competences, "CompetenceId", "CompetenceId");
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

            _context.Attach(ElementsCompetence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementsCompetenceExists(ElementsCompetence.CompetenceId))
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

        private bool ElementsCompetenceExists(string id)
        {
            return _context.ElementsCompetence.Any(e => e.CompetenceId == id);
        }
    }
}
