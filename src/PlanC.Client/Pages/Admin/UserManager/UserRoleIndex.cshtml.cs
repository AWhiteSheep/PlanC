using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client
{
    public class UserRoleIndexModel : PageModel
    {
        private readonly PlanC.Client.Data.PCU001Context _context;

        public readonly RoleManager<IdentityRole> roleManager;
        public UserManager<AspNetUsers> userManager;
        public UserRoleIndexModel(RoleManager<IdentityRole> roleManager, UserManager<AspNetUsers> userManager, PCU001Context context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = context;
        }
        public Dictionary<AspNetUsers, List<string>> AspNetUserRoles { get; set; }
        public List<AspNetUsers> AspNetUsers { get;set; }

        public async Task OnGetAsync()
        {
            AspNetUserRoles = new Dictionary<AspNetUsers, List<string>>();
            AspNetUsers = userManager.Users.ToList();
            foreach (var user in AspNetUsers) 
            {
                var roles = (await userManager.GetRolesAsync(user)).ToList();               
                AspNetUserRoles.Add(user, roles);
            }
        }
    }
}
