using System;

namespace RoleplayGame
{

    /*La clase Spell cumple con el patron Expert, ya que es la clase experta en conocer 
    el nombre y el poder de cada hechizo para poder cumplir con la responsabilidad de 
    construir un hechizo nuevo.
    
    Cumple con el principio SRP ya que no hay más de una razón de cambio. */

    public class Spell 
    {
        public string Name{get; private set;}

        public int Damage{get; private set;}

        public int Protection{get; private set;}

        public string Description{get; private set;}

        public Spell(string name, string description, int damage, int protection)
        {
            this.Name = name;
            this.Description = description;
            this.Damage = damage;
            this.Protection = protection;
        }
    }

}