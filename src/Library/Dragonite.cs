namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Dragonite.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Dragonite : Pokemon
{
    /// <summary>
    /// Constructor de Dragonite, implementa el patron GRASP creator.
    /// </summary>
    public Dragonite():base(name: "Dragonite", life: 460, type: Type.Dragon,new Attack("Wing Attack",Type.Flying,
        1.00,60),new Attack("Slam", Type.Normal,0.75,80),new SpecialAttack
        ("Twister",Type.Dragon,1.00,40,State.Paralized), new Attack("Wrap",Type.Normal,0.9,15))
    {
        
    }
    
    /// <summary>
    /// Este método retorna una copia del pokemon aplicando así, el patrón prototype.
    /// </summary>
    /// <returns><c>Pokemon</c> del subtipo <c>Dragonite</c></returns>
    public override Pokemon Instance()
    {
        return new Dragonite();
    }
}