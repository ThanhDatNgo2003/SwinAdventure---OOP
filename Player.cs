using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory", "inv" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public void ItemCheck(string itemName)
        {
            if (_inventory.HasItem(itemName))
            {
                Console.WriteLine("You have the " + itemName + ".");
            }
            else if (itemName == "me")
            {
                Console.WriteLine("You are " + ShortDescription);
            }
            else
            {
                Console.WriteLine("You don't have the " + itemName + ".");
            }
        }

        public override string FullDescription
        {
            get
            {
                string result = "";

                result += "You are " + Name + ", " + Desc + ". ";
                result += "You are carrying:\n";

                result += _inventory.ItemList;

                return result;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return null;
            }
        }
        public void TakeItemFromBag(string itemName, string bagName)
        {
            Bag bag = _inventory.Fetch(bagName) as Bag;
            if (bag != null)
            {
                Item item = bag.Inventory.Take(itemName);
                if (item != null)
                {
                    Console.WriteLine("You took the " + item.Name + " from the " + bagName + ".");
                    _inventory.Put(item);
                }
                else
                {
                    Console.WriteLine("The " + bagName + " does not contain a " + itemName + ".");
                }
            }
            else
            {
                Console.WriteLine("You don't have a " + bagName + ".");
            }
        }
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public void Move(Path path)
        {
            if (path.Destination != null)
            {
                _location = path.Destination;
            }
        }
        public GameObject TakeCommand(string id)
        {
            return Inventory.Take(id);
        }
    }
}
