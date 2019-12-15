using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client.Pages.Profils
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }

        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signInManager;
        private readonly PlanC.Client.Data.PCU001Context _context;

        private AspNetUsers utilisateur;

        public CreateModel(PlanC.Client.Data.PCU001Context context, UserManager<AspNetUsers> userManager, SignInManager<AspNetUsers> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            utilisateur = await _userManager.GetUserAsync((await authenticationStateTask).User);
            ViewData["Uid"] = utilisateur.UserName;
                return Page();
        }

        [BindProperty]
        public DisponibilitesUtilisateur DisponibilitesUtilisateur { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DisponibilitesUtilisateur.Add(DisponibilitesUtilisateur);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
