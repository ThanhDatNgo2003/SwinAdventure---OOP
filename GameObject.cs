﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Desc
        {
            get { return _description; }
        }

        public virtual string ShortDescription
        {
            get { return $"{_name} ({FirstID})"; }
        }

        public virtual string FullDescription
        {
            get { return _description; }
        }
    }
}
