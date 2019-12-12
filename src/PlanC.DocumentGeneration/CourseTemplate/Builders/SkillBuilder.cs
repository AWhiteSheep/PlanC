using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PlanC.DocumentGeneration.CourseTemplate.Builders
{
    public class SkillBuilder
    {
        private Skill _skill;
        private CourseTemplateBuilder _parent;

        internal SkillBuilder(Skill skill, CourseTemplateBuilder parent)
        {
            Debug.Assert(skill != null && parent != null);
            _skill = skill;
            _parent = parent;
        }

        public SkillBuilder SetTitle(string title)
        {
            _skill.Title = title;
            return this;
        }

        public SkillElementBuilder AddElement()
        {
            var newElement = new SkillElement();
            _skill.SkillElements.Add(newElement);
            return new SkillElementBuilder(newElement, this);
        }

        public CourseTemplateBuilder Finish()
        {
            return _parent;
        }
    }
}
