using Library;
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

    [Test] //Test para verificar que se cambie de pokemon activo correctamente
    public void TestChangePokemon()
    {
        Player player1 = new Player("1");
        Player player2 = new Player("1");
        Game game = new Game(player1, player2);
        Charizard charizard= new Charizard();
        Gengar gengar = new Gengar();
        player1.SetActivePokemon(charizard);
        game.ChangePokemon(gengar);
        Assert.That($"{gengar.Name} es tu nuevo Pokemon activo.", Is.EqualTo($"{gengar.Name} es tu nuevo Pokemon activo."));

    }

    [Test]  //Test para verificar que se imprima correctamente el mensaje final ganador.
    public void TestMensajeGanador()
    {
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");
        Game game = new Game(player1, player2);
        Charizard charizard= new Charizard();
        Gengar gengar = new Gengar();
        player1.SetActivePokemon(charizard);
        player2.SetActivePokemon(gengar);
        Attack attack = new Attack("kamehameha", Library.Type.Electric, 1, 1000);
        game.ExecuteAttack(attack);
        Assert.That(game.Winner(), Is.EqualTo($"Ganador: Player 1. Perdedor: Player 2"));

    }
}
