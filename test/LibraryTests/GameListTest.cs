using Library;
using Library.Strategies;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Tests de la clase GameList
/// </summary>
[TestFixture]
[TestOf(typeof(GameList))]
public class GameListTest
{
    private GameList gameList;
    private Player player1;
    private Player player2;
    private Player player3;
    private Player player4;
    private IStrategyStartingPlayer StrategyStartingPlayer { get; set; } = new StrategyRandomStartingPlayer();
    [SetUp]
    public void SetUp()
    {
        player1 = new Player("jugador1");
        player2 = new Player("jugador2");
        player3 = new Player("jugador3");
        player4 = new Player("jugador4");
        gameList = new GameList();
    }
    
    /// <summary>
    /// Test del método AddGame
    /// </summary>
    [Test]
    public void TestAddGame()
    {
        Game game1 = gameList.AddGame(player1, player2,StrategyStartingPlayer);
        Assert.That(gameList.GetGameList().Count, Is.EqualTo(1));
        Assert.That(gameList.GetGameList().Contains(game1));
        Game game2 = gameList.AddGame(player3, player4, StrategyStartingPlayer);
        Assert.That(gameList.GetGameList().Count, Is.EqualTo(2));
        Assert.That(gameList.GetGameList().Contains(game2));
    }
    /// <summary>
    ///Test del método RemoveGame
    /// </summary>
    [Test]
    public void TestRemoveGame()
    {
        Game game1 = gameList.AddGame(player1, player2, StrategyStartingPlayer);
        Assert.That(gameList.RemoveGame(game1));
        Game game2 = new Game(player3, player4, StrategyStartingPlayer);
        Assert.That(!gameList.RemoveGame(game2));
    }
    /// <summary>
    /// Test del método FindPlayerBYName
    /// </summary>
    [Test]
    public void TestFindPlayerByName()
    {
        gameList.AddGame(player1, player2, StrategyStartingPlayer);
        Assert.That(gameList.FindPlayerByName("jugador1"), Is.EqualTo(player1));
        Assert.That(gameList.FindPlayerByName(" "), Is.Null);
    }
    /// <summary>
    /// Test del método FindGameByPlayer
    /// </summary>
    [Test]
    public void TestFindGameByPlayer()
    {
        Game game1 = gameList.AddGame(player1, player2, StrategyStartingPlayer);
        Assert.That(gameList.FindGameByPlayer(player1),Is.EqualTo(game1));
        Assert.That(gameList.FindGameByPlayer(player3), Is.Null);
    }
    /// <summary>
    /// Test del método GetGameList
    /// </summary>
    [Test]
    public void TestGetGameList()
    {
        Assert.That(gameList.GetGameList().Count, Is.EqualTo(0));
        
        Game game1 = gameList.AddGame(player1, player2, StrategyStartingPlayer);
        Assert.That(gameList.GetGameList().Contains(game1));
        Assert.That(gameList.GetGameList().Count, Is.EqualTo(1));
    }
}