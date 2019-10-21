using PlanC.DataAccessModel.Records;
using PlanC.DataAccessModel.Tables;

namespace PlanC.DataAccessModel
{
    public interface IDataContext
    {
        ITable<SkillRecord> Skills { get; }

        ITable<SkillElementRecord> SkillElements { get; }

        ITable<CourseTemplateRecord> CourseTemplates { get; }
    }
}