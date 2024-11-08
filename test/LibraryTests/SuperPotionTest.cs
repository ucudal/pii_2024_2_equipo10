using Library;
using NUnit.Framework;
namespace LibraryTests;


public class SuperPotionTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SuperPotionCorrectUse()
    {
        SuperPotion SuperPotionItem = new SuperPotion();
        Charizard charizard = new Charizard();
        charizard.TakeDamage(60);
        SuperPotionItem.Use(charizard);
        Assert.That(charizard.CurrentLife.Equals(350));
    }

    
}