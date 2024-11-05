namespace Library;
// Clase experta encargada de mostrar el catálogo disponible

public class PokemonCatalogue
{
    public List<Pokemon> PokemonList { get; private set; }

    public void ShowCatalogue()
    {
        foreach (Pokemon pokemon in PokemonList)
        {
            Console.WriteLine(pokemon.Name);
        }
    }

    public PokemonCatalogue()
    {
        //Aplicamos Creator
        this.PokemonList = new List<Pokemon>();
        Charizard charizard = new Charizard();
        this.PokemonList.Add(charizard);
    }
    
}