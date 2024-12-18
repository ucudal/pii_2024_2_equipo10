namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Charizard.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Charizard : Pokemon
{
    /// <summary>
    /// Constructor de Charizard, implementa el patron GRASP creator.
    /// </summary>
    public Charizard():base(name: "Charizard", life: 360, type: Type.Fire, new Attack("Dragon claw",Type.Dragon,1,55000),new SpecialAttack("Flamethrower",Type.Fire,1,75, State.Burned), new Attack("Wing Attack",Type.Flying,1,40), new Attack("Fire punch",Type.Fire,1,50))
    {
        
    }
    /// <summary>
    /// Este método retorna una copia del pokemon aplicando así, el patrón prototype.
    /// </summary>
    /// <returns><c>Pokemon</c> del subtipo <c>Charizard</c></returns>
    public override Pokemon Instance()
    {
        return new Charizard();
    }
}