using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlanC.Client.Areas.Identity.Models;
using PlanC.EntityDataModel;

namespace PlanC.Client
{
    public class UserRoleCreateModel : PageModel
    {
        readonly RoleManager<IdentityRole> roleManager;
        UserManager<AspNetUsers> userManager;
        public UserRoleCreateModel(RoleManager<IdentityRole> roleManager, UserManager<AspNetUsers> userManager, PCU001Context context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            Context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RoleId"] = new SelectList(roleManager.Roles.ToList(), "Id", "Name");
            ViewData["UserId"] = new SelectList(userManager.Users.ToList(), "Username", "Identitfiant");
            return Page();
        }

        [BindProperty]
        public AspNetUserRoles AspNetUserRoles { get; set; }
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
            var user = Context.AspNetUsers.Find(AspNetUserRoles.UserId);
            var role = await roleManager.FindByNameAsync(AspNetUserRoles.RoleId);
            userManager.AddToRoleAsync(user, role.Name);
            return RedirectToPage("./Index");
        }
    }
}
