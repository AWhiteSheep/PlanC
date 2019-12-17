using Microsoft.AspNetCore.Components;
using PlanC.EntityDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Client.Components.PlanCours
{
    public abstract class CoursePlanInputFormComponent : ComponentBase
    {
        [Bindable(true)]
        [Parameter]
        public PlansCours CoursePlan { get; set; }

        [Parameter]
        public EventCallback<PlansCours> CoursePlanChanged { get; set; }

        public abstract Task<bool> SaveProgress();
    }
}
