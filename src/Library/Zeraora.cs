namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Zeraora.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Zeraora: Pokemon
{
    /// <summary>
    /// Constructor de Zeraora, implementa el patron GRASP creator.
    /// </summary>
    public Zeraora() : base(name: "Zeraora", life: 380, type: Type.Electric,
        new Attack("Plasma Fist", Type.Electric, 1, 65),
        new SpecialAttack("Thunderbolt", Type.Electric, 1, 75, State.Paralized),
        new Attack("Close Combat", Type.Fighting, 0.75, 120), new Attack("Wild Charge", Type.Electric, 0.6, 160))
    {

    }
}