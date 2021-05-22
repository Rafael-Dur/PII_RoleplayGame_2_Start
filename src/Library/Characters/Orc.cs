/* using System;
using System.Collections;
using System.Collections.Generic;

namespace RoleplayGame
{
    
    public class Orc : ICharacter
    {
        public string Name{get; private set;}
        public int Damage{get; private set;}
        public int Health{get; private set;}
        public string Role{get; private set;}
        
        private int initialHealth;

        public List<IItem> Inventary{get; private set;}


        public Orc(string name, int damage, string role)
        {
            this.Name = name;
            this.Damage = damage;
            this.initialHealth = 200;
            this.Health = initialHealth;
            this.Role = role;
            this.Inventary = new List<IItem>();
        }        
        
        //Este metodo ataca a un personaje:
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
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida.");
        }

        public void Heal()
        {   
            if(this.Health > 0)
            {
                this.Health = this.initialHealth;
            }
            else
                {
                    Console.WriteLine($"El {this.Name} esta muerto. No se puede curar.");
                }
        }

        public void Respawn()
        {
            if(this.Health <= 0)
            {
                this.Health = this.initialHealth;
            }
            else 
            {
                this.Health += 0;
            }
        }

        public void Equip(IItem item)
        {   
            if(item.MagicItem == false)
            {
                this.Inventary.Add(item);
            }
            else
                {
                    Console.WriteLine($"El {item.Name} no se puede agregar ya que no se puede equipar un item magico.");
                } 
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

        public int TotalDamage()
        {
            int totalDamage = 0;
            foreach(IItem item in this.Inventary)
            {
                totalDamage += item.Damage;
            }
            totalDamage += this.Damage;

            return totalDamage;
        }

        public int TotalProtection()
        {
            int totalProtection = 0;
            foreach(IItem item in this.Inventary)
            {
                totalProtection += item.Protection;
            }

            return totalProtection;
        }
    }
    
}

 */