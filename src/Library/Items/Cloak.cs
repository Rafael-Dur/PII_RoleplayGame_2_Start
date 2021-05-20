using System;
using System.Collections;
using System.Collections.Generic;

namespace RoleplayGame
{

    public class Cloak : IItem
    {
        private string name;
        public string Name 
        {
            get
            {
                return this.name;
            }
        }

        private int damage;

        public int Damage{get;}

        private int protection;

        public int Protection{get;}

        private string description;

        public string Description {get; }

        private bool magicItem;

        public bool MagicItem {get;}


        public Cloak(string name, int damage, int protection, string description)
        {
            this.name = name;
            this.damage = damage;
            this.protection = protection;
            this.Description = description;
            this.MagicItem = true;
        }
    }
}