namespace Library;
// Clase experta encargada de mostrar el catálogo disponible

public static class PokemonCatalogue
{
    private static List<Pokemon> PokemonList { get; set; }

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