namespace Library;

public class DamageMove: IMove
{
    public string Name { get; private set;}
    public double Accuracy { get; private set;}
    public IType Type { get; private set;}
    public bool Special { get; private set;}
    public int LastTurnPlayed { get; private set; }
    public int power { get; private set; }

    public DamageMove(string name, bool special, double accuracy, int power,IType type)
    {
        this.Name = name;
        this.power = power;
        this.Accuracy = accuracy;
        this.Special = special;
        this.Type = type;
    }
}