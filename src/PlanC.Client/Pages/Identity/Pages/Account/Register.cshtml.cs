using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client.Pages.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Utilisateurs> _signInManager;
        private readonly UserManager<Utilisateurs> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<Utilisateurs> userManager,
            SignInManager<Utilisateurs> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel : Utilisateurs
        {     
            [Required(ErrorMessage = "{0} est obligatoire.")]
            [EmailAddress]
            [Display(Name = "Addresse couriel")]
            public override string Email { get; set; }

            [Required(ErrorMessage = "{0} est obligatoire.")]
            [Phone]
            [Display(Name = "Numéro de votre poste")]
            public override string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Le numéro est obligatoire d'usagé.")]
            [StringLength(7, ErrorMessage = "Le numéro de peut dépasser 7 charactères.")]
            [RegularExpression("^[0-9]+$", ErrorMessage = "Le numéro ne peut que contenir des chiffres.")]
            [Display(Name = "Numéro d'utilisateur")]
            public override string UserName { get; set; }

            [Required(ErrorMessage = "{0} est obligatoire.")]
            [StringLength(100, ErrorMessage = "Le mot de passe doit être au moins {2} et au maximum {1} charactères de long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mot de passe")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmation du mot de passe")]
            [Compare("Password", ErrorMessage = "Les mots de passe ne sont pas identiques.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Département")]
            [Required(ErrorMessage = "Le département doit être sélectionné.")]
            public new int DepartementId { get; set; }

            [Display(Name = "Nom de famille")]
            [Required(ErrorMessage = "{0} est obligatoire.")]
            [StringLength(50)]
            [PersonalData]
            public new string GvnNm { get; set; } // prénom

            [Display(Name = "Prénom")]
            [Required(ErrorMessage = "{0} est obligatoire.")]
            [StringLength(50)]
            public new string Snm { get; set; }

            [Display(Name = "Clé d'enregistrement")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Vous devez saisir la clée d'enregistrement.")]
            public string Clef { get; set; }
        }

        public IActionResult OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (Input.Clef != "585858") {
                ModelState.AddModelError("Clef", "La clée n'a pas été trouvée, s'il vous plaît contacter l'administrateur du système.");
            }

            if (ModelState.IsValid)
            {
                var user = new Utilisateurs { UserName = Input.UserName, DepartementId = Input.DepartementId,
                    PhoneNumber = Input.PhoneNumber, Email = Input.Email, GvnNm = Input.GvnNm, Snm = Input.Snm };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
