namespace Library;
/// <summary>
/// Esta clase representa la lista de espera.
/// </summary>
public class WaitingList
{
    /// <summary>
    /// Obtiene la lista de jugadores en espera.
    /// </summary>
    public List<Player> Players { get; private set; }= new List<Player>();

    /// <summary>
    /// Devuelve el número de jugadores en espera.
    /// </summary>
    public int Count
    {
        get { return this.Players.Count; }
    }
    
    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="playerName"></param>
    /// <returns>
    ///<c>true</c> si el jugador fue agregado. <c>false</c> si ya estaba esperando.
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    public bool AddPlayer(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
            throw new ArgumentException(nameof(playerName));
        if (this.FindPlayerByName(playerName) != null) 
            return false;
        this.Players.Add(new Player(playerName));
        return true;
    }

    public bool RemovePlayer(string playerName)
    {
        Player? player = FindPlayerByName(playerName);
        if (player == null)
            return false;
        this.Players.Remove(player);
        return true;
    }

    public Player? FindPlayerByName(string playerName)
    {
        foreach (Player player in this.Players)
            if (player.Name == playerName)
                return player;
        return null;
    }
    
    public Player? GetAnyoneWaiting()
    {
        Random random = new Random();
        int randomNumber = random.Next(0, this.Count);
        return this.Players[randomNumber];
    }
}