namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Chikorita.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Jigglypuff : Pokemon
{
    /// <summary>
    /// Constructor de Chikorita, implementa el patron GRASP creator.
    /// </summary>
    public Jigglypuff():base(name: "Jigglypuff", life: 280, type: Type.Normal,new Attack("Disarming Voice",Type.Normal,
        1.00,40),new Attack("Pound", Type.Normal,0.95,45),new SpecialAttack
        ("Rest",Type.Psychic,0.95,30,State.Asleep), new Attack("Covet",Type.Normal,0.9,50))
    {
        
    }
    
    public override Pokemon Instance()
    {
        return new Jigglypuff();
    }
}