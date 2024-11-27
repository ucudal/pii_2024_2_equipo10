using Library;
using Library.Strategies;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(RestrictionManager))]
public class RestrictionManagerTest
{

    [Test]
    public void RestrictionTypeTest()
    {
        RestrictionManager restrictionManager = new RestrictionManager();
        Assert.That(restrictionManager.RestrictionType(Type.Water),Is.EqualTo("La restricción ha sido aplicada"));
        Assert.That(restrictionManager.RestrictionType(Type.Water),Is.EqualTo("No hay ningún pokemon que tenga ese tipo"));
    }
    
    [Test]
    public void RestrictionPokemonTest()
    {
        RestrictionManager restrictionManager = new RestrictionManager();
        Assert.That(restrictionManager.RestrictionPokemon(new Charizard()),Is.EqualTo("La restricción ha sido aplicada"));
        Assert.That(restrictionManager.RestrictionPokemon(new Charizard()),Is.EqualTo("Ese pokemon no se encuentra en el catálogo"));
    }
    
    [Test]
    public void RestrictionItemTest()
    {
        RestrictionManager restrictionManager = new RestrictionManager();
        Game game = new Game(new Player("Facu"),new Player("Gabriel"), new StrategyPlayerOneStart());
        Assert.That(restrictionManager.RestrictionItem(game),Is.EqualTo("No hay restricciones de items"));
    }
    
    [Test]
    public void RestrictionItemTest2()
    {
        RestrictionManager restrictionManager = new RestrictionManager();
        Game game = new Game(new Player("Facu"),new Player("Gabriel"), new StrategyPlayerOneStart());
        Assert.That(restrictionManager.SetRestrictedItem(new SuperPotion()), Is.EqualTo("La restricción fue aplicada"));
        Assert.That(restrictionManager.RestrictionItem(game),Is.EqualTo("La restricción ha sido aplicada"));
    }

    [Test]
    public void GetRestrictions()
    {
        RestrictionManager restrictionManager = new RestrictionManager();
        Assert.That(restrictionManager.GetRestrictions(), Is.EqualTo("Pokemon restringido: False\nTipo de pokemon restringido: False\n Item restringido: False\n"));
        restrictionManager.RestrictionPokemon(new Charizard());
        Assert.That(restrictionManager.GetRestrictions(), Is.EqualTo("Pokemon restringido: True\nTipo de pokemon restringido: False\n Item restringido: False\n"));
    }
}