namespace Library;
/// <summary>
/// Esta clase representa la lista de espera.
/// </summary>
public class WaitingList
{
    /// <summary>
    /// Lista de jugadores en espera.
    /// </summary>
    private List<Player> Players { get; set; }= new List<Player>();

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
    /// <param name="playerName"> Nombre del jugaodr a agregar.</param>
    /// <returns>
    ///<c>true</c> si el jugador fue agregado. <c>false</c> si ya estaba esperando.
    /// </returns>
    /// <exception cref="ArgumentException"> si el nombre es nulo o vacío.</exception>
    public bool AddPlayer(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
            throw new ArgumentException(nameof(playerName));
        if (this.FindPlayerByName(playerName) != null) 
            return false;
        this.Players.Add(new Player(playerName));
        return true;
    }
    
    /// <summary>
    /// Elimina un jugador de la lista de espera.
    /// </summary>
    /// <param name="playerName"> Nombre del jugador a remover.</param>
    /// <returns>
    ///<c>true</c> si el jugador fue eliminado. <c>false</c> si no estaba esperando.
    /// </returns>
    public bool RemovePlayer(string playerName)
    {
        Player? player = FindPlayerByName(playerName);
        if (player == null)
            return false;
        this.Players.Remove(player);
        return true;
    }

    /// <summary>
    /// Devuelve un jugador de la lista de espera buscandolo por su nombre.
    /// </summary>
    /// <param name="playerName"> Nombre del jugador a agregar.</param>
    /// <returns>
    /// <c>null</c> si el jugador no está esperando.
    /// </returns>
    public Player? FindPlayerByName(string playerName)
    {
        foreach (Player player in this.Players)
            if (player.Name == playerName)
                return player;
        return null;
    }

    /// <summary>
    /// Devuelve un jugador al azar de la lista de espera.
    /// </summary>
    public Player? GetSomeone(string playerName)
    {
        Random random = new Random();
        if (this.Count <= 1)
            return null;
        int randomNumber;
        do
        {
            randomNumber = random.Next(0, this.Count);
        } while (this.Players[randomNumber].Name == playerName);
        return this.Players[randomNumber];
    }

    /// <summary>
    /// Devuelve la lista de jugadores en espera.
    /// </summary>
    public List<Player> GetWaitingList()
    {
        return this.Players;
    }
}