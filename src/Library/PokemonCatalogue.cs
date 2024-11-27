namespace Library;

/// <summary>
/// Esta clase representa el catálogo de Pokemons.
/// </summary>
public class PokemonCatalogue
{
    /// <summary>
    /// Lista de Pokemons.
    /// </summary>
    public List<Pokemon> PokemonList { get; } = new List<Pokemon>();
    
    /// <summary>
    /// Cantidad de Pokemons en el catálogo
    /// </summary>
    public int PokemonCount
    {
        get { return this.PokemonList.Count; }
    }
    
    /// <summary>
    /// Crea las instancias de los Pokemons y los agrega a la lista.
    /// </summary>
    public PokemonCatalogue()
    {
        Charizard charizard = new Charizard();
        Chikorita chikorita = new Chikorita();
        Gengar gengar = new Gengar();
        Caterpie caterpie = new Caterpie();
        Mewtwo mewtwo = new Mewtwo();
        Zeraora zeraora = new Zeraora();
        Haxorus haxorus = new Haxorus();
        Hydreigon hydreigon = new Hydreigon();
        Gastrodon gastrodon = new Gastrodon();
        Entei entei = new Entei();
        Dragonite dragonite = new Dragonite();
        Jigglypuff jigglypuff = new Jigglypuff();
        Pikachu pikachu = new Pikachu();
        Scyther scyther = new Scyther();
        PokemonList.Add(caterpie);
        PokemonList.Add(chikorita);
        PokemonList.Add(gengar);
        PokemonList.Add(charizard);
        PokemonList.Add(mewtwo);
        PokemonList.Add(zeraora);
        PokemonList.Add(haxorus);
        PokemonList.Add(hydreigon);
        PokemonList.Add(gastrodon);
        PokemonList.Add(entei);
        PokemonList.Add(dragonite);
        PokemonList.Add(jigglypuff);
        PokemonList.Add(pikachu);
        PokemonList.Add(scyther);

    }
    
    
    /// <summary>
    /// Devuelve el nombre de todos los Pokemons en el catálogo. 
    /// </summary>
    /// <returns><c>string</c></returns>
    public string ShowCatalogue()
    {
        string pokemonsAvailable = "";
        foreach (Pokemon pokemon in this.PokemonList)
        {
            pokemonsAvailable += pokemon.Name +"\n";
        }
        return pokemonsAvailable;
    }

    
}