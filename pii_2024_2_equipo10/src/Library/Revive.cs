namespace Library;

/// <summary>
/// Esta clase representa el item Revive.
/// Al ser un item implementa la interfaz <see cref="IItem"/>.
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
        if (pokemon.CurrentLife > 0)
        {
            return "El pokemon no está debilitado";
        }
        pokemon.CurrentLife = (pokemon.BaseLife / 2);
        return $"{pokemon.Name} ha revivido.";
    }
    /// <summary>
    /// Constructor de <see cref="Revive"/>
    /// </summary>
    public Revive()
    {
        this.Name = "Revive";
    }
    
}