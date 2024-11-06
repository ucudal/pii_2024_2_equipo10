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

    public string ExecuteAttack(Attack attack)
    {
        bool asleep = StateLogic.AsleepEffect(players[ActivePlayer].ActivePokemon);
        bool paralized = StateLogic.ParalizedEffect(players[ActivePlayer].ActivePokemon);
        if (!asleep & !paralized)
        {
            Pokemon attackedPokemon = this.players[(this.ActivePlayer + 1) % 2].ActivePokemon;
            double damage = DamageCalculator.CalculateDamage(attackedPokemon, attack);
            attackedPokemon.TakeDamage(damage);
            return $"{attackedPokemon} recibió {damage} puntos de daño";
        }
        else return $"{this.players[ActivePlayer].ActivePokemon} está {this.players[ActivePlayer].ActivePokemon.CurrentState}";
    }


    public string UseItem(IItem item, Pokemon pokemon)
    {
        if (item == null)
        {
            return "Ese item no está en tu inventario.";
        }

        if (pokemon == null)
        {
            return "Ese Pokemon no está en tu equipo.";
        }

        return item.Use(pokemon);
    }

    public string ChangePokemon(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            return "Ese Pokemon no está en tu equipo.";
        }
        this.players[ActivePlayer].SetActivePokemon(pokemon);
        return $"{pokemon.Name} es tu nuevo Pokemon activo.";
    }
    
}