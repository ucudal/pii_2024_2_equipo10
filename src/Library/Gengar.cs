namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Gengar.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Gengar : Pokemon
{
    /// <summary>
    /// Constructor de Gengar.
    /// </summary>
    public Gengar():base(name: "Gengar", life: 324, type: Type.Ghost, new Attack("Shadow Ball",Type.Ghost,1,60),new SpecialAttack("Sludge Bomb", Type.Poison,0.95,70,State.Poisoned), new Attack("Shadow Punch", Type.Ghost, 0.75,100),new Attack("Focus Punch", Type.Normal, 0.45,155))
    {
        
    }
}