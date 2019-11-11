using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PlanC.WebApi.Models;
using PlanC.WebApi.Server.DataAccess;

namespace PlanC.Web.Client.Pages.Departement
{
    public class IndexDepartmentBase : ComponentBase
    {
        protected List<Department> departments;
    }
}
