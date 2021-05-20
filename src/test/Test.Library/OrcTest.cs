using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class OrcTest
    {
        private Orc orc;
        private Sword sword;
        private Shield shield;
        private Dwarf dwarf;
        private Axe axe;
        private Warhammer warhammer;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            sword = new Sword("Espadon", 50, 0,"Corte Fugaz");
            shield = new Shield("Escudo Dorado", 0, 30, "Escudazo");
            orc = new Orc("Thor", 25, "Tanque");
            axe = new Axe("Hacha", 50, 0,"Corte Rapaz");
            warhammer = new Warhammer("Martillo de Guerra", 60, 0, "Martillazo");
            dwarf = new Dwarf("Wagner", 35,"Apoyo"); 
        }

        [Test]
        public void NameAndRoleCannotBeNull()
        //Se prueba que el nombre y el rol del orco que no sea nulo
        {   
            //Assert
            Assert.IsTrue(orc.Name!=null && orc.Role!=null);
        }

        [Test]
        public void OrcCorrectlyInstanced()
        //Se prueba que orco se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(orc);
        }

        [Test]
        public void AttachAttackItemCheck()
        //Se prueba que la espada se attach al orco.
        {   //Act
            orc.Equip(sword);
            
            //Assert
            Assert.IsNotNull(orc.Inventary);
        }

        [Test]
        public void AttachDefensiveItemCheck()
        //Se prueba que el escudo se attach al orco.
        {   
            //Act
            orc.Equip(shield);
            int index = orc.Inventary.IndexOf(shield);

            //Assert
            Assert.AreEqual(0,index);
        }

        [Test]
        public void RemoveItemCheck()
        //Se prueba que la espada se remueva del orco.
        {   
            //Act
            orc.Equip(sword);
            orc.UnEquip(sword);
            int cantidadEsperadaItems = 0;
            //Assert
            Assert.AreEqual(cantidadEsperadaItems, orc.Inventary.Count);
        }

        [Test]
        public void TotalDamageCheck()
        //Se prueba que el valor total del damage del orco sea el esperado.
        {   
            //Act
            orc.Equip(sword);
            int expectedTotalDamage = 75;

            int calcTotalDamage = orc.TotalDamage();

            //Assert
            Assert.AreEqual(expectedTotalDamage, calcTotalDamage);
        }

        [Test]
        public void TotalProtectionCheck()
        //Se prueba que el valor total de la proteccion del orco sea el esperado.
        {
            //Act
            orc.Equip(shield);
            int expectedProtection = 30;

            int calcProtection = orc.TotalProtection();

            //Assert
            Assert.AreEqual(expectedProtection, calcProtection);
        }

        [Test]
        public void AtackCheckHealthEnemy()
        //Se prueba que el valor total de la vida del enemigo sea el esperado despues de recibir un ataque por el orco.
        {  
            //Act
            dwarf.Respawn();
            int expectedHealthLeftEnemy = 25;
            orc.Equip(sword);
            orc.Equip(shield);
            dwarf.Equip(axe);
            dwarf.Equip(warhammer);
            orc.Attack(dwarf);

            //Assert
            Assert.AreEqual(expectedHealthLeftEnemy,dwarf.Health);
        } 

        [Test]
        public void ReceiveAttackCheck()
        //Se prueba que el valor total de la vida (con su protección) orco sea el esperado despues de recibir un dañp ataque en especifico.
        {   
            //Act
            int expectedOrcHealth = 120;
            orc.Equip(shield);
            orc.RecieveAttack(110);
        
            //Assert
            Assert.AreEqual(expectedOrcHealth,orc.Health);
        }

        [Test]
        public void HealDwarfCheck()
        // Se comprueba que el el método para curar a un mago del enano funcione correctamente. //

        {
            //Act
            orc.Attack(dwarf);
            orc.HealCharacter(dwarf);
            int newHealth = dwarf.Health;
            //Assert
            Assert.AreEqual(dwarf.InitialHealth, newHealth);
        }
    }
}