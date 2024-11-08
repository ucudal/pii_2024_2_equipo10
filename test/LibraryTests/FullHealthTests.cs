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

    
}