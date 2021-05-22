using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Shield shield = new Shield ("Golden Shield", 75,"Escudo Protector");
            Sword sword = new Sword ("Katana", 125,"Corte Fugaz");

            Orc orc = new Orc ("Grom", 25, "Tanque");
            orc.Equip(sword);
            orc.Equip(shield);


            Axe axe = new Axe("Verdugo", 70, "Juicio final");
            Warhammer warhammer = new Warhammer("Mjölnir", 90, "Aplastar y machacar");

            Dwarf dwarf = new Dwarf("Thorin", 35, "Luchador");
            dwarf.Equip(axe);
            dwarf.Equip(warhammer);

            Bow bow = new Bow ("Arco gigante", 75,"Tira fuego");
            Cloak cloak = new Cloak ("Capa maxima", 85, "Invisibilidad");
            
            Elf elf = new Elf ("Galardiel",15, "Escurridizo");
            elf.Equip(bow);
            elf.Equip(cloak); 

            SpellBook spellBook = new SpellBook("Libro de Hechizos Oscuros","Hechizos oscuros");  
            Spell spell = new Spell("Lumos", "La varita enciende luz", 65, 0);
            MagicStaff magicStaff = new MagicStaff("Baculo Oscuro",150, "Baculo perdido de Toran");

            Wizard wizard = new Wizard("Harry", "Mago De Apoyo", spellBook);

            dwarf.Attack(orc);
            Console.WriteLine("👳 " + dwarf.Name + " cura a 🤢 " + orc.Name);
            dwarf.HealCharacter(orc);
            Console.WriteLine();

            orc.Attack(wizard);
            wizard.Respawn();
            Console.WriteLine("La vida actual de 🧙 "+ wizard.Name + " ahora es: " + wizard.Health + " ❤");
            Console.WriteLine();

            elf.UnEquip(bow);
            elf.Equip(sword);
            Console.WriteLine("El daño total que causa 🧝‍♀️ " + elf.Name + " es: " + elf.TotalDamage() + " 🗡");
            Console.WriteLine("El daño total que causa 🧝‍♀️ " + elf.Name + " es: " + elf.TotalProtection() + " 🛡");
            Console.WriteLine();

            orc.UnEquip(sword);
            orc.Equip(axe);
            Console.WriteLine("El daño total que causa 🤢 " + orc.Name + " es: " + orc.TotalDamage() + " 🗡");
            Console.WriteLine("El daño total que causa 🤢 " + orc.Name + " es: " + orc.TotalProtection() + " 🛡"); 
            Console.WriteLine();

            dwarf.UnEquip(axe);
            dwarf.Equip(shield);
            Console.WriteLine("El daño total que causa 👳 " + dwarf.Name + " es: " + dwarf.TotalDamage() + " 🗡");
            Console.WriteLine("El daño total que causa 👳 " + dwarf.Name + " es: " + dwarf.TotalProtection() + " 🛡");
            Console.WriteLine();

            wizard.Equip(magicStaff);
            wizard.Equip(spellBook);
            wizard.LearnSpell(spell);
            Console.WriteLine();

            Console.WriteLine("El daño total que causa 🧙 " + wizard.Name + " es: " + wizard.TotalDamage() + " 🗡");
            Console.WriteLine("El daño total que causa 🧙 " + wizard.Name + " es: " + wizard.TotalProtection() + " 🛡");
            Console.WriteLine();

            wizard.UnEquip(magicStaff);
            Console.WriteLine(magicStaff.Name + " fue quitado del inventario de " + wizard.Name);
            Console.WriteLine();
            wizard.Equip(sword);
            wizard.Equip(shield);
            Console.WriteLine("Se añadieron los items: " + sword.Name + " y " + shield.Name + " al inventario de " + wizard.Name);
            Console.WriteLine("El daño de " + wizard.Name + " ahora es: " +  wizard.TotalDamage() + " 🗡");
            Console.WriteLine("La protección de " + wizard.Name + " ahora es: " + wizard.TotalProtection() + " 🛡");
        }
    }
}
