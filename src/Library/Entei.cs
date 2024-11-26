namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Entei.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Entei : Pokemon
{
    /// <summary>
    /// Constructor de Entei, implementa el patron GRASP creator.
    /// </summary>
    public Entei():base(name: "Entei", life: 490, type: Type.Fire,new Attack("Ember",Type.Fire,
        1.00,40),new Attack("Stomp", Type.Normal,1.00,60),new SpecialAttack
        ("Will-O-Wisp",Type.Dragon,1.00,0,State.Burned), new Attack("Extrasensory",Type.Psychic,0.9,60))
    {
        
    }
    /// <summary>
    /// Este método retorna una copia del pokemon aplicando así, el patrón prototype.
    /// </summary>
    /// <returns><c>Pokemon</c> del subtipo <c>Entei</c></returns>
    public override Pokemon Instance()
    {
        return new Entei();
    }
}