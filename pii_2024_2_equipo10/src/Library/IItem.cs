namespace Library;

/// <summary>
/// Interfaz de Item. Creada para subir la cohesión y bajar el acoplamiento.
/// </summary>
public interface IItem
{
    /// <summary>
    /// Nombre del item
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Utiliza el item sobre un pokemon.
    /// </summary>
    /// <param name="pokemon">Pokemon en el que se usará el item</param>
    /// <returns>Resultado.</returns>
    string Use(Pokemon pokemon);
}