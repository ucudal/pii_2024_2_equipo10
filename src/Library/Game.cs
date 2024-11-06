namespace Library;

public class Game
{
    public List<Player> Players { get; private set; } = new List<Player> ();
    public int ActivePlayer { get; private set; }
    public int TurnCount { get; private set; }

    public Game(Player player1, Player player2)
    {
        this.Players.Add(player1);
        this.Players.Add(player2);
        this.ActivePlayer = 0;
        this.TurnCount = 0;
    }

    public bool OngoingGameCheck()
    {
        foreach (var player in Players)
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
        foreach (var player in Players)
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
        bool asleep = StateLogic.AsleepEffect(Players[ActivePlayer].ActivePokemon);
        bool paralized = StateLogic.ParalizedEffect(Players[ActivePlayer].ActivePokemon);
        if (!asleep & !paralized)
        {
            Pokemon attackedPokemon = this.Players[(this.ActivePlayer + 1) % 2].ActivePokemon;
            double damage = DamageCalculator.CalculateDamage(attackedPokemon, attack);
            attackedPokemon.TakeDamage(damage);
            return $"{attackedPokemon} recibió {damage} puntos de daño";
        }
        else return $"{this.Players[ActivePlayer].ActivePokemon} está {this.Players[ActivePlayer].ActivePokemon.CurrentState}";
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
        this.Players[ActivePlayer].SetActivePokemon(pokemon);
        return $"{pokemon.Name} es tu nuevo Pokemon activo.";
    }
    
}