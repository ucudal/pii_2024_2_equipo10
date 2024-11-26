namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Hydreigon.
/// Al ser un Pokemon hereda de la clase <see cref="Pokemon"/>.
/// </summary>
public class Hydreigon : Pokemon
{
    /// <summary>
    /// Constructor de Hydreigon, implementa el patron GRASP creator.
    /// </summary>
    public Hydreigon() : base("Hydreigon",life: 388,type: Type.Dragon, new Attack("Surf", Type.Water,1,80), new Attack("Draco meteor", Type.Dragon,0.80,110), new Attack("Focus Blast", Type.Fighting,0.75,120), new SpecialAttack("Fire Blast",Type.Fire,0.85,100,State.Burned))
    {
    }

    /// <summary>
    /// Este método retorna una copia del pokemon aplicando así, el patrón prototype.
    /// </summary>
    /// <returns><c>Pokemon</c> del subtipo <c>Hydreigon</c></returns>
    public override Pokemon Instance()
    {
        return new Hydreigon();
    }
}