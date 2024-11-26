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
    /// Verifica que al usar una FullHealth sobre un Pokemon dormido, su estado se restablezca correctamente.
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

    /// <summary>
    /// Verifica que al usar una FullHealth sobre un Pokemon sin estado negativo, el resultado sea un mensaje
    /// indicando que actualmente no tiene ningún estado negativo.
    /// </summary>
    [Test]
    public void FullHealthUseOnHealthyPokemon()
    {
        FullHealth fullHealthItem = new FullHealth();
        Charizard charizard = new Charizard();
        string result = fullHealthItem.Use(charizard);
        Assert.That(result.Equals("Charizard no tiene ningún estado negativo"));
    }

    /// <summary>
    /// Verifica que al intentar usar una FullHealth sobre un Pokemon nulo, el resultado sea nulo.
    /// </summary>
    [Test]
    public void FullHealthNullPokemon()
    {
        FullHealth fullHealthItem = new FullHealth();
        string result = fullHealthItem.Use(null);
        Assert.That(fullHealthItem.Use(null), Is.Null);
    }
    
}