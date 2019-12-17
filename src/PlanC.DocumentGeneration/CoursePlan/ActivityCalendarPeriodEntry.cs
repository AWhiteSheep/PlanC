using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlanC.DocumentGeneration.CoursePlan
{
    public class ActivityCalendarPeriodEntry
    {
        private Collection<string>? _skillElements;

        //L'identitifant textuel de la période, en semaine.
        //P. ex. "1 à 3"
        //TODO Structurer étiquette de période
        public string? PeriodLabel { get; set; }

        //Tableau de chaînes; Chaque item est un paragraphe.
        //TODO Chaîne multi-paragraphe formattée
        public string[]? Content { get; set; }

        //Les idendifiants des éléments de compétence vus durant cette période.
        public Collection<string> SkillElements
        {
            get => _skillElements ?? (_skillElements = new Collection<string>());
            set => _skillElements = value;
        }
    }
}
