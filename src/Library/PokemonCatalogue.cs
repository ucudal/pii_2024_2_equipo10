namespace Library;
// Clase experta encargada de mostrar el catálogo disponible

public class PokemonCatalogue
{
    public List<Pokemon> PokemonList { get; private set; }

    public string ShowCatalogue()
    {
        string pokemonsAvailable = "";
        foreach (Pokemon pokemon in PokemonList)
        {
            pokemonsAvailable += pokemon.Name +"\n";
        }
        return pokemonsAvailable;
    }

    public PokemonCatalogue()
    {
        //Aplicamos Creator
        this.PokemonList = new List<Pokemon>();
        Charizard charizard = new Charizard();
        this.PokemonList.Add(charizard);
    }
    
}