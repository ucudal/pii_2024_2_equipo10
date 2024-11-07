namespace Library;

/// <summary>
/// Esta clase representa la posión Revivir.
/// </summary>
public class Revive : IItem
{
    /// <summary>
    /// Nombre del item.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Revive al Pokemon asignando a su vida actual la mitad de la vida base,
    /// si está vivo no se revive.
    /// </summary>
    /// <param name="pokemon"></param>
    /// <returns>Si fue revivido o no.</returns>
    public string Use(Pokemon pokemon)
    {
        pokemon.CurrentLife = (pokemon.BaseLife / 2);
        return $"{pokemon} ha revivido.";
    }
}