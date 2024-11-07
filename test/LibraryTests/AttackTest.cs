using Library;
using NUnit.Framework;
namespace LibraryTests;


public class AttackTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAccuracy0()
    {
        Attack attack = new Attack("impactrueno",Library.Type.Electric, 0, 100);
        Assert.That(attack.Accuracy.Equals(0));
    }

    [Test]
    public void TestPower0()
    {
        Attack attack = new Attack("impactrueno",Library.Type.Electric, 1, 0);
        Assert.That(attack.Power.Equals(0));
    }

    [Test]
    public void TestNullName()
    {
        Attack attack;
        Assert.That(new Attack("",Library.Type.Electric, 1, 30).Equals("El nombre ingresado no es válido"));
    }

    [Test]
    public void TestInvalidAccuracy()
    {
        Attack attack;
        Assert.That(new Attack("impactrueno",Library.Type.Electric, 70000, 30).Equals("La precision ingresada no es válido"));
    }

    [Test]
    public void TestInvalidPower()
    {
        Attack attack;
        Assert.That(new Attack("",Library.Type.Electric, 1, -80000).Equals("El poder ingresado no es válido"));
    }
}