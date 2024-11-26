namespace Library;

/// <summary>
/// Esta clase representa el Pokemon Chikorita.
/// Al ser un Pokemon hereda de la clase  <see cref="Pokemon"/>.
/// </summary>
public class Chikorita : Pokemon
{
    /// <summary>
    /// Constructor de Chikorita, implementa el patron GRASP creator.
    /// </summary>
    public Chikorita():base(name: "Chikorita", life: 294, type: Type.Grass,new Attack("Razor leaf",Type.Grass,0.9,35),new Attack("Magical leaf", Type.Grass,1,45),new SpecialAttack("Giga Drain",Type.Grass,0.95,70,State.Paralized), new Attack("Body slam",Type.Normal,1,55))
    {
        
    }
    
    /// <summary>
    /// Este método retorna una copia del pokemon aplicando así, el patrón prototype.
    /// </summary>
    /// <returns><c>Pokemon</c> del subtipo <c>Chikorita</c></returns>
    public override Pokemon Instance()
    {
        return new Chikorita();
    }
}