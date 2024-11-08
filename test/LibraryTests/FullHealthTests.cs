using Library;
using NUnit.Framework;
namespace LibraryTests;


public class FullHealthTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FullHealthCorrectUse()
    {
        FullHealth fullHealthItem = new FullHealth();
        Charizard charizard = new Charizard();
        charizard.CurrentState = State.Asleep;
        fullHealthItem.Use(charizard);
        Assert.That(charizard.CurrentState.Equals(null));
    }

    [Test]
    public void TestPower0()
    {
        Attack attack = new Attack("impactrueno",Library.Type.Electric, 1, 0);
        Assert.That(attack.Power.Equals(0));
    }

    
}