namespace Library;

public class Attack : IAttack
{
    public string Name { get; private set;}
    public Type types{get; private set;}
    public double Accuracy {get; private set;}
    public int Power {get; private set;}

    public Attack(string name, Type type, int Accuracy, int Power)
    {
        this.Name = name;
        this.types = type;
        this.Accuracy = Accuracy;
        this.Power = Power;

    }
}