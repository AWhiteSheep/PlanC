using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Views.Shared.SharedChild.navbar
{
    public interface Item
    {
        string Display();
        string RedirectTo();
    }
}
