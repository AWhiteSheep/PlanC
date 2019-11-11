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
            CourseId = template.Id;
            TheoryHours = template.TheoryHours.GetValueOrDefault();
            PracticeHours = template.PracticeHours.GetValueOrDefault();
            HomeHours = template.HomeHours.GetValueOrDefault();
            Title = template.Title;
            EducationalIntent = template.EducationalIntent;
            PedagogicalIntent = template.PedagogicalIntent;
            DepartmentApprovalDate = template.DepartmentApprovalDate.GetValueOrDefault();
            CommitteeApprovalDate = template.CommitteeApprovalDate.GetValueOrDefault();
            BoardApprovalDate = template.DepartmentApprovalDate.GetValueOrDefault();


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

        public TemplateViewModel()
        {

        }

        public string CourseId { get; set; }
        public int TheoryHours { get; set; }
        public int PracticeHours { get; set; }
        public int HomeHours { get; set; }
        public string Title { get; set; }

        public string EducationalIntent { get; set; }
        public string PedagogicalIntent { get; set; }
        public DateTime DepartmentApprovalDate { get; set; }
        public DateTime CommitteeApprovalDate { get; set; }
        public DateTime BoardApprovalDate { get; set; }

        

        public List<SkillViewModel> SkillViews = new List<SkillViewModel>();

        public List<FinalExamViewModel> finalExams = new List<FinalExamViewModel>();

        public class SkillViewModel
        {
            public SkillViewModel()
            {

            }
            public SkillViewModel(List<Course_SkillElement> elements)
            {
                var Skill = elements.First().SkillElement.Skl;
                SkillTitle = Skill.Title;
                SkillId = Skill.Id;

                foreach (Course_SkillElement elem in elements)
                {
                    Elements.Add(new SkillElementViewModel(elem));
                }
            }

            public string SkillId { get; set; }
            public string SkillTitle { get; set; }

            
            public List<SkillElementViewModel> Elements = new List<SkillElementViewModel>();

            public class SkillElementViewModel
            {
                public SkillElementViewModel(Course_SkillElement course_SkillElement)
                {
                    SkillElement skillElement = course_SkillElement.SkillElement;
                    List <SkillElementPerformanceCriteria> skillElementPerformanceCriterias = skillElement.Tsklelemcrt.ToList();

                    SkillElementTitle = skillElement.Title;

                    foreach (SkillElementPerformanceCriteria crit in skillElementPerformanceCriterias)
                    {
                        PerformanceCriteria.Add(crit.SklElemCrtTitle);
                    }

                    ContentDetails = course_SkillElement.ContentDetails;

                    IsPartial = course_SkillElement.IsPartial == "1";
                }

                public SkillElementViewModel()
                {

                }

                public string SkillElementTitle { get; set; }
                public List<string> PerformanceCriteria { get; set; }
                public string ContentDetails { get; set; }

                public bool IsPartial { get; set;  }
            }
        }

        //TODO implement exam naming
        public class FinalExamViewModel
        {
            public FinalExamViewModel()
            {

            }

            public FinalExamViewModel(ExamInfo exam)
            {
                ExamTitle = exam.ExamId.ToString();
                ExamWeight = exam.Weight.GetValueOrDefault();

                foreach (Exam_SkillElement exam_SkillElement in exam.Exam_SkillElements)
                {
                    SkillElementWeights.Add(new SkillElementWeightViewModel(exam_SkillElement));
                }
            }

            public string ExamTitle { get; set; }
            public decimal ExamWeight { get; set; }

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
