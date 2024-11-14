namespace Library;

/// <summary>
/// Esta clase representa el catálogo de Pokemons.
/// </summary>
public class PokemonCatalogue
{
    /// <summary>
    /// Lista de Pokemons.
    /// </summary>
    public List<Pokemon> PokemonList { get; private set; } = new List<Pokemon>();
    
    /// <summary>
    /// Cantidad de Pokemons en el catálogo
    /// </summary>
    public int PokemonCount
    {
        get { return this.PokemonList.Count; }
    }

    /// <summary>
    /// Instancia del catálogo.
    /// </summary>
    private static PokemonCatalogue? _instance;

    /// <summary>
    /// Crea las instancias de los Pokemons y los agrega a la lista.
    /// </summary>
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
    
    /// <summary>
    /// Crea una instancia del catálogo si no existe una.
    /// </summary>
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