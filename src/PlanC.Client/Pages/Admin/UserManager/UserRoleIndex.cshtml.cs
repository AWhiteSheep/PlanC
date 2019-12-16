using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Areas.Identity.Models;

namespace PlanC.Client
{
    public class UserRoleIndexModel : PageModel
    {
        private readonly PlanC.Client.Areas.Identity.Models.PCU001Context _context;

        public UserRoleIndexModel(PlanC.Client.Areas.Identity.Models.PCU001Context context)
        {
            _context = context;
        }

        public IList<AspNetUserRoles> AspNetUserRoles { get;set; }

        public async Task OnGetAsync()
        {
            AspNetUserRoles = await _context.AspNetUserRoles
                .Include(a => a.Role).ToListAsync();
        }
    }
}
