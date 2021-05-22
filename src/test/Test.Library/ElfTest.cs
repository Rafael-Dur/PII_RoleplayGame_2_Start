using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class ElfTest
    {
        private Elf elf;
        private Bow bow;
        private Cloak cloak;
        private Wizard wizard;
        private SpellBook spellBook;
        private Spell spell;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            bow = new Bow("Arco gigante", 75, "Tira fuego");
            cloak = new Cloak("Capa maxima", 80, "Agilidad");
            elf = new Elf("Frank",15, "Escurridizo");
            spellBook = new SpellBook("Libro de Hechizos Oscuros","Hechizos oscuros");
            spell = new Spell("Lumos", "La varita enciende luz", 65, 0);
            wizard = new Wizard("Harry", "Mago De Apoyo", spellBook); 
        }

        [Test]
        public void NameAndRoleCannotBeNull()
        //Se prueba que el nombre y el rol del elfo que no sea nulo
        {   
            //Assert
            Assert.IsTrue(elf.Name!=null && elf.Role!=null);
        }

        [Test]
        public void ElfCorrectlyInstanced()
        //Se prueba que elfo se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(elf);
        }

        [Test]
        public void AttachAttackItemCheck()
        //Se prueba que el arco se attach al elfo.
        {   //Act
            elf.Equip(bow);
            
            //Assert
            Assert.IsNotNull(elf.Inventary);
        }

        [Test]
        public void AttachDefensiveItemCheck() 
        //Se prueba que la capa se attach al elfo.
        {   
            //Act
            elf.Equip(cloak);
            int index = elf.Inventary.IndexOf(cloak);

            //Assert
            Assert.AreEqual(0,index);
        }

        [Test]
        public void RemoveItemCheck()
        //Se prueba que el arco se remueva del elfo.
        {   
            //Act
            elf.Equip(bow);
            elf.UnEquip(bow);
            int cantidadEsperadaItems = 0;
            //Assert
            Assert.AreEqual(cantidadEsperadaItems, elf.Inventary.Count);
        }

        [Test]
        public void TotalDamageCheck() 
        //Se prueba que el valor total del damage del elfo sea el esperado.
        {   
            //Act
            elf.Equip(bow);
            int expectedTotalDamage = 90;

            int calcTotalDamage = elf.TotalDamage();

            //Assert
            Assert.AreEqual(expectedTotalDamage, calcTotalDamage);
        }

        [Test]
        public void TotalProtectionCheck() 
        //Se prueba que el valor total de la proteccion del elfo sea el esperado.
        {
            //Act
            elf.Equip(cloak);
            int expectedProtection = 80;

            int calcProtection = elf.TotalProtection();

            //Assert
            Assert.AreEqual(expectedProtection, calcProtection);
        }

        [Test]
        public void AtackCheckHealthEnemy()
        //Se prueba que el valor total de la vida del enemigo sea el esperado despues de recibir un ataque por el elfo.
        {  
            //Act
            wizard.Respawn();
            int expectedHealthLeftEnemy = 10;
            elf.Equip(bow);
            elf.Equip(cloak);
            wizard.Equip(spellBook);
            wizard.LearnSpell(spell);
            elf.Attack(wizard);

            //Assert
            Assert.AreEqual(expectedHealthLeftEnemy,wizard.Health);
        } 

        [Test]
        public void ReceiveAttackCheck()
        //Se prueba que el valor total de la vida (con su protección) del elfo sea el esperado despues de recibir un dañp ataque en especifico.
        {   
            //Act
            int expectedElfHealth = 70;
            elf.Equip(cloak);
            elf.RecieveAttack(110);
        
            //Assert
            Assert.AreEqual(expectedElfHealth,elf.Health);
        }

        [Test]
        public void HealWizardCheck()
        // Se comprueba que el el método para curar a un mago del elfo funcione correctamente. //

        {
            //Act
            wizard.Respawn();
            elf.Attack(wizard);
            elf.HealCharacter(wizard);
            int newHealth = wizard.Health;
            //Assert
            Assert.AreEqual(100, newHealth);
        } 

        [Test]
        public void EquipNormalItemsTest()
        // Se verifica que se añadan items al inventario del elfo correctamente.
        {
            elf.Equip(bow);
            Assert.AreEqual(1, elf.Inventary.Count); 
        }
    }
}