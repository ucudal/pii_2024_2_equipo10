/*
using Library;
using NUnit.Framework;

namespace Library.Tests;

[TestFixture]
[TestOf(typeof(Player))]
public class PlayerTest
{
    private Player player;
    private Charizard charizard1;
    private Charizard charizard2;
    
    [SetUp]
    public void SetUp()
    {
        
        player = new Player("jugador1");
        charizard1 = new Charizard();
        charizard2 = new Charizard();
        
    }
    
    
    [Test]
    public void TestAddToTeam()
    {
        player.AddToTeam(charizard1);
        Assert.That(player.GetPokemonTeam().Contains(charizard1));
        player.AddToTeam(charizard2);
        Assert.That(player.GetPokemonTeam().Count, Is.EqualTo(2));
    }
    
    
    [Test]
    public void TestChangeActivePokemon()
    {
        Assert.That(player.ActivePokemon,Is.EqualTo(charizard1));
    }

}
*/