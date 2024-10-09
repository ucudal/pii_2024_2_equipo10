namespace Library;

public class StatsChangerMove: IMove
{
    public string Name { get; }
    public bool Special { get; }
    public double Buff { get; }
    public int LastTurnPlayed { get; }
}