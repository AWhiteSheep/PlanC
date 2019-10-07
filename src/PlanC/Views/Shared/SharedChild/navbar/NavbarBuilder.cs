using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Views.Shared.SharedChild.navbar
{
    public class NavbarBuilder
    {
        public List<LinkItem> ItemsList { get; set; }

        public NavbarBuilder()
        {
        }

        [JsonConstructor]
        public NavbarBuilder(List<DropDownItem> itemsList)
        {
            ItemsList = new List<LinkItem>();

            foreach (DropDownItem item in itemsList)
            {
                if (item.Items != null)
                {
                    foreach (LinkItem link in item.Items)
                    {
                        link.parent = item;
                    }

                    ItemsList.Add(item);
                }
                else
                {
                    ItemsList.Add(new LinkItem(item.Text, item.Url));
                }
            }
        }

        public List<LinkItem> LinkItems
        {
            get
            {
                // retourne la liste d'item dans lesquelles nous
                // retrouver les liens
                return ItemsList;
            }
            set
            {
                ItemsList = value;
            }
        }


    }
}
