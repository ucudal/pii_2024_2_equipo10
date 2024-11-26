namespace Library.Strategies;
/// <summary>
/// Esta clase representa una estrategia que determina quién va a ser el jugador que tenga el primer turno.
/// Al ser una estrategia que determina quién va a ser el jugador que tenga el primer turno, implementa la interfaz <see cref="IStrategyStartingPlayer"/>.
/// </summary>
public class StrategyPlayerOneStart : IStrategyStartingPlayer
{
    /// <summary>
    /// El método de esta estrategia siempre va a determinar que el primer jugador en la lista de la partida comienza.
    /// </summary>
    /// <returns><c>int</c> 0 representando el primer elemento de la lista</returns>
    public int StartingPlayer()
    {
        return 0;
    }
}