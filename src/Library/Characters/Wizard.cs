using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Wizard : ICharacter
    {
        public string name;
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
       
        private int initialHealth; 
        public int InitialHealth
        {
            get{return this.initialHealth = 100;}
        }
        
        private int health;
        public int Health
        {
            get{return this.health;}
        }

        private string role;
        public string Role
        {
            get{return this.role;}
        }

        
        
        private SpellBook spellBook;
        public SpellBook SpellBook
        {
            get{return this.spellBook;}
            set{this.spellBook = value;}
        }

       private List<IItem> inventary;
        public List<IItem> Inventary{get;}

        public Wizard(string name, string role, SpellBook spellBook)
        {
            this.name = name;
            this.health = initialHealth;
            this.role = role;
            this.inventary = new List<IItem>();
            this.SpellBook = spellBook;
        }

        public void Attack(ICharacter character)
        {
            if(character.Health > 0)
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
            else
                {
                    Console.WriteLine($"No se puede atacar a {character.Name} ya que se encuentra muerto");
                }
        }

        public void RecieveAttack(int damage)
        {
            if(damage <= (this.health + this.TotalProtection()))
            {
                this.health -= (damage - this.TotalProtection());
            }
            else
            {
                this.health = 0;
            }  
        }

        public void HealCharacter(ICharacter character) //HEAL() TIENE QUE ESTAR CREADO EN EL CHARACTER QUE RECIBE
        {
            character.Heal();
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida.");
        }

        public void Heal()
        {   
            if(this.health > 0)
            {
                this.health = initialHealth;
            }
            else
                Console.WriteLine($"El {this.name} esta muerto. No se puede curar.");
        }

        public void Respawn()
        {
            if(this.health <= 0)
            {
                this.health = initialHealth;
            }
        }

        public int TotalDamage()
        {
            int totalDamage = 0;
            foreach(IItem item in inventary)
            {
                totalDamage += item.Damage;
            }
            return totalDamage + this.SpellBook.Damage;
        }

        public int TotalProtection()
        {
            int totalProtection = 0;
            foreach(IItem item in inventary)
            {
                totalProtection += item.Protection;
            }
            return totalProtection + this.SpellBook.Protection;
        } 

        public void Equip(IItem item)
        {
            if(item.MagicItem && item != typeof(SpellBook))
            {
                this.inventary.Add(item);
            }
        }

        public void LearnSpell(Spell spell)
        {
            this.SpellBook.AddSpell(spell);
            Console.WriteLine($"{this.Name} ha aprendido el hechizo {spell.Name}");
        }

    }
}