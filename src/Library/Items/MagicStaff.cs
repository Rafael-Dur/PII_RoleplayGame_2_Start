using System;

namespace RoleplayGame
{
    public class MagicStaff : IMagicAttackItem
    {
        public string Name{get; private set;}

        public int Damage{get; private set;}

        public string Description{get; private set;}

        public MagicStaff(string name, int damage, string description)
        {
            this.Name = name;
            this.Damage = damage;
            this.Description = description;
        }
    }
}