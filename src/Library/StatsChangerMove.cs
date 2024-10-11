namespace Library;

public class StatsChangerMove: IMove
{
    public string Name { get; private set; }
    public bool Special { get; private set; }
    public int Buff { get; private set;}
    public string StatBuff { get; private set; }
    public int LastTurnPlayed { get; private set;}
    
    public StatsChangerMove(string name, bool special, int buff, string statBuff)
    {
        this.Name = name;
        this.Buff = buff;
        this.Special = special;
        this.StatBuff = statBuff;
    }
}