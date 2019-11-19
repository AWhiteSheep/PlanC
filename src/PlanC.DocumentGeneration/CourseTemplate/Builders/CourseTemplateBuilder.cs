using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PlanC.DocumentGeneration.CourseTemplate.Builders
{
    public class CourseTemplateBuilder
    {
        private CourseTemplate _courseTemplate = new CourseTemplate();

        public CourseTemplateBuilder SetCourseTitle(string courseTitle)
        {
            _courseTemplate.CourseTitle = courseTitle;
            return this;
        }

        public SkillBuilder AddSkill()
        {
            var newSkill = new Skill();
            _courseTemplate.Skills.Add(newSkill);
            return new SkillBuilder(newSkill, this);
        }
    }
}
