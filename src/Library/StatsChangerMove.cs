namespace Library;

public class StatsChangerMove: IMove
{
    public string Name { get; }
    public bool Special { get; }
    public int Buff { get; }
    public int LastTurnPlayed { get; }
}