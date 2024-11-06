
namespace Library;

public class Game
{
    public List<Player> Players {get; private set;}//Cambiar a Array
    public int ActivePlayer {get; private set;}
    public int TurnCount {get; private set;}

    public Game(Player player1, Player player2)
    {
        this.Players = new List<Player>();
        this.Players.Add(player1);
        this.Players.Add(player2);
        this.ActivePlayer = 0;
        this.TurnCount = 0;
    }
    
    public void NextTurn()
    {
        this.TurnCount++;
        this.ActivePlayer = (this.ActivePlayer + 1) % 2;
    }

    public string? ExecuteAction()
    {
            IAction action = this.Players[ActivePlayer].ChooseAction();
            if (action is Attack attack)
            {
                bool asleep = StateLogic.AsleepEffect(Players[ActivePlayer].ActivePokemon);
                bool paralized = StateLogic.ParalizedEffect(Players[ActivePlayer].ActivePokemon);
                if (!asleep & !paralized)
                {
                    this.Players[(this.ActivePlayer + 1) % 2].ActivePokemon.TakeDamage(
                        DamageCalculator.CalculateDamage(this.Players[(this.ActivePlayer + 1) % 2].ActivePokemon, attack));
                }
                else
                    return
                        $"{this.Players[ActivePlayer].ActivePokemon} is {this.Players[ActivePlayer].ActivePokemon.CurrentState}";
            }
            else if (action is Backpack backpack)
            {
            }
            else if (action is Pokeball pokeball)
            {
                pokeball.ChangePokemon(this.Players[ActivePlayer]);
            }
            return "accion no reconocida, introduzcala nuevamente";
            StateLogic.PoisonedEffect(Players[ActivePlayer].ActivePokemon);
            StateLogic.BurnedEffect(Players[ActivePlayer].ActivePokemon);

    }
    
}