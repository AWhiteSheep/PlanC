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
        private readonly PlanC.Client.Data.PCU001Context _context;

        public IndexModel(PlanC.Client.Data.PCU001Context context)
        {
            _context = context;
        }

        public IList<ElementsCompetence> ElementsCompetence { get;set; }

        public async Task OnGetAsync()
        {
            ElementsCompetence = await _context.ElementsCompetence
                .Include(e => e.Competences).ToListAsync();
        }
    }
}
