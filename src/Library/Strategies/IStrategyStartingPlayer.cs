namespace Library.Strategies;
/// <summary>
/// Esta interfaz es utilizada para poder aplicar el patrón strategy,
/// sirve para definir diferentes resultados al momento de verificar que jugador va a tener el primer turno
/// </summary>
public interface IStrategyStartingPlayer
{
    /// <summary>
    /// Este método se encarga de definir como va a funcionar esta estrategia, cada estrategia implementa su propia funcionalidad
    /// </summary>
    /// <returns>Un valor <c>int</c> que va a ser usado como índice de la lista de jugadores para determinar que jugador tiene el primer turno</returns>
    public int StartingPlayer();
}