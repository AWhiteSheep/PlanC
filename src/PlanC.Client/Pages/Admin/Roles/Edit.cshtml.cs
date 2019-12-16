using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Areas.Identity.Models;

namespace PlanC.Client
{
    public class EditModel : PageModel
    {
        RoleManager<IdentityRole> roleManager { get; set; }

        [BindProperty]
        public IdentityRole IdentityRoleEntity { get; set; }

        public EditModel(RoleManager<IdentityRole> roleManager)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await roleManager.UpdateNormalizedRoleNameAsync(IdentityRoleEntity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await roleManager.RoleExistsAsync(IdentityRoleEntity.Id))
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
    }
}
