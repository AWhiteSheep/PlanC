using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanC.EntityDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Claims;
using PlanC.Client.Data;
using Microsoft.JSInterop;

namespace PlanC.Client.Pages.Profils
{
    public class Usager : ComponentBase
    {
        [Inject]
        public UserManager<AspNetUsers> _userManager { get; set; }
        [Inject]
        public SignInManager<AspNetUsers> _signInManager { get; set; }
        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public PCU001Context _context { get; set; }
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        // utilisateur pour qui les formulaire sont
        public AspNetUsers user;
        // list des départements que peut choisir l'utilisateur
        public List<PlanC.EntityDataModel.Departements> GetDepartements { 
            get => _context.Departements.ToList();  
        }
        public string Username { get; set; }
        // message destiné a l'usagé
        public string StatusMessage { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public InputModel Input { get; set; }
        public InputPasswordModel InputPassword { get; set; }
        public InputPersonnalData InputPerson { get; set; }
        public class InputModel
        {
            // validation pour un téléphone
            [Phone]
            [Display(Name = "Combiné de votre poste")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Campus primaire")]
            public string Campus { get; set; }
            [Display(Name = "Bureau")]
            public string Office { get; set; }
            [Display(Name = "Département")]
            [RegularExpression("^[0-9]+$")]
            // département ID mais doit être en string pas oublier de le convertir
            public string Département { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Nouvelle email")]
            public string NewEmail { get; set; }
        }
        public class InputPasswordModel
        {
            [Required(ErrorMessage = "{0} est obligatoire")]
            [DataType(DataType.Password)]
            [Display(Name = "L'ancien mot de passe")]
            public string OldPassword { get; set; }

            [Required(ErrorMessage = "{0} est obligatoire")]
            [StringLength(100, ErrorMessage = "Le mot de passe doit être au moins {2} et au maximum {1} charactères de long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nouveau mot de passe")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmer nouveau mot de passe")]
            [Compare("NewPassword", ErrorMessage = "Les mots de passe ne sont pas identiques.")]
            public string ConfirmPassword { get; set; }
        }

        public class InputPersonnalData 
        {
            [Required(ErrorMessage = "{0} est obligatoire")]
            [Display(Name = "Prénom")]
            public string Prénom { get; set; }
            [Required(ErrorMessage = "{0} est obligatoire")]
            [Display(Name = "Nom de famille")]
            public string Nom { get; set; }
            [Display(Name = "Choix de votre image de profil")]
            public int ImageProfilChoice { get; set; }
        }
        // sauvegarde le numéro de téléphone
        public async Task PostPublicAsync()
        {
            var postError = "";
            var postSuccess = "";

            if (Input.PhoneNumber != user.PhoneNumber)
            {
                try
                {
                    await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                    postSuccess += "Votre numéro de téléphone a été changé." + "<br/>";
                }
                catch(Exception e) {
                    postError += "Erreur, votre poste n'a pas été changé." + Environment.NewLine;
                }
            }
            if (Input.NewEmail != user.Email)
            {
                try
                {
                    await _userManager.SetEmailAsync(user, Input.NewEmail);
                    postSuccess += "Le lien de confirmation vous a été envoyé par email. Veuillez voir votre boîte de messagerie." + Environment.NewLine;
                }
                catch(Exception e)
                {
                    postError += "Erreur, votre email n'a pas été changé." + Environment.NewLine;
                }
            }

            user.Office = Input.Office;
            user.DepartementId = int.Parse(Input.Département);

            if (postError != "")
                StatusMessage = postError;
            else if (postSuccess != "")
                StatusMessage = postSuccess;

            // refresh la page pour l'utilisateur
            SaveProgress();
            StateHasChanged();
        }
        public async Task PostPasswordAsync()
        {
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, InputPassword.OldPassword, InputPassword.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    StatusMessage += error + Environment.NewLine;
                }
            }
            else
            {
                StatusMessage = "Votre mot de passe a été changé.";
            }
            // refresh la page pour l'utilisateur
            StateHasChanged();
        }
        public async Task PostPersonnalDataAsync()
        {
            user.GvnNm = InputPerson.Nom;
            user.Snm = InputPerson.Prénom;
            user._ImageProfilChoice = InputPerson.ImageProfilChoice;
            SaveProgress();
        }

        public void SaveProgress()
        {
            try
            {
                _context.SaveChanges();
                StateHasChanged();
            }
            catch (Exception except)
            {
                Console.WriteLine($"Plan cadre liste error: {except.Message}");
            }
        }

    }
}
