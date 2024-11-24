using Library;
using NUnit.Framework;
namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="FullHealth"/>
/// </summary>

public class FullHealthTest
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Test de pocion de curacion.
    /// </summary>

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
    public void FullHealthUseOnHealthyPokemon()
    {
        FullHealth fullHealthItem = new FullHealth();
        Charizard charizard = new Charizard();
        string result = fullHealthItem.Use(charizard);
        Assert.That(result.Equals("Charizard no tiene ningún estado negativo"));
    }

    [Test]
    public void FullHealthNullPokemon()
    {
        FullHealth fullHealthItem = new FullHealth();
        string result = fullHealthItem.Use(null);
        Assert.That(fullHealthItem.Use(null), Is.Null);
    }
    
}