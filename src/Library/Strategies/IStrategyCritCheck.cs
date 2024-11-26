namespace Library.Strategies;
/// <summary>
/// Esta interfaz es utilizada para poder aplicar el patrón strategy,
/// sirve para definir diferentes resultados al momento de verificar si un pokemon realizó un golpe crítico
/// </summary>
public interface IStrategyCritCheck
{
    /// <summary>
    /// Este método se encarga de definir como va a funcionar esta estrategia, cada estrategia implementa su propia funcionalidad
    /// </summary>
    /// <returns>Un valor <c>double</c> determinando si el golpe fue crítico o no</returns>
    public double CriticalCheck();
}


