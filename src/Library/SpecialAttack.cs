namespace Library;

/// <summary>
/// Esta clase representa un ataque especial.
/// Como es un ataque hereda de <see cref="Attack"/>
/// </summary>
public class SpecialAttack : Attack
{
    /// <summary>
    /// Efecto del ataque.
    /// </summary>
    public State SpecialEffect { get; private set; }
    
    /// <summary>
    /// Cantidad de turnos que se deben esperar para volver a usar el ataque especial.
    /// </summary>
    public int Cooldown { get; private set; }

    /// <summary>
    /// Constructor de <see cref="SpecialAttack"/>
    /// </summary>
    /// <param name="name">Nombre del ataque a crear.</param>
    /// <param name="type">Tipo del ataque a crear.</param>
    /// <param name="accuracy">Precisión del ataque a crear.</param>
    /// <param name="power">Potencia del ataque a crear.</param>
    /// <param name="specialEffect">Efecto del ataque a crear.</param>
    public SpecialAttack(string name, Type type, double accuracy, int power, State specialEffect): base(name, type, accuracy, power)
    {
        this.Cooldown = 0;
        this.SpecialEffect = specialEffect;
    }

    /// <summary>
    /// Le quita un turno a la cantidad de turnos que se deben esperar para usar el ataque.
    /// </summary>
    public void LowerCooldown()
    {
        if (Cooldown > 0)
        {
            Cooldown -= 1;
        }
    }

    /// <summary>
    /// Le asigna 2 a el contador de turnos que se deben esperar para usar el ataque.
    /// </summary>
    public void SetCooldown()
    {
        Cooldown = 4;
    }
    
    /// <summary>
    /// Genera una descripción formateada del ataque.
    /// Incluye el nombre, tipo, precisión, potencia del ataque, efecto especial y cooldown.
    /// </summary>
    public string InfoAttack()
    {
        return $"**{this.Name}**: tipo *{this.Type}*, precisión *{this.Accuracy*100}*, potencia *{this.Power}*, efecto especial *{this.SpecialEffect}*, cooldown de uso actual *{this.Cooldown}*\n";
    }
    
}