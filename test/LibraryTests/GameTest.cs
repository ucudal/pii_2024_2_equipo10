/*
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

    [Test]
    public void TestMetodo1()
    {
        Player player1 = new Player("Facundo");
        Player player2 = new Player("Mateo");
        Game game = new Game(player1, player2);
        game.NextTurn();
        Assert.That(1, Is.EqualTo(game.TurnCount));
    }
}
*/