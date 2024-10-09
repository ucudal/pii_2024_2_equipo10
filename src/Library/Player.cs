namespace Library;
using Library;

public class Player
{
    public string  Name;
    public List<IPokemon> PokemonTeam { get; set;} =  new List<IPokemon> ();
    IPokemon ActivePokemon;

    public IAction ChooseAction()
    {

    }

    public void AddToTeam(IPokemon pokemon)
    {

    }

    public void ChoosePokemon()
    {

    }
}
