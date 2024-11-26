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
    /// Constructor del ataque.
    /// Asigna el nombre, tipo, precisión y potencia a un ataque a crear.
    /// </summary>
    /// <param name="name">Nombre del ataque a crear.</param>
    /// <param name="type">Tipo del ataque a crear.</param>
    /// <param name="accuracy">Precisión del ataque a crear.</param>
    /// <param name="power">Potencia del ataque a crear.</param>
    public Attack(string name, Type type, double accuracy, int power)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("El nombre ingresado no es válido");
        }
        if (accuracy < 0 || accuracy > 1)
        {
            throw new ArgumentException("La precision ingresada no es válido");
        }
        if (power < 0)
        {
           throw new ArgumentException("El poder ingresado no es válido");
        }
        this.Name = name;
        this.Type = type;
        this.Accuracy = accuracy;
        this.Power =power;
    }

    
    /// <summary>
    /// Genera una descripción formateada del ataque.
    /// Incluye el nombre, tipo, precisión y potencia del ataque.
    /// </summary>
    public string InfoAttack()
    {
        return $"**{this.Name}**: tipo *{this.Type}*, precisión *{this.Accuracy*100}*, potencia *{this.Power}*\n";
    }
    
}