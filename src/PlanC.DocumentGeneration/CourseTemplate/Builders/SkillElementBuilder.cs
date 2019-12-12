using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PlanC.DocumentGeneration.CourseTemplate.Builders
{
    public class SkillElementBuilder
    {
        private SkillElement _skillElement;
        private SkillBuilder _parent;

        internal SkillElementBuilder(SkillElement skillElement, SkillBuilder parent)
        {
            Debug.Assert(skillElement != null && parent != null);
            _skillElement = skillElement;
            _parent = parent;
        }

        public SkillElementBuilder SetTitle(string title)
        {
            _skillElement.Title = title;
            return this;
        }

        public SkillBuilder Finish()
        {
            return _parent;
        }
    }
}
