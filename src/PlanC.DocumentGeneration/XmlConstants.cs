using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.DocumentGeneration
{
    internal static class XmlConstants
    {
        public const string DocumentRootNamespace = "http://nemesis.cicco.org/schemas/v1.0";

        public const string CommonNamespace = DocumentRootNamespace + "/common";

        public const string CourseTemplateNamespace = DocumentRootNamespace + "/course-template";

        public const string CoursePlanNamespace = DocumentRootNamespace + "/course-plan";
    }
}
