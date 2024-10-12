namespace Library;
// Clase experta encargada de mostrar el catálogo disponible

public class PokemonCatalogue
{
    public List<IPokemon> PokemonList { get; private set; }

    public void ShowCatalogue()
    {
        Console.WriteLine(PokemonList[0].Name);
    }

    public PokemonCatalogue()
    {
        //Aplicamos Creator
        this.PokemonList = new List<IPokemon>();
        IPokemon charizard = new Charizard();
        this.PokemonList.Add(charizard);
    }
    
}