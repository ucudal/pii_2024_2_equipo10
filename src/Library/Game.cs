
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
    } 

    public void ExecuteAction()
    {
        IAction action = this.players[ActivePlayer].ChooseAction();
        if (action is DamageMove damageMove)
        {
            this.players[(this.ActivePlayer + 1) % 2].ActivePokemon.TakeDamage(DamageCalculator.CalculateDamage(this.players[this.ActivePlayer].ActivePokemon,this.players[(this.ActivePlayer + 1) % 2].ActivePokemon, damageMove));
        }
        else if (action is StatsChangerMove statsChangerMove)
        {
            if (statsChangerMove.StatBuff == "Attack")
            {
                this.players[this.ActivePlayer].ActivePokemon.BuffAttack(statsChangerMove.Buff);
            }
            else if (statsChangerMove.StatBuff == "Defense")
            {
                this.players[this.ActivePlayer].ActivePokemon.BuffDefense(statsChangerMove.Buff);
            }
        }
        else if (action is Pokeball pokeball)
        {
            pokeball.ChangePokemon(this.players[ActivePlayer]);
        }
        
    }
}