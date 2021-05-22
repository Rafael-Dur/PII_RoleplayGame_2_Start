using System;
using System.Collections;
using System.Collections.Generic;

namespace RoleplayGame
{

    public class Shield : IProtectionItem
    {
        public string Name{get; private set;}

        public int Protection{get; private set;}

        public string Description{get; private set;}

        public Shield(string name, int protection, string description)
        {
            this.Name = name;
            this.Protection = protection;
            this.Description = description;
        }
    }
}