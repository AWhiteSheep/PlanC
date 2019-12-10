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

namespace PlanC.Client.Pages.Profils
{
    public class Usager : ComponentBase
    {
        [Inject]
        public UserManager<Utilisateurs> _userManager { get; set; }
        [Inject]
        public SignInManager<Utilisateurs> _signInManager { get; set; }
        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }
        // utilisateur pour qui les formulaire sont
        public Utilisateurs user;

        public string Username { get; set; }
        // message destiné a l'usagé
        public string StatusMessage { get; set; }

        public InputModel Input { get; set; }
        public class InputModel
        {
            // validation pour un téléphone
            [Phone]
            public string PhoneNumber { get; set; }
        }
        public async void LoadAsync(ClaimsPrincipal __user)
        {
            user = (await _userManager.GetUserAsync(__user));
            var userName = user.UserName;
            var phoneNumber = user.PhoneNumber;

            Username = userName;
        }
        public async Task PostNumberAsync()
        {
            if (Input.PhoneNumber != user.PhoneNumber)
            {
                await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Votre profil a été sauvegardé";
            // refresh la page pour l'utilisateur
            StateHasChanged();
        }
    }
}
