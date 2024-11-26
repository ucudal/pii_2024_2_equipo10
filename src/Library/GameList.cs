using Library.Strategies;

namespace Library;
/// <summary>
/// Esta clase representa la lista de partidas en curso.
/// </summary>
public class GameList
{
    /// <summary>
    /// Lista de partidas.
    /// </summary>
    private List<Game> Games { get; } = new List<Game>();
    
    /// <summary>
    /// Agrega una partida a la lista de partidas.
    /// </summary>
    /// <param name="player1"> Jugador 1.</param>
    /// <param name="player2"> Jugador 2.</param>
    /// <param name="strategyStartingPlayer"> Estrategia que determinara como se va a determinar que jugador tiene el primer turno.</param>
    /// <returns>La partida agregada.</returns>
    public Game AddGame(Player player1, Player player2, IStrategyStartingPlayer strategyStartingPlayer)
    {
        Game game = new Game(player1, player2, strategyStartingPlayer);
        this.Games.Add(game);
        return game;
    }
    /// <summary>
    /// Elimina una partida de la lista de partidas.
    /// </summary>
    /// <param name="game">Partida a remover.</param>
    /// <returns>
    /// <c>true</c> si la partida fue eliminada. <c>false</c> si no encontró la partida.
    /// </returns>
    public bool RemoveGame(Game game)
    {
        if (this.Games.Remove(game))
            return true;
        return false;
    }

    /// <summary>
    /// Devuelve un jugador buscandolo por su nombre
    /// </summary>
    /// <param name="playerName">Nombre del jugador a buscar.</param>
    /// <returns>
    /// <c>null</c> si el jugador no está en ninguna partida.
    /// </returns>
    public Player? FindPlayerByName(string playerName)
    {
        foreach (Game game in this.Games)
            foreach (Player player in game.GetPlayers())
                if (player.Name == playerName)
                    return player;
        return null;
    }

    /// <summary>
    /// Devuelve la partida en la que se encuentra un jugador.
    /// </summary>
    /// <param name="player"> Jugador a buscar. </param>
    /// <returns>
    /// <c>null</c> si el jugador no está en ninguna partida.
    /// </returns>
    public Game? FindGameByPlayer(Player player)
    {
        foreach (Game game in this.Games)
            if (game.GetPlayers().Contains(player))
                return game;
        return null;
    }
    
    /// <summary>
    /// Devuelve la lista de partidas.
    /// </summary>
    public List<Game> GetGameList()
    {
        return this.Games;
    }
}