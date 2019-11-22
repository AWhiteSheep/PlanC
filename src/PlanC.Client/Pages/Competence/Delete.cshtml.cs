﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly PlanC.Client.Data.PCU001Context _context;

        public DeleteModel(PlanC.Client.Data.PCU001Context context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ElementsCompetence = await _context.ElementsCompetence.FindAsync(id);

            if (ElementsCompetence != null)
            {
                _context.ElementsCompetence.Remove(ElementsCompetence);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
