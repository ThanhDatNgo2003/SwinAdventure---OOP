using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _path;

        public Location(string name, string desc) : base(new string[] { "location", "place", "room", "around" }, name, desc)
        {
            _inventory = new Inventory();
            _path = new List<Path>();
        }



        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            foreach (Path p in _path)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }
            return _inventory.Fetch(id);
        }

        public Inventory Inventory
        {
            get => _inventory;
        }
        public string ItemListOfTheLocation
        {
            get
            {
                if (_inventory.ItemList.Length == 0)
                {
                    return "There are no item in this location";
                }

                return "In here you see: \r\n" + _inventory.ItemList;
            }
        }
        public override string FullDescription
        {
            get
            {
                string result = "You are in " + base.Name + "\r\n" + ItemListOfTheLocation;
                return result;
            }
        }

        public string PathList

        {
            get
            {
                if (_path.Count == 0)
                {
                    return "There are no paths";
                }

                if (_path.Count == 1)
                {
                    return "\r\n\nThere is an exit in the " + _path[0].FirstID + ".\r\n";
                }

                string announment = "There are exits to the ";

                if (_path.Count > 1)
                {
                    for (int i = 0; i < _path.Count; i++)
                    {
                        announment += _path[i].FirstID;
                        announment += " and ";
                    }
                }
                return announment;
            }
        }

        public void AddPath(Path path)
        {
            _path.Add(path);
        }
        public GameObject TakeCommand(string id)
        {
            return Inventory.Take(id);
        }
    }
}