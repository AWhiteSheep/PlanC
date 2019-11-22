using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client.Pages.Competence
{
    public class CreateModel : PageModel
    {
        private readonly PlanC.Client.Data.PCU001Context _context;

        public CreateModel(PlanC.Client.Data.PCU001Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CompetenceId"] = new SelectList(_context.Competences, "CompetenceId", "CompetenceId");
            return Page();
        }

        [BindProperty]
        public ElementsCompetence ElementsCompetence { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ElementsCompetence.Add(ElementsCompetence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
