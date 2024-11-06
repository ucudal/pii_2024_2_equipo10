namespace Library;
using Library;

public class Player
{
    public string  Name { get; }
    public List<Pokemon> PokemonTeam { get; private set;}
    public List<IItem> Items { get; private set;}
    public Pokemon ActivePokemon { get; private set; }

    public Player(string name)
    {
        this.Name = name;
        this.PokemonTeam = new List<Pokemon>();
        this.Items = new List<IItem>();
        this.Items.Add(new Revive());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new FullHealth());
        this.Items.Add(new FullHealth());
    }
    
    public IAction ChooseAction()
    {
        // mostrar movimientos en pantalla, podría llamar a otra
        // clase para imprimir en pantalla las opciones
        //obtengo la selección del usuario, por ejemplo le pido un int
        // x=0
        // if (x < 5)
        // {
        //     return this.ActivePokemon.Moves[x - 1];
        // }
        // else 
        // {
        //     IAction action = new Pokeball();
        //     return action;
        // }
        
        IAction action = new Pokeball();
        return action;
    }

    public void AddToTeam(Pokemon pokemon)
    {
        if (this.PokemonTeam.Count < 6)
        {
            this.PokemonTeam.Add(pokemon);
        }
    }
    
    public void ChangeActivePokemon(Pokemon pokemon)
    {
        this.ActivePokemon = pokemon;
    }
}
