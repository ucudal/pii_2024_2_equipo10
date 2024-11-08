namespace Library;

/// <summary>
/// Esta clase representa el catalogo de Pokemons.
/// </summary>
public static class PokemonCatalogue
{
    /// <summary>
    /// Lista de Pokemons.
    /// </summary>
    private static List<Pokemon> PokemonList { get; set; }
    
    /// <summary>
    /// Devuelve el nombre de todos los Pokemons en el catalogo. 
    /// </summary>
    /// <returns></returns>
    public static string ShowCatalogue()
    {
        List<Pokemon> pokedex = SetCatalogue();
        string pokemonsAvailable = "";
        foreach (Pokemon pokemon in pokedex)
        {
            pokemonsAvailable += pokemon.Name +"\n";
        }
        return pokemonsAvailable;
    }

    /// <summary>
    /// Inicialia el catalogo.
    /// </summary>
    /// <returns>Devuelve la lista con los Pokemons creados.</returns>
    public static List<Pokemon> SetCatalogue()
    {
        Charizard charizard = new Charizard();
        Chikorita chikorita = new Chikorita();
        Gengar gengar = new Gengar();
        Caterpie caterpie = new Caterpie();
        List<Pokemon> list = new List<Pokemon>();
        list.Add(charizard);
        list.Add(caterpie);
        list.Add(chikorita);
        list.Add(gengar);
        list.Add(charizard);
        PokemonList = list;
        return PokemonList;
    }
    
}