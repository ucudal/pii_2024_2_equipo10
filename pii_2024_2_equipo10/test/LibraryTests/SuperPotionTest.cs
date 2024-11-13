using Library;
using NUnit.Framework;
namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="SuperPotion"/>
/// </summary>

public class SuperPotionTest
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Test de pocion de curacion.
    /// </summary>
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