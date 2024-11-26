using Library;
using NUnit.Framework;
using Type = Library.Type;

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
        var result = Assert.Throws<ArgumentException>(() => new Attack("", Type.Electric, 1.0, 30));
        Assert.That(result.Message, Is.EqualTo("El nombre ingresado no es válido"));
    }

    /// <summary>
    /// Test de Accuracy inválido.
    /// </summary>
    [Test]
    public void TestInvalidAccuracy()
    {
        var result = Assert.Throws<ArgumentException>(() => new Attack("impactrueno", Type.Electric, 70000.0, 30));
        Assert.That(result.Message, Is.EqualTo("La precision ingresada no es válido"));
    }

    /// <summary>
    /// Test de Power invalido.
    /// </summary>
    [Test]
    public void TestInvalidPower()
    {
        var result = Assert.Throws<ArgumentException>(() => new Attack("impactrueno", Type.Electric, 0.8, -20));
        Assert.That(result.Message, Is.EqualTo("El poder ingresado no es válido"));
    }
}