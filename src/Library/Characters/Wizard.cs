using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    /*
    •La clase Wizard cumple con el patron Expert ya que:
    - Es la clase experta en conocer el daño total de un Mago y con ello tiene la responsabilidad de ejecutar un ataque
     
    •La clase Wizard no cumple con el principio SRP ya que tiene más de una razón de cambio, las cuales por ejemplo, pueden ser:
    - Cambiar el comportamiento del ataque
    - Cambiar el comportamiento de la cura
    - Cambiar el cómo se calcula el daño total de un Wizard
    - Cambiar el modo en que se recibe un ataque

    •Como es un personaje de tipo IMagicCharacter, puedo usar cualquier
     item subtipo de IItem por el principio de sustitucion. */

    public class Wizard : IMagicCharacter
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
                Console.WriteLine($"{this.Name} ⚔ ataca a {character.Name}");
                character.RecieveAttack(this.TotalDamage());

                if(character.Health <= 0)
                {
                    Console.WriteLine($" {character.Name} fue asesinado 💔");
                }
                else
                {
                    Console.WriteLine($"{character.Name} tiene {character.Health} de vida ❤");
                }
            }
            else
                {
                    Console.WriteLine($"No se puede atacar a {character.Name} ya que se encuentra muerto 💔");
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
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida ❤");
        }

        public void Heal()
        {   
            if(this.Health > 0)
            {
                this.Health = this.initialHealth;
            }
            else
                Console.WriteLine($"{this.Name} esta muerto/a. No se puede curar 💔");
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
                    Console.WriteLine($"El item {item.Name} no se puede remover ya que no se encuentra añadido al personaje.");
                } 
        }

        public void LearnSpell(Spell spell)
        {
            this.SpellBook.AddSpell(spell);
            Console.WriteLine($"{this.Name} ha aprendido el hechizo {spell.Name}");
        }

    }
}