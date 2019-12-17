using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.DocumentGeneration.CoursePlan
{
    [Serializable]
    public class Teacher
    {
        public string? Name { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Office { get; set; }

        //Chaque chaîne est dans le format d'affichage
        //P. ex. "Mercredi 9h-10h"
        //TODO Structurer disponibilités
        public string[]? Availabilities { get; set; }
    }
}
