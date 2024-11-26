namespace Library.Strategies;

/// <summary>
/// Esta clase representa una estrategia que determina el daño crítico hecho por el ataque de un pokemon.
/// Al ser una estrategia que determina el daño crítico, implementa la interfaz <see cref="IStrategyCritCheck"/>.
/// </summary>
public class StrategyRandomCrit : IStrategyCritCheck
{
    
    /// <summary>
    /// Determina si un ataque resulta en un golpe crítico basado en una probabilidad aleatoria.
    /// </summary>
    /// <returns>
    /// Un valor <c>double</c>: <c>1.20</c> si el ataque es crítico (10% de probabilidad), 
    /// o <c>1.0</c> si no es crítico.
    /// </returns> 
    public double CriticalCheck()
    {
        Random random = new Random();
        int chance = random.Next(1,11);
        if (chance == 1)
        {
            return 1.20;
        }
        return 1.0;
    }
}