namespace Library;

/// <summary>
/// Esta clase representa la Super Posión
/// </summary>
public class SuperPotion : IItem
{
    /// <summary>
    /// Nombre del item.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Suma 70 HP a la vida actual del Pokemon.
    /// </summary>
    /// <param name="pokemon">Pokemon al que se le aplicará la posión</param>
    /// <returns>
    /// Devuelve si el Pokemon fue curado o no.
    /// </returns>
    public string Use(Pokemon pokemon)
    { 
        pokemon.GainLife(70);
        return $"{pokemon} ha ganado 70HP.";
    }
}