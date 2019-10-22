using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanC.Models.Assets
{


    public class BaseMenuItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }
        public DropDownMenuItem parent { get; set; }

        public string Class = "nav-link text-dark";

        public BaseMenuItem() { }

        public BaseMenuItem(string title, string url, bool openInNewWindow = false)
        {
            Title = title;
            Url = url;
            OpenInNewWindow = openInNewWindow;
        }

        public BaseMenuItem(string display, string redirect, DropDownMenuItem dropDownItem)
            : this(display, redirect)
        {
            parent = dropDownItem;
        }
    }

    public class MenuSource
    {
        // le navbar
        MenuItemDataTemplate _navbar { get; }

        /// <summary>
        /// Revoit le navbar en prennant en paramètre le json
        /// </summary>
        public MenuSource()
        {
            // construit la navigation à partir du fichier json
            _navbar = JsonConvert.DeserializeObject<MenuItemDataTemplate>(
                File.ReadAllText(
                    "menu.json",
                    Encoding.UTF7
                ));
        }

        class NavbarBuilder
        {
            public IList<BaseMenuItem> Items { get; }

            public NavbarBuilder() { }

            [JsonConstructor]
            public NavbarBuilder(IList<DropDownMenuItem> itemsList)
            {
                Items = new List<BaseMenuItem>();

                foreach (DropDownMenuItem item in itemsList)
                {
                    if (item.Items != null)
                    {
                        foreach (BaseMenuItem link in item.Items)
                        {
                            link.parent = item;
                        }

                        Items.Add(item);
                    }
                    else
                    {
                        Items.Add(new BaseMenuItem(item.Title, item.Url));
                    }
                }
            }
        }
    }
}
