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
    /// Verifica que el método AddGame agrega correctamente un juego a la lista de juegos.
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
    /// Verifica que el método RemoveGame elimina correctamente un juego de la lista de juegos
    /// y que no puede eliminar un juego que no está en la lista.
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
    /// Verifica que el método FindPlayerByName devuelve el jugador correcto cuando se busca por
    /// nombre y retorna null si el jugador no existe.
    /// </summary>
    [Test]
    public void TestFindPlayerByName()
    {
        gameList.AddGame(player1, player2, StrategyStartingPlayer);
        Assert.That(gameList.FindPlayerByName("jugador1"), Is.EqualTo(player1));
        Assert.That(gameList.FindPlayerByName(" "), Is.Null);
    }
    
    /// <summary>
    /// Verifica que el método FindGameByPlayer devuelve el juego en el que se encuentra un jugador y retorna
    /// null si el jugador no participa en ningún juego.
    /// </summary>
    [Test]
    public void TestFindGameByPlayer()
    {
        Game game1 = gameList.AddGame(player1, player2, StrategyStartingPlayer);
        Assert.That(gameList.FindGameByPlayer(player1),Is.EqualTo(game1));
        Assert.That(gameList.FindGameByPlayer(player3), Is.Null);
    }
    
    /// <summary>
    /// Verifica que el método GetGameList devuelve correctamente la lista de juegos.
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