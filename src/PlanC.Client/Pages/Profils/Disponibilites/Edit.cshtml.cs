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

namespace PlanC.Client.Pages.Profils
{
    public class EditModel : PageModel
    {
        private readonly PlanC.Client.Data.PCU001Context _context;

        public EditModel(PlanC.Client.Data.PCU001Context context)
        {
            _context = context;
        }

        [BindProperty]
        public DisponibilitesUtilisateur DisponibilitesUtilisateur { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DisponibilitesUtilisateur = await _context.DisponibilitesUtilisateur
                .Include(d => d.U).FirstOrDefaultAsync(m => m.Uid == id);

            if (DisponibilitesUtilisateur == null)
            {
                return NotFound();
            }
           ViewData["Uid"] = new SelectList(_context.AspNetUsers, "Id", "Id");
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

            _context.Attach(DisponibilitesUtilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilitesUtilisateurExists(DisponibilitesUtilisateur.Uid))
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

        private bool DisponibilitesUtilisateurExists(string id)
        {
            return _context.DisponibilitesUtilisateur.Any(e => e.Uid == id);
        }
    }
}
