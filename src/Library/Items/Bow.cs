using System;
using System.Collections;
using System.Collections.Generic;

namespace RoleplayGame
{

    public class Bow : IItem
    {
        public string Name{get; private set;}

        public int Damage{get; private set;}

        public string Description{get; private set;}


        public Bow(string name, int damage, string description)
        {
            this.Name = name;
            this.Damage = damage;
            this.Description = description;
        }
    }
}