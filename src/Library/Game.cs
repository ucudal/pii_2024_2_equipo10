
namespace Library;

public class Game
{
    List<Player> players = new List<Player> (); //Cambiar a Array
    public int ActivePlayer;
    public int TurnCount;

    public Game(Player player1, Player player2)
    {
        this.players.Add(player1);
        this.players.Add(player2);
        this.ActivePlayer = 0;
        this.TurnCount = 0;
    }
    
    public void NextTurn()
    {
        this.TurnCount++;
        this.ActivePlayer = (this.ActivePlayer + 1) % 2;
        StateLogic.PoisonedEffect(players[ActivePlayer].ActivePokemon);
        StateLogic.BurnedEffect(players[ActivePlayer].ActivePokemon);
    }

    public string? ExecuteAction()
    {
            IAction action = this.players[ActivePlayer].ChooseAction();
            if (action is Attack attack)
            {
                bool asleep = StateLogic.AsleepEffect(players[ActivePlayer].ActivePokemon);
                bool paralized = StateLogic.ParalizedEffect(players[ActivePlayer].ActivePokemon);
                if (!asleep & !paralized)
                {
                    this.players[(this.ActivePlayer + 1) % 2].ActivePokemon.TakeDamage(
                        DamageCalculator.CalculateDamage(this.players[(this.ActivePlayer + 1) % 2].ActivePokemon, attack));
                }
                else
                    return
                        $"{this.players[ActivePlayer].ActivePokemon} is {this.players[ActivePlayer].ActivePokemon.CurrentState}";
            }
            else if (action is Backpack backpack)
            {
                
            }
            else if (action is Pokeball pokeball)
            {
                pokeball.ChangePokemon(this.players[ActivePlayer]);
            }

            return "accion no reconocida, introduzcala nuevamente";
    }
    
}