namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Haxorus.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Haxorus: Pokemon
{
    /// <summary>
    /// Constructor de Haxorus, implementa el patron GRASP creator.
    /// </summary>
    public Haxorus():base(name: "Haxorus", life: 356, type: Type.Dragon, new Attack("Outrage",Type.Dragon,0.75,120),new Attack("Assurance", Type.Normal,0.95,80), new Attack("Close Combat", Type.Fighting, 0.75,120) ,new Attack("Dragon claw", Type.Dragon, 1,55)) 
    { 
    }
    
    public override Pokemon Instance()
    {
        return new Haxorus();
    }
    
}