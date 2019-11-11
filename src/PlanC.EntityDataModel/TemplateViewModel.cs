using PlanC.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanC.EntityDataModel
{
    public class TemplateViewModel
    {
        public TemplateViewModel(CourseTemplate template)
        {
            Template = template;

            List<string> skillKeys = template.Tcrssklelem.Select(elem => elem.SkillId).Distinct().ToList();

            foreach (string skillKey in skillKeys)
            {
                List<Course_SkillElement> course_SkillElements = template.Tcrssklelem.Where(elem => elem.SkillId == skillKey).ToList();

                SkillViews.Add(new SkillViewModel(course_SkillElements));
            }

            foreach (FinalCertificativeExam final in template.Tfnlexam)
            {
                finalExams.Add(new FinalExamViewModel(final.Exam));
            }
        }

        CourseTemplate Template;

        List<SkillViewModel> SkillViews = new List<SkillViewModel>();

        List<FinalExamViewModel> finalExams = new List<FinalExamViewModel>();

        private class SkillViewModel
        {
            public SkillViewModel(List<Course_SkillElement> elements)
            {
                Skill = elements.First().SkillElement.Skl;

                this.elements = elements;
            }

            Skill Skill;

            List<Course_SkillElement> elements;
        }

        //TODO implement exam naming
        private class FinalExamViewModel
        {
            public FinalExamViewModel(ExamInfo exam)
            {
                ExamTitle = exam.ExamId.ToString();
                ExamWeight = exam.Weight.GetValueOrDefault();

                foreach (Exam_SkillElement exam_SkillElement in exam.Exam_SkillElements)
                {
                    SkillElementWeights.Add(new SkillElementWeightViewModel(exam_SkillElement));
                }
            }

            public string ExamTitle { get; private set; }
            public decimal ExamWeight { get; private set; }

            List<SkillElementWeightViewModel> SkillElementWeights = new List<SkillElementWeightViewModel>();

            private class SkillElementWeightViewModel
            {
                public SkillElementWeightViewModel(Exam_SkillElement exam_SkillElement)
                {
                    skillElemDescription = exam_SkillElement.SkillElement.Title;
                    skillElemWeight = exam_SkillElement.SkillElementWeight.GetValueOrDefault();
                }

                public string skillElemDescription;
                public decimal skillElemWeight;
            }
        }
    }
}
