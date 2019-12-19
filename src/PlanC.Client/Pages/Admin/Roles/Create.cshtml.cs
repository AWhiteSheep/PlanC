using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlanC.Client.Pages.Identity.Pages.Models;

namespace PlanC.Client
{
    public class CreateModel : PageModel
    {
        readonly RoleManager<IdentityRole> roleManager;
        private readonly SecretContext secretContext;

        public CreateModel(RoleManager<IdentityRole> roleManager, SecretContext secretContext)
        {
            this.roleManager = roleManager;
            this.secretContext = secretContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IdentityRole IdentityRoleEntity { get; set; } = new IdentityRole();

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //crée un rôle et créera une clef secret allant avec le rôle 
            var role = await roleManager.CreateAsync(IdentityRoleEntity);

            if (role.Succeeded) 
            {
                var roleId = await roleManager.GetRoleIdAsync(IdentityRoleEntity);
                // création de la clé secret avec un total vie de 30, chaque utilisation cout 1
                secretContext.Add(new RolesSecretKeys() { RoleId = roleId, LifeSpan = 30 });
                secretContext.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
