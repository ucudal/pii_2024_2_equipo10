namespace Library;

public class GameList
{
    private List<Game> Games { get; set; } = new List<Game>();
    
    public Game AddGame(Player player1, Player player2)
    {
        Game game = new Game(player1, player2);
        this.Games.Add(game);
        return game;
    }

    public Player? FindPlayerByName(string playerName)
    {
        foreach (Game game in this.Games)
            foreach (Player player in game.Players)
                if (player.Name == playerName)
                    return player;
        return null;
    }

    public Game? FindGameByPlayer(Player player)
    {
        foreach (Game game in this.Games)
            if (game.Players.Contains(player))
                return game;
        return null;
    }
}