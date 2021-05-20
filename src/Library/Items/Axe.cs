using System;
using System.Collections;
using System.Collections.Generic;

namespace RoleplayGame
{

    public class Axe : IItem
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

        public string Description {get; set;}

        private bool magicItem;

        public bool MagicItem {get;}


        public Axe(string name, int damage, int protection, string description)
        {
            this.name = name;
            this.damage = damage;
            this.protection = protection;
            this.Description = description;
            this.MagicItem = false;
        }
    }
}