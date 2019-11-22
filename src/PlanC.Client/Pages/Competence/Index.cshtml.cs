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
    public class IndexModel : PageModel
    {
        // identification du département donné afin de trouver tous les compétences associées
        public int Id { get; set; }
        private readonly PlanC.Client.Data.PCU001Context _context;

        public IndexModel(PlanC.Client.Data.PCU001Context context)
        {
            _context = context;
        }

        public IList<Competences> Competences { get;set; }

        public async Task OnGetAsync()
        {
            Competences = await _context.Competences
                .Include(c => c.Discipline).ToListAsync();
        }

        public async Task OnGetAsync(int id)
        {
            Competences = await _context.Competences.Where(p => p.DisciplineId == id)
                .Include(c => c.Discipline).ToListAsync();
        }
    }
}
