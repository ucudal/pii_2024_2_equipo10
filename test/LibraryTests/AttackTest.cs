using Library;
using NUnit.Framework;
namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Attack"/>
/// </summary>

public class AttackTest
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Test del atributo Accuracy en 0.
    /// </summary>
    [Test]
    public void TestAccuracy0()
    {
        Attack attack = new Attack("impactrueno",Library.Type.Electric, 0, 100);
        Assert.That(attack.Accuracy.Equals(0));
    }

    /// <summary>
    /// Test del atributo Power en 0.
    /// </summary>
    [Test]
    public void TestPower0()
    {
        Attack attack = new Attack("impactrueno",Library.Type.Electric, 1, 0);
        Assert.That(attack.Power.Equals(0));
    }

    /// <summary>
    /// Test del nombre nulo
    /// </summary>
    [Test]
    public void TestNullName()
    {
        Attack attack;
        Assert.That(new Attack("",Library.Type.Electric, 1, 30), Is.EqualTo("El nombre ingresado no es válido"));
    }

    /// <summary>
    /// Test de Accuracy invalido.
    /// </summary>
    [Test]
    public void TestInvalidAccuracy()
    {
        Attack attack;
        Assert.That(new Attack("impactrueno",Library.Type.Electric, 70000, 30).Equals("La precision ingresada no es válido"));
    }

    /// <summary>
    /// Test de Power invalido.
    /// </summary>
    [Test]
    public void TestInvalidPower()
    {
        Attack attack;
        Assert.That(new Attack("",Library.Type.Electric, 1, -80000).Equals("El poder ingresado no es válido"));
    }
}