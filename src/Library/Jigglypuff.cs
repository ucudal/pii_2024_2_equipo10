namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Jigglypuff.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Jigglypuff : Pokemon
{
    /// <summary>
    /// Constructor de Jigglypuff, implementa el patron GRASP creator.
    /// </summary>
    public Jigglypuff():base(name: "Jigglypuff", life: 280, type: Type.Normal,new Attack("Disarming Voice",Type.Normal,
        1.00,40),new Attack("Pound", Type.Normal,0.95,45),new SpecialAttack
        ("Rest",Type.Psychic,0.95,30,State.Asleep), new Attack("Covet",Type.Normal,0.9,50))
    {
        
    }
    
    /// <summary>
    /// Este método retorna una copia del pokemon aplicando así, el patrón prototype.
    /// </summary>
    /// <returns><c>Pokemon</c> del subtipo <c>Jigglypuff</c></returns>
    public override Pokemon Instance()
    {
        return new Jigglypuff();
    }
}