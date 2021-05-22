using System;

namespace RoleplayGame
{
    public class Spell : IItem
    {
        public string Name{get; private set;}

        public int Damage{get; private set;}

        public int Protection{get; private set;}

        public string Description{get; private set;}

        public Spell(string name, string description, int damage, int protection)
        {
            this.Name = name;
            this.Description = description;
            this.Damage = damage;
            this.Protection = protection;
        }
    }

}