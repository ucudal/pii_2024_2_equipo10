using Library;
using Library.Strategies;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Game))]
public class GameTest
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Verifica que el método ChangePokemon cambia correctamente el Pokemon activo de un jugador durante la partida.
    /// </summary>
    [Test] 
    public void TestChangePokemon()
    {
        Player player1 = new Player("1");
        Player player2 = new Player("1");
        Game game = new Game(player1, player2, new StrategyRandomStartingPlayer());
        Charizard charizard= new Charizard();
        Gengar gengar = new Gengar();
        player1.SetActivePokemon(charizard);
        game.ChangePokemon(gengar);
        Assert.That($"{gengar.Name} es tu nuevo Pokemon activo.", Is.EqualTo($"{gengar.Name} es tu nuevo Pokemon activo."));

    }

    /// <summary>
    /// Verifica que el método Winner devuelve correctamente el ganador de la partida, en caso de que sea el jugador 1.
    /// </summary>
    [Test]
    public void TestWinnerPlayer1()
    {
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");
        Game game = new Game(player1, player2, new StrategyPlayerOneStart());
        Charizard charizard= new Charizard();
        Gengar gengar = new Gengar();
        player1.AddToTeam(charizard);
        player2.AddToTeam(gengar);
        Attack attack = new Attack("kamehameha", Library.Type.Electric, 1, 1000);
        game.ExecuteAttack(attack);
        Assert.That(game.Winner(), Is.EqualTo($"\nGanador: Player 1. Perdedor: Player 2"));

    }

    /// <summary>
    /// Verifica que el método Winner devuelve correctamente el ganador de la partida, en caso de que sea el jugador 2.
    /// </summary>
    [Test]
    public void TestWinnerPlayer2()
    {
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");
        Game game = new Game(player1, player2, new StrategyPlayerTwoStart());
        Charizard charizard= new Charizard();
        Gengar gengar = new Gengar();
        player1.AddToTeam(charizard);
        player2.AddToTeam(gengar);
        Attack attack = new Attack("kamehameha", Library.Type.Electric, 1, 1000);
        game.ExecuteAttack(attack);
        Assert.That(game.Winner(), Is.EqualTo($"\nGanador: Player 2. Perdedor: Player 1"));
    }
}
