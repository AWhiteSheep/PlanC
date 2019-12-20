using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Pages.Identity.Pages.Models;

namespace PlanC.Client
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        RoleManager<IdentityRole> roleManager;
        private readonly SecretContext secretContext;

        public IndexModel(RoleManager<IdentityRole> _roleManager, SecretContext secretContext)
        {
            roleManager = _roleManager;
            this.secretContext = secretContext;
        }

        public IList<AspNetRoles> IdentityRolesList { get;set; }
        public IList<RolesSecretKeys> secrets { get;set; }


        [BindProperty]
        public IdentityRole RoleModification { get; set; }

        public async Task OnGetAsync()
        {
            IdentityRolesList = await secretContext.AspNetRoles.ToListAsync();
            secrets = await secretContext.RolesSecretKeys.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // bind le id recu en paramètre et recherche l'objet dans la base de données
            var result = await roleManager.FindByIdAsync(RoleModification.Id);
            if (result != null) 
            {
                // fait la modification du nom et rapporte une nouvelle liste
                await roleManager.SetRoleNameAsync(result, RoleModification.Name);
                await roleManager.UpdateNormalizedRoleNameAsync(result);
            }

            IdentityRolesList = await secretContext.AspNetRoles.ToListAsync();
            return Page();
        }
    }
}
