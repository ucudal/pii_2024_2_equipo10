namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Mewtwo.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Mewtwo: Pokemon
{
    /// <summary>
    /// Constructor de Mewtwo, implementa el patron GRASP creator.
    /// </summary>
    public Mewtwo() : base(name: "Mewtwo", life: 416, type: Type.Psychic, new Attack("Shadow Ball", Type.Ghost, 1, 60),
        new Attack("Psystrike", Type.Psychic, 1, 100), new Attack("Mental Shock", Type.Psychic, 0.75, 100),
        new Attack("Drain Punch", Type.Fighting, 0.95, 80))
    {
    }
    
    /// <summary>
    /// Este método retorna una copia del pokemon aplicando así, el patrón prototype.
    /// </summary>
    /// <returns><c>Pokemon</c> del subtipo <c>Mewtwo</c></returns>
    public override Pokemon Instance()
    {
        return new Mewtwo();
    }
}
