using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class DwarfTest
    {
        private Orc orc;
        private Sword sword;
        private Shield shield;
        private Dwarf dwarf;

        private Wizard wizard;
        private MagicStaff magicStaff;

        private SpellBook spellBook;
        private Spell spell;
        private Axe axe;
        private Warhammer warhammer;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            sword = new Sword("Espada rústica", 50, 0, "Corte Fugaz");
            shield = new Shield("Escudo desgastado", 0, 70, "Bloqueo");
            orc = new Orc("Azog", 25, "Tanque");
            
            axe = new Axe("Executioner",50,5,"Corte decisivo");
            warhammer = new Warhammer("Mjölnir", 60, 10, "Ultimatum");
            dwarf = new Dwarf("Thorin", 70, "Luchador"); 

            magicStaff = new MagicStaff("Báculo ancestral", 50, "Poder mágico");
            spellBook = new SpellBook("Occido Lumen", "Tiene hechizos poderosos");
            spell = new Spell("You shall not pass", "Genera una barrera", 0, 70);
            wizard = new Wizard("Gandalf", "Mago", spellBook);

        }

        [Test]
        public void NameAndRoleCannotBeNull()
        //Se prueba que el nombre y el rol del enano que no sea nulo
        {   
            //Assert
            Assert.IsTrue(dwarf.Name!=null && dwarf.Role!=null);
        }

        [Test]
        public void DwarfCorrectlyInstanced()
        //Se prueba que enano se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(dwarf);
        }

        [Test]
        public void EquipItemCheck()
        //Se prueba que el hacha se haya agregado al inventario del enano.
        {   //Act
            dwarf.Equip(axe);
            
            //Assert
            Assert.IsNotNull(dwarf.Inventary);
        }

        [Test]
        public void EquipTwoItemsCheck()
        //Se prueba que los dos items se agreguen correctamente al inventario del enano.
        {   
            //Act
            dwarf.Equip(axe);
            dwarf.Equip(warhammer);
            int index = dwarf.Inventary.IndexOf(warhammer);

            //Assert
            Assert.AreEqual(1,index);
        }

        [Test]
        public void RemoveItemCheck()
        //Se prueba que el item que se añada al inventario del enano sea removido correctamente.
        {   
            //Act
            dwarf.Equip(axe);
            dwarf.UnEquip(axe);
            int cantidadEsperadaItems = 0;
            //Assert
            Assert.AreEqual(cantidadEsperadaItems, dwarf.Inventary.Count);
        }

        [Test]
        public void TotalDamageCheck()
        //Se prueba que el valor total del damage del orco sea el esperado.
        {   
            //Act
            dwarf.Equip(axe);
            dwarf.Equip(warhammer);
            int expectedTotalDamage = 70 + 50 + 60;

            int calcTotalDamage = dwarf.TotalDamage();

            //Assert
            Assert.AreEqual(expectedTotalDamage, calcTotalDamage);
        }

        [Test]
        public void TotalProtectionCheck()
        //Se prueba que el valor total de la proteccion del orco sea el esperado.
        {
            //Act
            dwarf.Equip(axe);
            dwarf.Equip(warhammer);
            int expectedProtection = 15;

            int calcProtection = dwarf.TotalProtection();

            //Assert
            Assert.AreEqual(expectedProtection, calcProtection);
        }

        [Test]
        public void AtackCheckHealthEnemy()
        //Se prueba que el valor total de la vida del enemigo sea el esperado despues de recibir un ataque por el enano.
        {  
            //Act
            int expectedHealthLeftEnemy = 270 - 180;
            orc.Equip(shield);
            dwarf.Equip(axe);
            dwarf.Equip(warhammer);
            dwarf.Attack(orc);

            //Assert
            Assert.AreEqual(expectedHealthLeftEnemy, orc.Health);
        } 

        [Test]
        public void ReceiveAttackCheck()
        //Se prueba que el valor total de la vida (con su protección) del enano sea el esperado despues de recibir un daño ataque en especifico.
        {   
            //Act
            int expectedDwarfHealth = 5;
            dwarf.Equip(axe);
            dwarf.Equip(warhammer);
            dwarf.RecieveAttack(110);
        
            //Assert
            Assert.AreEqual(expectedDwarfHealth, dwarf.Health);
        }

       [Test]
        public void HealOrcCheck()
        // Se comprueba que el el método para curar a un orco del enano funcione correctamente. //

        {
            //Act
            dwarf.Attack(orc);
            dwarf.HealCharacter(orc);
            int newHealth = orc.Health;
            //Assert
            Assert.AreEqual(orc.InitialHealth, newHealth);
        }
    }
}