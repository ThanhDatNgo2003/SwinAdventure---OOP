using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go"}) {}

        public override string Execute(Player p, string[] text)
        {
            string error = "Error in move input.";
            string Direction;

            switch (text.Length)
            {
                case 1:
                    return "Where do you want to move?";

                case 2:
                    Direction = text[1].ToLower();
                    break;

                case 3:
                    Direction = text[2].ToLower();
                    break;

                default:
                    return error;
            }

            GameObject _path = p.Location.Locate(Direction);
            if (_path != null)
            {
                if (_path.GetType() != typeof(Path))
                {
                    return "Could not find the " + _path.Name;
                }
                p.Move((Path)_path);
                return "You have moved " + _path.FirstID + " through a " + _path.Name + " to the " + p.Location.Name + ".\r\n\n" + p.Location.FullDescription;
            }
            else
            {
                return error;
            }
        }
    }
}
