using Library;
using NUnit.Framework;
namespace LibraryTests;


public class ReviveTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReviveCorrectUse()
    {
        Revive ReviveItem = new Revive();
        Charizard charizard = new Charizard();
        charizard.TakeDamage(1000000);
        ReviveItem.Use(charizard);
        Assert.That(charizard.CurrentLife.Equals(180));
    }

    
}