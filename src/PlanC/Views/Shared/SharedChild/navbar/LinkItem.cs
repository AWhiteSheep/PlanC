using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Views.Shared.SharedChild.navbar
{
    public class LinkItem : Item
    {
        public DropDownItem parent { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }

        public LinkItem()
        {
        }

        public LinkItem(string display, string redirect)
        {
            Text = display;
            Url = redirect;
        }

        public LinkItem(string display, string redirect, DropDownItem dropDownItem)
        {
            Text = display;
            Url = redirect;
            parent = dropDownItem;
        }

        public string Display()
        {
            return Text;
        }

        public string RedirectTo()
        {
            return Url;
        }
    }
}
