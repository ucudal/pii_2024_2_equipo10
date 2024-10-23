namespace Library;
// Clase experta encargada de mostrar el catálogo disponible

public class PokemonCatalogue
{
    public List<IPokemon> PokemonList { get; private set; }

    public void ShowCatalogue()
    {
        foreach (IPokemon pokemon in PokemonList)
        {
            Console.WriteLine(pokemon.Name);
        }
    }

    public PokemonCatalogue()
    {
        //Aplicamos Creator
        this.PokemonList = new List<IPokemon>();
        IPokemon charizard = new Charizard();
        this.PokemonList.Add(charizard);
    }
    
}