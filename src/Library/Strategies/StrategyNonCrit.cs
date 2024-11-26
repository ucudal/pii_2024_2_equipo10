namespace Library.Strategies;

/// <summary>
/// Esta clase representa una estrategia que determina el daño crítico hecho por el ataque de un pokemon.
/// Al ser una estrategia que determina el daño crítico, implementa la interfaz <see cref="IStrategyCritCheck"/>.
/// </summary>
public class StrategyNonCrit : IStrategyCritCheck
{
 
    
    /// <summary>
    /// El método de esta estrategia siempre va a determinar que todos los ataques hechos por un pokemon no sean críticos.
    /// </summary>
    /// <returns>Un valor <c>double</c>: <c>1.0</c>. Determinando así que el golpe nunca es crítico</returns>
    public double CriticalCheck()
    {
        return 1.0;
    }
}