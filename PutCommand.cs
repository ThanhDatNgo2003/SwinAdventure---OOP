using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" })
        {
        }

        private bool ContainsString(string searched, string[] value)
        {
            foreach (string s in value)
            {
                if (searched.Contains(s))
                {
                    return true;
                }
            }
            return false;
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private String PutItemTo(Player p, string thingId, IHaveInventory container)
        {
            if (p.Inventory.HasItem(thingId))
            {
                GameObject item = p.Inventory.Take(thingId);
                if (container is Item && container.GetType() != typeof(Bag))
                {
                    return $"{container.Name} is not a container.\n";
                }
                else if (container == null)
                {
                    container = p.Location;
                }
                container.Inventory.Put((Item)item);
                return $"You have put {thingId} into {container.Name}\n";
            }
            else
            {
                return $"You do not have {thingId} in your inventory.\n";
            }
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container = null;
            string _itemid;
            string _error = "Error in put input.";

            switch (text.Length)
            {
                case 1:
                    return "What do you want to put?";

                case 2:
                    if (ContainsString(text[1].ToLower(), new string[] { "north", "south", "east", "west", "up", "down" }))
                    {
                        return "Cannot " + text[0] + " direction!";
                    }
                    else
                    {
                        _itemid = text[1];
                        _container = p.Location;
                    }
                    break;

                case 3:
                        return "Where do you want to put at?";

                case 4:
                    _itemid = text[1];
                    _container = FetchContainer(p, text[3]);
                    break;

                default:
                    _container = null;
                    return _error;
            }
            return PutItemTo(p, _itemid, _container);
        }
    }
}
