using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Client.Authorization
{
    public class UserIdLenghtRequirement : IAuthorizationRequirement
    {
        public int UserIdLenght { get; set; }
        public UserIdLenghtRequirement(int lengthRequirement) 
        {
            // tient compte que la longueur du user id relié au compte est peut être un signe d'authorization
            UserIdLenght = lengthRequirement;
        }
    }
}
