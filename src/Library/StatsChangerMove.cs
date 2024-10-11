namespace Library;

public class StatsChangerMove: IMove
{
    public string Name { get; private set; }
    public bool Special { get; private set; }
    public int Buff { get; private set;}
    public string StatBuff { get; private set; }
    public int LastTurnPlayed { get; private set;}
}