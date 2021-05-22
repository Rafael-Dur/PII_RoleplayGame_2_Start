/* using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class WarhammerTest
    {
        private Warhammer warhammer;

        [SetUp]
        public void SetUp()
        {
            warhammer = new Warhammer("Aplastacráneos", 70, 0, "Machacar");
        }

        [Test]
        public void AxeCorrectlyInstanced()
        //Se prueba que el martillo de guerra se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(warhammer);
        }

        [Test]
        public void AttackValueCheck()
        //Se prueba que el valor del ataque del martillo sea el esperado.
        {  
            //Act
            int expectedAttackValue = 70;

            //Assert
            Assert.AreEqual(expectedAttackValue, warhammer.Damage);
        }

        [Test]
        public void NameCannotBeNull()
        //Se prueba que el nombre del martillo no sea nulo.
        {
            Assert.IsNotNull(warhammer.Name);
        }

        [Test]
        public void ItemNotMagic()
        //Se prueba que no sea un item de daño magico sino que en cambio sea de daño fisico.
        {
            Assert.AreEqual(false, warhammer.MagicItem);
        }
    }
} */