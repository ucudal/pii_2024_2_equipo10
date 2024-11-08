namespace Library;

/// <summary>
/// Interfaz de Ataque. Creada para subir la cohesión y bajar el acoplamiento.
/// </summary>
public interface IAttack
{ 
    /// <summary>
    /// Nombre del ataque.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Tipo del ataque.
    /// </summary>
    public Type Type {get;}
    public double Accuracy {get;}

}