namespace Library;

public class BattleList
{
    public List<Game> Games { get; private set; } = new List<Game>();
    
    public Game AddGame(Player player1, Player player2)
    {
        Game game = new Game(player1, player2);
        this.Games.Add(game);
        return game;
    }
}