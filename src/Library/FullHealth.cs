namespace Library;

/// <summary>
/// Esta clase representa una curación.
/// </summary>
public class FullHealth : IItem
{
    /// <summary>
    /// Nombre de la curación.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Le quita cualquier estado negativo al Pokemon.
    /// </summary>
    /// <param name="pokemon">Pokemón a ser curado.</param>
    /// <returns>El pokemon ya no tiene estado negativo.</returns>
    public string Use(Pokemon pokemon)
    {
        pokemon.EditState(null);
        return $"{pokemon} ya no tiene ningún estado negativo.";
    }
}