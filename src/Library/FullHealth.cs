namespace Library;

/// <summary>
/// Esta clase representa el item FullHealth.
/// Al ser un item implementa la interfaz <see cref="IItem"/>.
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
    public string? Use(Pokemon? pokemon)
    {
        if (pokemon != null)
        {
            if (pokemon.CurrentState == null)
            {
                return $"{pokemon.Name} no tiene ningún estado negativo";
            }
            pokemon.EditState(null);
            return $"{pokemon.Name} ya no tiene ningún estado negativo.";
        }
        return null;
    }

    /// <summary>
    /// Contructor de <see cref="FullHealth"/>
    /// </summary>
    public FullHealth()
    {
        this.Name = "Full Health";
    }
    
}