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
    /// Verifica que el item Revive funciona correctamente.
    /// </summary>
    [Test]
    public void ReviveCorrectUse()
    {
        Revive ReviveItem = new Revive();
        Charizard charizard = new Charizard();
        charizard.TakeDamage(1000000);
        string result = ReviveItem.Use(charizard);
        Assert.That(charizard.CurrentLife.Equals(180));
        Assert.That(result, Is.EqualTo("Charizard ha revivido. \n¡Revive utilizada con éxito!"));
    }

    /// <summary>
    /// Verifica que el item Revive no puede utilizarse sobre un Pokemon que no está debilitado.
    /// </summary>
    [Test]
    public void ReviveWrongUse()
    {
        Revive ReviveItem = new Revive();
        Charizard charizard = new Charizard();
        string result = ReviveItem.Use(charizard);
        Assert.That(result, Is.EqualTo("Charizard no está debilitado.\n"));

    }

    
}