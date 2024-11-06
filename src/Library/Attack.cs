namespace Library;

public class Attack : IAttack
{
    public string Name { get; private set;}
    public Type Type { get; }
    public double Accuracy {get; private set;}
    public int Power {get; private set;}

    public Attack(string name, Type type, int Accuracy, int Power)
    {
        this.Name = name;
        this.Type = type;
        this.Accuracy = Accuracy;
        this.Power = Power;

    }
}