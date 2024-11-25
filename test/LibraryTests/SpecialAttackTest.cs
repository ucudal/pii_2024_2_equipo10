using Library;
using NUnit.Framework;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="SpecialAttack"/>
/// </summary>

[TestFixture]
[TestOf(typeof(Game))]
public class SpecialAttackTest
{
    [SetUp]
    public void Setup()
    {
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
        //DamageCalculator.Instance.CalculateDamage(gengar,lanzallamas, player);
        Assert.That(lanzallamas.SpecialEffect.Equals(gengar.CurrentState));

    }
}