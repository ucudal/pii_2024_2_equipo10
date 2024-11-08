namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Caterpie.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Caterpie: Pokemon
{
    /// <summary>
    /// Constructor de Caterpie.
    /// </summary>
    public Caterpie():base(name: "Caterpie", life: 40, type: Library.Type.Bug, new Attack("Bug bite", Type.Bug, 1,20),new Attack("Tackle",Type.Normal,1,30),new SpecialAttack("Bug stomp", Type.Bug, 0.95,70, State.Paralized),new Attack("String shot", Type.Bug, 1,15))
    {
        
    }
}