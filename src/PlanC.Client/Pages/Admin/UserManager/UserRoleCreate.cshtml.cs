using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client
{
    [Authorize(Roles = "Admin")]
    public class UserRoleCreateModel : PageModel
    {
        public readonly RoleManager<IdentityRole> roleManager;
        public UserManager<AspNetUsers> userManager;
        public UserRoleCreateModel(RoleManager<IdentityRole> roleManager, UserManager<AspNetUsers> userManager, PCU001Context context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            Context = context;
        }

        public IActionResult OnGet()
        {
            AspNetUserRoles  = new IdentityUserRole<string>();
            return Page();
        }

        [BindProperty]
        public IdentityUserRole<string> AspNetUserRoles { get; set; }
        [BindProperty]
        public List<IdentityRole> AspNetRoles { get; set; }
        [BindProperty]
        public List<AspNetUsers> AspNetUsers { get; set; }
        public UserManager<AspNetUsers> UserManager { get; }
        public PCU001Context Context { get; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // trouve l'utilisateur trouvé
            var user = await userManager.FindByIdAsync(AspNetUserRoles.UserId);
            // trouve le role et le relie dans la base de donné
            var role = await roleManager.FindByIdAsync(AspNetUserRoles.RoleId);
            await userManager.AddToRoleAsync(user, role.Name);
            return Redirect("/admin/roles/authorise");
        }
    }
}
