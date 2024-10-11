namespace Library;
using Library;

public class Player
{
    public string  Name { get; }
    public List<IPokemon> PokemonTeam { get; set;} =  new List<IPokemon> ();
    public IPokemon ActivePokemon { get; private set; }

    public Player(string name)
    {
        this.Name = name;
    }
    
    public IAction ChooseAction()
    {
        // mostrar movimientos en pantalla, podría llamar a otra
        // clase para imprimir en pantalla las opciones
        int x = 0;//obtengo la selección del usuario, por ejemplo le pido un int
        if (x < 5)
        {
            return this.ActivePokemon.Moves[x - 1];
        }
        else 
        {
            IAction action = new Pokeball();
            return action;;
        }
        
    }

    public void AddToTeam(IPokemon pokemon)
    {
        if(this.PokemonTeam.Count < 6)
            this.PokemonTeam.Add(pokemon);
    }

    public void ChangeActivePokemon(IPokemon pokemon)
    {
        this.ActivePokemon = pokemon;
    }
}
