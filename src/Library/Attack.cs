namespace Library;

public class Attack : IAttack
{
    public string Name { get; }
    public Type Type{get; }
    public int Accuracy {get; private set; }
    public int Power {get; private set; }

    public Attack(string name, Type type, int accuracy, int power)
    {
        this.Name = name;
        this.Type = type;
        this.Accuracy = accuracy;
        this.Power = power;
    }
}