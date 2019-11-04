using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Models.Assets
{
    public class DropDownMenuItem : BaseMenuItem
    {
        public IList<BaseMenuItem> Items { get; set; }
        public new string Class = "dropdown-item";

        public DropDownMenuItem() { }

        public DropDownMenuItem(string display, string redirect, IList<BaseMenuItem> dropDownLinkItem, 
            bool OpenInNewWindow = false) : base(display, redirect, OpenInNewWindow)
        {
            Items = new List<BaseMenuItem>();
            foreach (BaseMenuItem item in dropDownLinkItem)
            {
                AddItem(item);
            }
        }

        public void AddItem(BaseMenuItem newItem)
        {
            newItem.parent = this;
            Items.Add(newItem);
        }
    }
}
