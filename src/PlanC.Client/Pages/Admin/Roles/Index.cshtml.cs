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
    public class IndexModel : PageModel
    {
        RoleManager<IdentityRole> roleManager;

        public IndexModel(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        public IList<IdentityRole> IdentityRolesList { get;set; }

        public async Task OnGetAsync()
        {
            IdentityRolesList = await roleManager.Roles.ToListAsync();
        }
    }
}
