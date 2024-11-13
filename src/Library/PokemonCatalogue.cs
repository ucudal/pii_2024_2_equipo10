namespace Library;

/// <summary>
/// Esta clase representa el catálogo de Pokemons.
/// </summary>
public class PokemonCatalogue
{
    /// <summary>
    /// Lista de Pokemons.
    /// </summary>
    private List<Pokemon> PokemonList { get; set; } = new List<Pokemon>();

    private static PokemonCatalogue? _instance;

    private PokemonCatalogue()
    {
        Charizard charizard = new Charizard();
        Chikorita chikorita = new Chikorita();
        Gengar gengar = new Gengar();
        Caterpie caterpie = new Caterpie();
        Mewtwo mewtwo = new Mewtwo();
        Zeraora zeraora = new Zeraora();
        Haxorus haxorus = new Haxorus();
        PokemonList.Add(caterpie);
        PokemonList.Add(chikorita);
        PokemonList.Add(gengar);
        PokemonList.Add(charizard);
        PokemonList.Add(mewtwo);
        PokemonList.Add(zeraora);
        PokemonList.Add(haxorus);
    }

    public static PokemonCatalogue Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PokemonCatalogue();
            }

            return _instance;
        }
    }
    
    /// <summary>
    /// Devuelve el nombre de todos los Pokemons en el catálogo. 
    /// </summary>
    /// <returns></returns>
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