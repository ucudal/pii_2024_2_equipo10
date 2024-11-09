using Library;
using NUnit.Framework;
namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Revive"/>
/// </summary>

public class ReviveTest
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Test de pocion de revivir.
    /// </summary>
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