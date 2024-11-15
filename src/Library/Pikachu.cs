namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Pikachu.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Pikachu : Pokemon
{
    /// <summary>
    /// Constructor de Pikachu, implementa el patron GRASP creator.
    /// </summary>
    public Pikachu():base(name: "Pikachu", life: 295, type: Type.Electric,new Attack("Quick Attack",Type.Normal,
        1.00,40),new Attack("Spark", Type.Electric,0.95,65),new SpecialAttack
        ("Thunder Shock",Type.Electric,1.00,40,State.Paralized), new Attack("Nuzzle",Type.Electric,1,20))
    {
        
    }
    
    public override Pokemon Instance()
    {
        return new Pikachu();
    }
}