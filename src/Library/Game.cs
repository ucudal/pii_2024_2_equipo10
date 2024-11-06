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

    public bool OngoingGameCheck()
    {
        foreach (var player in players)
        {
            bool Ongoing = false;
            foreach (var pokemon in player.PokemonTeam)
            {
                if (pokemon.CurrentLife > 0)
                {
                    Ongoing = true;
                }
            }
            if (!Ongoing)
            {
                return false;
            }
        }
        return true;
    }

    public void CooldownCheck()
    { 
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
    }

    public void NextTurn()
    {
        if (OngoingGameCheck())
        {
           this.TurnCount++;
           CooldownCheck();          
           this.ActivePlayer = (this.ActivePlayer + 1) % 2;
        }
    }

    public void ExecuteAttack()
    {
        
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
            else return $"{this.players[ActivePlayer].ActivePokemon} is {this.players[ActivePlayer].ActivePokemon.CurrentState}";
        }
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

    public void MenuCambioPokemon()
    {
        
            int n = 1;
            Console.WriteLine($"Que pokemon va a luchar?:");
            foreach (var pokemon in this.players[ActivePlayer].PokemonTeam)
            {
                Console.WriteLine($"{n}) {pokemon.Name}");
                n++;
            }
            while (true)
            {
                Console.Write(">");
                int R = Convert.ToInt32(Console.ReadLine());//posible error si se ingresa str
                if (R > 1 && R <= n)
                {
                    this.players[ActivePlayer].ChangeActivePokemon(players[ActivePlayer].PokemonTeam[R - 1]);
                    return;
                }
                else
                {
                    Console.WriteLine("Opcion invalida");
                }
            }
        

    }
    
}