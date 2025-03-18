using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Item : GameObject
    {
        public readonly object FullDesciption;

        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
        }
    }
}
