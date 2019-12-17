using PlanC.DocumentGeneration.CoursePlan;
using PlanC.DocumentGeneration.CourseTemplate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PlanC.EntityDataModel
{
    static class PlanCStaticModelMethods
    {

        public static CourseTemplate ToDocumentModel(this PlansCadres template)
        {
            return new CourseTemplate();
        }

        public static CoursePlan ToDocumentModel(this PlansCours plan, PlansCadres template)
        {
            CourseTemplate ParentTemplateDocumentModel = template.ToDocumentModel();

            CoursePlan model = new CoursePlan();

            model.CourseId = plan.CoursId;
            model.Campus = "Gabrielle-Roy";
            model.Exams.Add(ParentTemplateDocumentModel.FinalExam);
            foreach(Examens exam in plan.ExamensCertificatifsNonsFinals.Select(ex => ex.Examen))
            {
                model.Exams.Add(new DocumentGeneration.Common.Exam()
                {
                    Title = exam.Qualification,
                    Weight = exam.PoidExamen
                });
            }
            model.Introduction = ParentTemplateDocumentModel.CourseDescription.Split(Environment.NewLine);

            plan.CoursActivite.OrderBy(act => act.ActvtSqnbr);
            foreach(CoursActivite act in plan.CoursActivite)
            {
                int CurrentWeek = 1;
                model.ActivityPeriodEntries.Add(new ActivityCalendarPeriodEntry()
                {
                    Content = act.ActvtDesc.Split(Environment.NewLine),
                    PeriodLabel = $"Semaine {CurrentWeek} - Semaine {CurrentWeek + act.ActvtLgnth -1}",
                    SkillElements = new Collection<string>(act.CoursCompetenceElements.Select(ase => ase.IdentityCritereElementCompetenceNavigation.DescriptionCritere).ToList())
                }) ;
                CurrentWeek += act.ActvtLgnth.GetValueOrDefault();
            }

            model.PedagogicalIntents = ParentTemplateDocumentModel.PedagogicalIntent.Split(Environment.NewLine);

            model.Prerequisites = ParentTemplateDocumentModel.Prerequisites;

            foreach(MaterielsCours mat in plan.MaterielsCours)
            {
                model.RequiredMaterial.Add($"{mat.Description}");
            }

            model.Session = plan.Session.Titre;
            model.Skills = ParentTemplateDocumentModel.Skills;

            model.Teacher = new Teacher()
            {
                Name = plan.TchrUid
            };

            model.TimeDistribution = ParentTemplateDocumentModel.TimeDistribution;

            return model;
        }
    }
}
