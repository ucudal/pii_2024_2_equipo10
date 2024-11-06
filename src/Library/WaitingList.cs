namespace Library;

public class WaitingList
{
    public List<Player> Players { get; private set; }= new List<Player>();

    public int Count
    {
        get { return this.Players.Count; }
    }
    
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