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
        foreach (var player in players)
        {
            foreach (var pokemon in player.PokemonTeam)
            {
                foreach (var attack in pokemon.Attacks)
                {
                    if (attack is SpecialAttack specialAttack)
                    {
                        specialAttack.LowerCooldown();
                    }
                }
            }
        }
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
                return  $"{this.Players[ActivePlayer].ActivePokemon} is {this.Players[ActivePlayer].ActivePokemon.CurrentState}";
        }
        else return $"{this.players[ActivePlayer].ActivePokemon} is {this.players[ActivePlayer].ActivePokemon.CurrentState}";
        
        else if (action is Backpack backpack)
        {
            
        }

        else if (action is Pokeball pokeball)
        {
            pokeball.ChangePokemon(this.players[ActivePlayer]);
        }
        return "accion no reconocida, introduzcala nuevamente";
        StateLogic.PoisonedEffect(players[ActivePlayer].ActivePokemon);
        StateLogic.BurnedEffect(players[ActivePlayer].ActivePokemon);

    }

    
}