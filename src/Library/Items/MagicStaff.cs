using System;

namespace RoleplayGame
{
    public class MagicStaff : IItem
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
                return this.protection = 0;
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
        private bool magicItem;
        public bool MagicItem 
        {   
            get
            {
                return this.magicItem = true;
            }
        }

        public MagicStaff(string name, int damage, string description)
        {
            this.name = name;
            this.damage = damage;
            this.Description = description;
        }
    }
}