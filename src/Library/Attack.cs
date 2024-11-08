namespace Library;
    /// <summary>
    /// Esta clase representa un ataque básico que puede aprender el pokémon.
    /// </summary>
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
    /// <param name="accuracy">Precisión del ataque a crear.</param>
    /// <param name="power">Potencia del ataque a crear.</param>
    public Attack(string name, Type type, int accuracy, int power)
    {
        this.Name = name;
        this.Type = type;
        this.Accuracy = accuracy;
        this.Power =power;

    }
}