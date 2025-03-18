using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item item = Fetch(id);

            if (item != null)
            {
                _items.Remove(item);
            }

            return item;
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }

            return null;
        }

        public bool HasItem(string id)
        {
            return Fetch(id) != null;
        }

        public string ItemList
        {
            get
            {
                string result = "";

                foreach (Item itm in _items)
                {
                    result += itm.ShortDescription + "\n";
                }

                return result;
            }
        }
    }
}
