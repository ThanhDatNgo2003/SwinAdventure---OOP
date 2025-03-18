using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }
        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container;
            string thingId;

            if (text[0].ToLower() != "look")
                return "Error in look input.";

            switch (text.Length)
            {
                case 1:
                    if (p.Location != null)
                    {
                        return p.Location.FullDescription;
                    }
                    return p.FullDescription;

                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want to look at?";
                    _container = p;
                    thingId = text[2];
                    break;

                case 5:
                    _container = FetchContainer(p, text[4]);
                    if (_container == null)
                        return "Could not find " + text[4];
                    thingId = text[2];
                    break;

                default:
                    return "Error in look input.";
            }
            return LookAtIn(thingId, _container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
                return container.Locate(thingId).FullDescription;

            return "Couldn't find " + thingId;
        }
    }
}
