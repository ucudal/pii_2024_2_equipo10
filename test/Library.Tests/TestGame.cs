namespace Library.Tests;

public class GameTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestMetodo1()
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Game game = new Game(player1, player2);
        game.NextTurn();
        Assert.That(1, Is.EqualTo(game.TurnCount));
    }

    public void TestMetodo2()
    {
        
    }
    
}