namespace Library;

public class Attack : IAttack
{
    /// <summary>
    /// Nombre del ataque.
    /// </summary>
    public string Name { get; private set;}
    
    /// <summary>
    /// Tipo del ataque.
    /// </summary>
    public Type Type { get; }
    
    /// <summary>
    /// Precisión del ataque.
    /// </summary>
    public double Accuracy {get; private set;}
    
    /// <summary>
    /// Potencia del ataque.
    /// </summary>
    public int Power {get; private set;}

    /// <summary>
    /// Asigna el nombre, tipo, precisión y potencia a un ataque a crear.
    /// </summary>
    /// <param name="name">Nombre del ataque a crear.</param>
    /// <param name="type">Tipo del ataque a crear.</param>
    /// <param name="Accuracy">Precisión del ataque a crear.</param>
    /// <param name="Power">Potencia del ataque a crear.</param>
    public Attack(string name, Type type, int Accuracy, int Power)
    {
        this.Name = name;
        this.Type = type;
        this.Accuracy = Accuracy;
        this.Power = Power;

    }
}