namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Chikorita.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Scyther : Pokemon
{
    /// <summary>
    /// Constructor de Chikorita, implementa el patron GRASP creator.
    /// </summary>
    public Scyther():base(name: "Scyther", life: 460, type: Type.Bug,new Attack("Quick Attack",Type.Normal,
        0.9,35),new Attack("Fury cutter", Type.Bug,0.95,40),new SpecialAttack
        ("Air Slash",Type.Flying,0.85,60,State.Paralized), new Attack("Slash",Type.Normal,0.95,50))
    {
        
    }
    
    public override Pokemon Instance()
    {
        return new Scyther();
    }
}