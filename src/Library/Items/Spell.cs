using System;

namespace RoleplayGame
{
    public class Spell : IItem
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        private string description;
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
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
        private bool magicItem;
        public bool MagicItem
        {
            get
            {
                return this.magicItem = true;
            }
        }


        public Spell(string name, string description, int damage, int protection)
        {
            this.name = name;
            this.Description = description;
            this.damage = damage;
            this.protection = protection;
        }
    }

}