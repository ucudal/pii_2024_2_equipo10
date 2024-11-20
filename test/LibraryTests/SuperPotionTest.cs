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
    /// Verifica que SuperPotion recupere correctamente 70HP de un Pokemon después de recibir 60 puntos de daño,
    /// llevando su vida a su valor inicial.
    /// </summary>
    [Test]
    public void SuperPotionCorrectUse1()
    {
        SuperPotion SuperPotionItem = new SuperPotion();
        Charizard charizard = new Charizard();
        double initialLife = charizard.BaseLife;
        charizard.TakeDamage(60);
        string result = SuperPotionItem.Use(charizard);
        string expectedResult = "Charizard ha ganado 70HP.\n¡Super Potion utilizada con éxito!";
        Assert.That(result.Equals(expectedResult));
        Assert.That(charizard.CurrentLife.Equals(initialLife));
    }

    /// <summary>
    /// Verifica que SuperPotion recupere correctamente 70HP de un Pokemon después de recibir 80 puntos de daño.
    /// </summary>
    [Test]
    public void SuperPotionCorrectUse2()
    {
        SuperPotion SuperPotionItem = new SuperPotion();
        Charizard charizard = new Charizard();
        double initialLife = charizard.BaseLife;
        charizard.TakeDamage(80);
        string result = SuperPotionItem.Use(charizard);
        string expectedResult = "Charizard ha ganado 70HP.\n¡Super Potion utilizada con éxito!";
        Assert.That(result.Equals(expectedResult));
        Assert.That(charizard.CurrentLife.Equals(initialLife-10));
    }

    /// <summary>
    /// Verifica que SuperPotion no tenga efecto si el Pokemon ya tiene su vida completa,
    /// y que la vida del Pokemon no haya cambiado.
    /// </summary>
    [Test]
    public void SuperPotionHealthyPokemonUse()
    {
        SuperPotion SuperPotionItem = new SuperPotion();
        Charizard charizard = new Charizard();
        double initialLife = charizard.BaseLife;
        string result = SuperPotionItem.Use(charizard);
        string expectedResult = "Charizard ya tiene su vida completa.\n";
        Assert.That(result.Equals(expectedResult));
        Assert.That(charizard.CurrentLife.Equals(initialLife));
    }
    
    /// <summary>
    /// Verifica que al intentar usar SuperPotion con un Pokemon nulo, el resultado sea nulo.
    /// </summary>
    [Test]
    public void NullPokemonTest()
    {
        SuperPotion SuperPotionItem = new SuperPotion();
        Assert.That(SuperPotionItem.Use(null), Is.Null);
    }

    
}