using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Client.Components
{
    public class CourseTemplateFormComponent : ComponentBase
    {
        public virtual bool SaveProgress()
        {
            return true;
        }
    }
}
