using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Views.Shared.Assets.SideBar
{
    public class DropDownItem : LinkItem
    {
        public List<LinkItem> Items { get; set; }
        public new string Class = "dropdown-item";

        public DropDownItem() { }
        
        public DropDownItem(string display, string redirect, List<LinkItem> dropDownLinkItem) : base(display, redirect)
        {
            Items = new List<LinkItem>();
            foreach (LinkItem item in dropDownLinkItem)
            {
                AddItem(item);
            }
        }

        public void AddItem(LinkItem newItem)
        {
            newItem.parent = this;
            Items.Add(newItem);
        }
    }
}
