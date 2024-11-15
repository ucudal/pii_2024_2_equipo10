namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Chikorita.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Dragonite : Pokemon
{
    /// <summary>
    /// Constructor de Chikorita, implementa el patron GRASP creator.
    /// </summary>
    public Dragonite():base(name: "Dragonite", life: 460, type: Type.Dragon,new Attack("Wing Attack",Type.Flying,
        1.00,60),new Attack("Slam", Type.Normal,0.75,80),new SpecialAttack
        ("Twister",Type.Dragon,1.00,40,State.Paralized), new Attack("Wrap",Type.Normal,0.9,15))
    {
        
    }
    
    public override Pokemon Instance()
    {
        return new Dragonite();
    }
}