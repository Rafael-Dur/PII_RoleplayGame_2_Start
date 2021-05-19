using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class SpellBook : IItem
    {
        private string name;
        public string Name
        {
            get{return this.name;}
        }
        private int damage;
        public int Damage
        {
            get{return this.damage;}
        }
        private int protection;
        public int Protection
        {
            get{return this.protection;}
        }
        private string description;
        public string Description
        {
            get{return this.description;}
            set{this.description = value;}
        }

        private bool magicItem;
        public bool MagicItem
        {
            get{return this.magicItem = true;}
        }
        public List<Spell> spells;

        public SpellBook(string name, string description)
        {
            this.name = name;            
            this.Description = description;
            this.spells = new List<Spell>();
        }

        public void AddSpell(Spell spell)
        {
            this.spells.Add(spell);
            UpdateBookSpellDamage();
            UpdateBookSpellProtection();
            
        }

        private void UpdateBookSpellDamage()
        {
            int totalDamage = 0;
            foreach(Spell spell in spells)
            {
                totalDamage += spell.Damage;
            }

            this.damage = totalDamage;
        }

        private void UpdateBookSpellProtection()
        {
            int totalProtection = 0;
            foreach(Spell spell in spells)
            {
                totalProtection += spell.Protection;
            }

            this.protection = totalProtection;
        }
        

    }
}