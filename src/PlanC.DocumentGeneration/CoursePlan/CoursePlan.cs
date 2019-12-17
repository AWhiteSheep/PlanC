using PlanC.DocumentGeneration.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;

namespace PlanC.DocumentGeneration.CoursePlan
{
    [Serializable]
    public class CoursePlan
    {
        private Collection<Skill>? _skills;
        private Collection<Prerequisite>? _prerequisites;
        private Collection<ActivityCalendarPeriodEntry>? _activityPeriodEntries;
        private Collection<Exam>? _exams;
        private Collection<string>? _requiredMaterial;

        public string? CourseId { get; set; }

        public string? CourseTitle { get; set; }        

        public string? StudyProgram { get; set; }

        public TimeDistribution? TimeDistribution { get; set; }

        public string? Session { get; set; }

        public string? Campus { get; set; }

        public Teacher? Teacher { get; set; }

        public string? Group { get; set; }

        //Tableau de chaînes; Chaque item est un paragraphe.
        //TODO Chaîne multi-paragraphe formattée
        public string[]? Introduction { get; set; }

        //Tableau de chaînes; Chaque item est un paragraphe.
        //TODO Chaîne multi-paragraphe formattée
        public string[]? PedagogicalIntents { get; set; }

        public Collection<Skill> Skills
        {
            get => _skills ?? (_skills = new Collection<Skill>());
            set => _skills = value;
        }

        public Collection<Prerequisite> Prerequisites
        {
            get => _prerequisites ?? (_prerequisites = new Collection<Prerequisite>());
            set => _prerequisites = value;
        }

        public Collection<ActivityCalendarPeriodEntry> ActivityPeriodEntries
        {
            get => _activityPeriodEntries ?? (_activityPeriodEntries = new Collection<ActivityCalendarPeriodEntry>());
            set => _activityPeriodEntries = value;
        }

        //Remarque : on accepte plusieurs examens finaux dans la collection, mais le document n'en supporte qu'un.
        //TODO Valider unicité de l'examen final.
        [XmlArrayItem(nameof(Exam), typeof(Exam))]
        [XmlArrayItem(nameof(FinalExam), typeof(FinalExam))]
        public Collection<Exam> Exams
        {
            get => _exams ?? (_exams = new Collection<Exam>());
            set => _exams = value;
        }

        public Collection<string> RequiredMaterial
        {
            get => _requiredMaterial ?? (_requiredMaterial = new Collection<string>());
            set => _requiredMaterial = value;
        }
    }
}
