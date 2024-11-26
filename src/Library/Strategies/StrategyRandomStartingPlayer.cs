namespace Library.Strategies;
/// <summary>
/// Esta clase representa una estrategia que determina quién va a ser el jugador que tenga el primer turno.
/// Al ser una estrategia que determina quién va a ser el jugador que tenga el primer turno, implementa la interfaz <see cref="IStrategyStartingPlayer"/>.
/// </summary>
public class StrategyRandomStartingPlayer : IStrategyStartingPlayer
{
    
    /// <summary>
    /// El método de esta estrategia siempre va a determinar aleatoriamente qué jugador en la lista de la partida comienza.
    /// </summary>
    /// <returns><c>int</c> <c>0</c>  o <c>1</c>. Representando el primer y segundo elemento de la lista de jugadores</returns>
    public int StartingPlayer()
    {
        Random random = new Random();
        return random.Next(0, 2);
    }
}