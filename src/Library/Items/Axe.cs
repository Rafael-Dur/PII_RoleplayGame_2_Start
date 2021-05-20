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

        public int Damage
        {
            get
            {
                return this.damage;
            }
        }

        private int protection;

        public int Protection
        {
            get
            {
                return this.protection;
            }
        }

        private string description;

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        private bool magicItem;

        public bool MagicItem
        {
            get
            {
                return this.magicItem;
            }
        }


        public Axe(string name, int damage, int protection, string description)
        {
            this.name = name;
            this.damage = damage;
            this.protection = protection;
            this.description = description;
            this.magicItem = false;
        }
    }
}