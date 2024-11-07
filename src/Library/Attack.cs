namespace Library;

public class Attack : IAttack
{
    public string Name { get; private set;}
    public Type Type { get; }
    public double Accuracy {get; private set;}
    public int Power {get; private set;}

    public Attack(string name, Type type, int Accuracy, int Power)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("El nombre ingresado no es válido");
        }
        if (Accuracy < 0 || Accuracy > 1)
        {
            throw new ArgumentException("La precision ingresada no es válido");
        }
        if (Power < 0)
        {
           throw new ArgumentException("El poder ingresado no es válido");
        }
        this.Name = name;
        this.Type = type;
        this.Accuracy = Accuracy;
        this.Power = Power;

    }
}