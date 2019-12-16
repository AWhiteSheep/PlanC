using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Areas.Identity.Models;

namespace PlanC.Client
{
    public class UserRoleDeleteModel : PageModel
    {
        readonly RoleManager<IdentityRole> roleManager;
        private readonly PlanC.Client.Areas.Identity.Models.PCU001Context _context;

        [BindProperty]
        public AspNetUserRoles AspNetUserRoles { get; set; }


        public UserRoleDeleteModel(PlanC.Client.Areas.Identity.Models.PCU001Context context, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AspNetUserRoles = await _context.AspNetUserRoles
                .Include(a => a.Role).FirstOrDefaultAsync(m => m.UserId == id);

            if (AspNetUserRoles == null)
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

            AspNetUserRoles = await _context.AspNetUserRoles.FindAsync(id);

            if (AspNetUserRoles != null)
            {
                _context.AspNetUserRoles.Remove(AspNetUserRoles);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
