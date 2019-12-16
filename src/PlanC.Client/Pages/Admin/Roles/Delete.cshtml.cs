using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PlanC.Client
{
    public class DeleteModel : PageModel
    {
        RoleManager<IdentityRole> roleManager { get; set; }

        public DeleteModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [BindProperty]
        public IdentityRole IdentityRoleEntity { get; set; }

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IdentityRoleEntity = await roleManager.FindByIdAsync(id);

            if (IdentityRoleEntity != null)
            {
                await roleManager.DeleteAsync(IdentityRoleEntity);
            }

            return RedirectToPage("./Index");
        }
    }
}
