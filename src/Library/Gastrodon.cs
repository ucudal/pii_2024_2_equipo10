namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Gastrodon.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Gastrodon : Pokemon
{
    /// <summary>
    /// Constructor de Gastrodon, implementa el patron GRASP creator.
    /// </summary>
    public Gastrodon():base(name: "Gastrodon",life: 426, type: Type.Water, new SpecialAttack("Scald",Type.Water,0.95,90,State.Burned), new Attack("Earthquake", type: Type.Ground,0.80,120), new Attack("Ice beam", Type.Ice, 1,70), new SpecialAttack("Sludge Bomb", Type.Poison,0.95,70,State.Poisoned))
    {
    }
    
    /// <summary>
    /// Este método retorna una copia del pokemon aplicando así, el patrón prototype.
    /// </summary>
    /// <returns><c>Pokemon</c> del subtipo <c>Gastrodon</c></returns>
    public override Pokemon Instance()
    {
        return new Gastrodon();
    }
    
}