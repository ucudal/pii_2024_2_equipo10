using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="SpecialAttack"/>
/// </summary>

[TestFixture]
[TestOf(typeof(Game))]
public class SpecialAttackTest
{

        /// <summary>
        /// Test del constructor.
        /// </summary>
        [Test]
        public void TestConstructor()
        {
            SpecialAttack specialAttack = new SpecialAttack("Lanzallamas", Type.Fire, 0.9, 40, State.Burned);
            Assert.That(specialAttack.Name, Is.EqualTo("Lanzallamas"));
            Assert.That(specialAttack.Type, Is.EqualTo(Type.Fire));
            Assert.That(specialAttack.Accuracy, Is.EqualTo(0.9));
            Assert.That(specialAttack.Power, Is.EqualTo(40));
            Assert.That(specialAttack.SpecialEffect, Is.EqualTo(State.Burned));
            Assert.That(specialAttack.Cooldown, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifica que el cooldown de un ataque especial disminuye correctamente llamando al metodo LowerCooldown().
        /// </summary>
        [Test]
        public void TestLowerCooldown()
        {
            SpecialAttack specialAttack = new SpecialAttack("Lanzallamas", Type.Fire, 0.9, 40, State.Burned);
            specialAttack.SetCooldown();
            Assert.That(specialAttack.Cooldown, Is.EqualTo(4));
            specialAttack.LowerCooldown();
            Assert.That(specialAttack.Cooldown, Is.EqualTo(3));
        }

        /// <summary>
        /// Verifica que el método SetCooldown() restablece a 4 el cooldown del ataque especial.
        /// </summary>
        [Test]
        public void TestSetCooldown()
        {
            SpecialAttack specialAttack = new SpecialAttack("Lanzallamas", Type.Fire, 0.9, 40, State.Burned);
            specialAttack.SetCooldown();
            Assert.That(specialAttack.Cooldown, Is.EqualTo(4));
        }

        /// <summary>
        /// Verifica que la descripción del ataque especial sea correcta.
        /// </summary>
        [Test]
        public void TestInfoAttack()
        {
            SpecialAttack specialAttack = new SpecialAttack("Lanzallamas", Type.Fire, 0.9, 40, State.Burned);
            string expectedInfo = "**Lanzallamas**: tipo *Fire*, precisión *90*, potencia *40*, efecto especial *Burned*, cooldown de uso actual *0*\n";
            Assert.That(specialAttack.InfoAttack(), Is.EqualTo(expectedInfo));
        }
        
        /// <summary>
        /// Test de ataque especial.
        /// </summary>
        [Test]
        public void TestSpecialAttack()
        {
            Player player = new Player("mateo");
            SpecialAttack lanzallamas = new SpecialAttack("lanzallamas", Library.Type.Fire, 1, 40, Library.State.Burned);
            Gengar gengar = new Gengar();
            player.AddToTeam(gengar);
            DamageCalculator damageCalculator = new DamageCalculator();
            damageCalculator.CalculateDamage(gengar,lanzallamas, player);
            Assert.That(lanzallamas.SpecialEffect.Equals(gengar.CurrentState));
        }
    }


