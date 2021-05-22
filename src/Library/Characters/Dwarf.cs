using System;
using System.Collections;
using System.Collections.Generic;

namespace RoleplayGame
{
    /* 
    • La clase Dwarf cumple con el patron Expert ya que:
    - Es la clase experta en conocer el daño total de las instancias de la clase Dwarf
      y tambien tiene las responsabilidades de ejecutar un ataque y de recibir un ataque.
     
    • La clase Dwarf no cumple con el principio SRP ya que tiene más de una razón de cambio, 
    las cuales por ejemplo, pueden ser:
    - Cambiar el comportamiento del ataque
    - Cambiar el cómo se calcula el daño total de un enano
    - Cambiar el cómo se calcula la protección total de un enano
    - Cambiar el modo en que se recibe un ataque 
    
    • Como es un personaje de tipo INormalCharacter, puedo usar cualquier item subtipo de 
    INormalItem por el principio de sustitucion. */

    public class Dwarf : INormalCharacter 
    {
        public string Name{get; private set;}
        public int Damage{get; private set;}
        public int Health{get; private set;}
        public string Role{get; private set;}
        
        private int initialHealth;

        public List<INormalItem> Inventary{get; private set;}

        public Dwarf(string name, int damage, string role)
        {
            this.Name = name;
            this.Damage = damage;
            this.initialHealth = 100;
            this.Health = initialHealth;
            this.Role = role;
            this.Inventary = new List<INormalItem>();
        }        
        
        //Este metodo ataca a un personaje:
        public void Attack(ICharacter character)
        {
            if(character.Health > 0)
            {
                Console.WriteLine($"{this.Name} ⚔ ataca a {character.Name}");
                character.RecieveAttack(this.TotalDamage());

                if(character.Health <= 0)
                {
                    Console.WriteLine($"{character.Name} fue asesinado 💔");
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
                    this.Health -= (damage - TotalProtection());
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
                Console.WriteLine($"{this.Name} esta muerto. No se puede curar 💔");
        }

        public void Respawn()
        {
            if(this.Health <= 0)
            {
                this.Health = initialHealth;
            }
            else
            {
                this.Health = this.Health;
            }
        }

        public void Equip(INormalItem item)
        {   
            this.Inventary.Add((INormalItem)item);  
        }

        public void UnEquip(INormalItem item)
        {   
            if(Inventary.Contains(item))
            {
                this.Inventary.Remove(item);
                Console.WriteLine($"Se ha removido el item {item.Name} del personaje {this.Name}.");
            }
            else
                {
                    Console.WriteLine($"El item {item.Name} no se puede remover ya que no se encuentra añadido al personaje.");
                } 
        }

        public int TotalDamage()
        {
            int totalDamage = 0;
            foreach(INormalItem item in this.Inventary)
            {
                if(typeof(IAttackItem).IsInstanceOfType(item))
                {
                    totalDamage += ((IAttackItem)item).Damage;
                }
                
            }
            totalDamage += this.Damage;
            
            return totalDamage;
        }

        public int TotalProtection()
        {
            int totalProtection = 0;
            foreach(INormalItem item in this.Inventary)
            {
                if(typeof(IProtectionItem).IsInstanceOfType(item))
                {
                    totalProtection += ((IProtectionItem)item).Protection;
                }
            }
            return totalProtection;
        }
    }
    
}

