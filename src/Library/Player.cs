namespace Library;
using Library;

public class Player
{
    public string  Name;
    public List<IPokemon> PokemonTeam { get; private set;} =  new List<IPokemon> ();
    public IPokemon ActivePokemon { get; }

    public IAction ChooseAction()
    {
        // imprimir.movimientos();
        // int x = Console.Read();
        // //if
        // return this.ActivePokemon.Moves[x - 1];
        // //else
        // this.ActivePokemon = Pokeball.ChangePokemon();
        return null;
        //podría llamar a una clase para imprimir en pantalla las opciones
    }

    public void AddToTeam(IPokemon pokemon)
    {

    }

    public void ChoosePokemon()
    {

    }
}
