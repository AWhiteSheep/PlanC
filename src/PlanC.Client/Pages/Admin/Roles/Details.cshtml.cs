using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PlanC.Client
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        RoleManager<IdentityRole> roleManager { get; set; }

        [BindProperty]
        public IdentityRole IdentityRoleEntity { get; set; }

        public DetailsModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IdentityRoleEntity = await roleManager.FindByIdAsync(id);

            if (IdentityRoleEntity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
