using System;
using System.Collections;
using System.Collections.Generic;

namespace RoleplayGame
{
    
    public class Dwarf : ICharacter
    {
        private string name;
        public string Name {get; }

        private int damage;
        public int Damage {get;}
    
        private int initialHealth;
        public int InitialHealth 
        {
            get
            {
                return this.initialHealth = 100;
            }
        }
        private int health;

        public int Health
        {
            get{return this.health;}
        }

        public string Role {get; set;}

        private List<IItem> inventary;
        public List<IItem> Inventary{get;}

    

        public Dwarf(string name, int damage, string role)
        {
            this.name = name;
            this.damage = damage;
            this.health = initialHealth;
            this.Role = role;
            this.inventary = new List<IItem>();
        }        
        
        //Este metodo ataca a un personaje:
        public void Attack(ICharacter character)
        {
            Console.WriteLine($"{this.Name} ataca a {character.Name}");
            character.RecieveAttack(this.TotalDamage());

            if(character.Health <= 0)
            {
                Console.WriteLine($"{character.Name} fue asesinado.");
            }
            else
            {
                Console.WriteLine($"{character.Name} tiene {character.Health} de vida.");
            }
        }

        public void RecieveAttack(int damage)
        {
                if(damage <= (this.health + this.TotalProtection()))
                {
                    this.health -= (damage - TotalProtection());
                }
                else
                {
                    this.health = 0;
                }
            }

        public void HealCharacter(ICharacter character)
        {
            character.Heal();
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida.");
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }

        public void Equip(IItem item)
        {
            throw new NotImplementedException();
        }

        public int TotalDamage()
        {
            int totalDamage = 0;
            foreach(IItem item in inventary)
            {
                totalDamage += item.Damage;
            }
            return totalDamage;
        }

        public int TotalProtection()
        {
            int totalProtection = 0;
            foreach(IItem item in inventary)
            {
                totalProtection += item.Protection;
            }
            return totalProtection;
        }
    }
    
}

