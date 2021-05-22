using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Wizard : ICharacter
    {
        public string Name{get; private set;}
        public int Damage{get; private set;}
        public int Health{get; private set;}
        public string Role{get; private set;}
        
        private int initialHealth;

        public List<IItem> Inventary{get; private set;}

        public SpellBook SpellBook {get; private set;}


        public Wizard(string name, string role, SpellBook spellBook)
        {
            this.Name = name;
            this.initialHealth = 100;
            this.Health = initialHealth;
            this.Role = role;
            this.Inventary = new List<IItem>();
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
            if(damage <= (this.Health + this.TotalProtection()))
            {
                this.Health -= (damage - this.TotalProtection());
            }
            else
            {
                this.Health = 0;
            }  
        }

        public void HealCharacter(ICharacter character)
        {
            character.Heal();
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida.");
        }

        public void Heal()
        {   
            if(this.Health > 0)
            {
                this.Health = this.initialHealth;
            }
            else
                Console.WriteLine($"El {this.Name} esta muerto. No se puede curar.");
        }

        public void Respawn()
        {
            if(this.Health <= 0)
            {
                this.Health = this.initialHealth;
            }
        }

        public int TotalDamage()
        {
            int totalDamage = 0;
            foreach(IItem item in this.Inventary)
            {
                if(typeof(IAttackItem).IsInstanceOfType(item))
                {
                    totalDamage += ((IAttackItem)item).Damage;
                }
                else if(typeof(IMagicAttackItem).IsInstanceOfType(item))
                {
                    totalDamage += ((IMagicAttackItem)item).Damage;
                }
            }
            return totalDamage + this.SpellBook.Damage + this.Damage;
        }

        public int TotalProtection()
        {
            int totalProtection = 0;
            foreach(IItem item in this.Inventary)
            {
                if(typeof(IProtectionItem).IsInstanceOfType(item))
                {
                    totalProtection += ((IProtectionItem)item).Protection;
                }
                else if(typeof(IMagicProtectionItem).IsInstanceOfType(item))
                {
                    totalProtection += ((IMagicProtectionItem)item).Protection;
                }
            }
            return totalProtection + this.SpellBook.Protection;
        } 

        public void Equip(IItem item)
        {   
            this.Inventary.Add((IItem)item);  
        }

        public void UnEquip(IItem item)
        {   
            if(this.Inventary.Contains(item))
            {
                this.Inventary.Remove(item);
                Console.WriteLine($"Se ha removido el item {item.Name} del personaje {this.Name}.");
            }
            else
                {
                    Console.WriteLine($"El {item.Name} no se puede removew ya que no se encuentra añadido al personaje.");
                } 
        }

        public void LearnSpell(Spell spell)
        {
            this.SpellBook.AddSpell(spell);
            Console.WriteLine($"{this.Name} ha aprendido el hechizo {spell.Name}");
        }

    }
}