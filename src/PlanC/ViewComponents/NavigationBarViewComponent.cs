using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlanC.Models.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanC.ViewComponents
{
    public class NavigationBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(MenuItemDataTemplate item = null, bool isTopLevel = false)
        {
            if (item != null)
            {
                ViewBag.isTopLevel = isTopLevel;

                if (item.Children.Any())
                    return View("DropDownMenu", item);

                return View("DropDownMenuItem", item);
            }
            else
            {
                var menuItems = JsonConvert.DeserializeObject<List<MenuItemDataTemplate>>(
                    File.ReadAllText(
                        "menu.json",
                        Encoding.UTF7
                    ));

                return View("SideNavigation", menuItems);
            }
        }
    }
}
