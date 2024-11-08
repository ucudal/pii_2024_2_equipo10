namespace Library;

/// <summary>
/// Esta clase representa un ataque especial.
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
    /// 
    /// </summary>
    /// <param name="name">Nombre del ataque a crear.</param>
    /// <param name="type">Tipo del ataque a crear.</param>
    /// <param name="accuracy">Precisión del ataque a crear.</param>
    /// <param name="power">Potencia del ataque a crear.</param>
    /// <param name="specialEffect">Efecto del ataque a crear.</param>
    public SpecialAttack(string name, Type type, int accuracy, int power, State specialEffect): base(name, type, accuracy, power)
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
        Cooldown = 2;
    }
}