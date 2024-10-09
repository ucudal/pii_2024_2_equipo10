namespace Library;

public class DamageMove: IMove
{
    public string Name { get; }
    public int Potencia { get; }
    public double Precision { get; }
    public bool Special { get; }
    public int LastTurnPlayed { get; private set; }
}