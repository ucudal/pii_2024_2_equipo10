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

    public void Reset()
    {
        _instance = null;
    }
    
    /// <summary>
    /// Instancia del catálogo.
    /// </summary>
    private static PokemonCatalogue? _instance;

    
    private Dictionary<string, Type> PossibleTypes { get; }

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
        Type fire = Type.Fire;
        Type water = Type.Water;
        Type grass = Type.Grass;
        Type electric = Type.Electric;
        Type ground = Type.Ground;
        Type bug = Type.Bug;
        Type dragon = Type.Dragon;
        Type fighting = Type.Fighting;
        Type flying = Type.Flying;
        Type ghost = Type.Ghost;
        Type ice = Type.Ice;
        Type normal = Type.Normal;
        Type poison = Type.Poison;
        Type psychic = Type.Psychic;
        Type rock = Type.Rock;
        PossibleTypes = new Dictionary<string, Type>();
        PossibleTypes.Add("Fire", fire);
        PossibleTypes.Add("Water", water);
        PossibleTypes.Add("Grass", grass);
        PossibleTypes.Add("Electric", electric);
        PossibleTypes.Add("Ground", ground);
        PossibleTypes.Add("Bug", bug);
        PossibleTypes.Add("Dragon", dragon);
        PossibleTypes.Add("Fighting", fighting);
        PossibleTypes.Add("Flying", flying);
        PossibleTypes.Add("Ghost", ghost);
        PossibleTypes.Add("Ice", ice);
        PossibleTypes.Add("Normal", normal);
        PossibleTypes.Add("Poison", poison);
        PossibleTypes.Add("Psychic", psychic);
        PossibleTypes.Add("Rock", rock);
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

    public void Remove(Pokemon pokemon)
    {
        PokemonList.Remove(pokemon);
    }

    public bool CheckPokemonTypes(Type? pokemonType)
    {
        foreach (Pokemon pokemon in PokemonList)
        {
            foreach (Type type in pokemon.GetTypes())
            {
                if (type == pokemonType)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckPokemonInCatalogue(Pokemon playerPokemon)
    {
        foreach (Pokemon pokemon in PokemonList)
        {
            if (pokemon.Name == playerPokemon.Name)
            {
                return true;
            }
        }
        return false;
    }

    public Pokemon? FindPokemonByName(string pokemonName)
    {
        foreach (Pokemon pokemon in PokemonList)
        {
            if (pokemon.Name == pokemonName)
            {
                return pokemon;
            }
        }
        return null;
    }

    public Type? GetPossibleTypes(string pType)
    {
        if (PossibleTypes.ContainsKey(pType))
        {
            return PossibleTypes[pType];
        }
        return null;
    }
}