using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using PlanC.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Client.Authorization
{
    public class NumberAuthHandler : AuthorizationHandler<UserIdLenghtRequirement>
    {
        [Inject]
        public UserManager<AspNetUsers> UserManager { get; set; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIdLenghtRequirement requirement)
        {
            // authorize l'accès si le numéro de l'utilisateur contient un certain nombre de chiffre
            var username = UserManager.GetUserName(context.User);
            if (username.Length == requirement.UserIdLenght) 
            {
                //retourne que le test a passé
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
