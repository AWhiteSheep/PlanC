using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Models.Assets
{
    public class MenuItemDataTemplate
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public IList<MenuItemDataTemplate> Children { get; set; } = new List<MenuItemDataTemplate>();
        public string Class { get; set; } = "nav-link text-dark";
    }
}
