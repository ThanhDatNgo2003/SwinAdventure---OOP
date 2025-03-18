using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _start;
        private Location _destination;

        public Path(string[] idents, string name, string desc, Location start, Location destination) : base(idents, name, desc)
        {
            _start = start;
            _destination = destination;
        }

        public Location Start
        { get { return _start; } }

        public Location Destination
        { get { return _destination; } }

        public override string ShortDescription
        {
            get { return Name; }
        }

    }
}
