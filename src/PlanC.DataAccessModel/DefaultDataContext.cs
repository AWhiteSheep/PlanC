using PlanC.DataAccessModel.Records;
using PlanC.DataAccessModel.Tables;
using PlanC.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.DataAccessModel
{
    public class DefaultDataContext : IDataContext
    {
        public DefaultDataContext()
        {
            var efContext = new PCU001Context();
            Skills = new DefaultTable<SkillRecord>(efContext.Skills);
            SkillElements = new DefaultTable<SkillElementRecord>(efContext.SkillElements);
            CourseTemplates = new DefaultTable<CourseTemplateRecord>(efContext.CourseTemplates);
        }

        public ITable<SkillRecord> Skills { get; }

        public ITable<SkillElementRecord> SkillElements { get; }

        public ITable<CourseTemplateRecord> CourseTemplates { get; }
    }
}
