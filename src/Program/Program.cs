using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Shield shield1 = new Shield ("Golden Shield", 75,"Escudo Protector");
            Sword sword1 = new Sword ("Katana", 125,"Corte Fugaz");

            Orc orc = new Orc ("Grom", 25, "Tanque");
            orc.Equip(sword1);
            orc.Equip(shield1);


            Axe axe1 = new Axe("Verdugo", 70, "Juicio final");
            Warhammer warhammer1 = new Warhammer("Mjölnir", 90, "Aplastar y machacar");

            Dwarf dwarf = new Dwarf("Thorin", 35, "Luchador");
            dwarf.Equip(axe1);
            dwarf.Equip(warhammer1);

            Bow bow1 = new Bow ("Arco gigante", 75,"Tira fuego");
            Cloak cloak1 = new Cloak ("Capa maxima", 85, "Invisibilidad");
            
            Elf elf = new Elf ("Frank",15, "Escurridizo");
            elf.Equip(bow1);
            elf.Equip(cloak1); 

            SpellBook spellBook1 = new SpellBook("Libro de Hechizos Oscuros","Hechizos oscuros");  
            Spell spell1 = new Spell("Lumos", "La varita enciende luz", 65, 0);
            spellBook1.AddSpell(spell1);

            MagicStaff magicStaff1 = new MagicStaff("Baculo Oscuro",150, "Baculo perdido de Toran");

            Wizard wizard = new Wizard("Harry", "Mago De Apoyo", spellBook1);
            wizard.Equip(magicStaff1);
            wizard.LearnSpell(spell1);
        }
    }
}
