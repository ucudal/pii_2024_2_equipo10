namespace Library;

/// <summary>
/// Esta clase representa el item SuperPotion.
/// Al ser un item implementa la interfaz <see cref="IItem"/>.
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
        if (pokemon != null)
        {
            if (pokemon.CurrentLife == pokemon.BaseLife)
            {
                return $"{pokemon.Name} ya tiene su vida completa.";
            }
            pokemon.GainLife(70);
            return $"{pokemon.Name} ha ganado 70HP."; 
        }
        return null;
    }
    /// <summary>
    /// Constructor de <see cref="SuperPotion"/>
    /// </summary>
    public SuperPotion()
    {
        this.Name = "Super Potion";
    }
}