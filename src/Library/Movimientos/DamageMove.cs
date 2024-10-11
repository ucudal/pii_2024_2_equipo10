namespace Library;

public class DamageMove: IMove
{
    public string Name { get; private set;}
    public double Acurrac { get; private set;}
    public IType Type { get; private set;}
    public bool Special { get; private set;}
    public int LastTurnPlayed { get; private set; }
    public int power { get; private set; }
}