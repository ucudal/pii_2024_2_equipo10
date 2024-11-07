namespace Library;

/// <summary>
/// Esta clase representa una partida entre dos jugadores.
/// </summary>
public class Game
{
    /// <summary>
    /// Obtiene la lista de los jugadores de la partida.
    /// </summary>
    private List<Player> Players { get; set; } = new List<Player> ();
    
    /// <summary>
    /// Obtiene el valor del índice del jugador activo de la partida.
    /// </summary>
    public int ActivePlayer { get; private set; }
    
    /// <summary>
    /// Obtiene la cantidad de turnos que lleva la partida.
    /// </summary>
    public int TurnCount { get; private set; }

    public Game(Player player1, Player player2)
    {
        this.Players.Add(player1);
        this.Players.Add(player2);
        this.ActivePlayer = Random0or1();
        this.TurnCount = 0;
    }

    /// <summary>
    /// Obtiene la lista de jugadores de la partida.
    /// </summary>
    public List<Player> GetPlayers()
    {
        return Players;
    }

    /// <summary>
    /// Obtiene un valor aleatorio entre 0 y 1.
    /// </summary>
    /// <returns><c>int</c> Valor entre 0 y 1.</returns>
    public int Random0or1()
    {
        Random random = new Random();
        return random.Next(0, 2);
    }
    
    /// <summary>
    /// Verifica si el juego sigue en curso evaluando el nivel de vida de cada Pokemon para ambos jugadores.
    /// </summary>
    /// <returns> <c>true</c> si al menos un jugador tiene un Pokemon con vida en su equipo.
    /// <c>false</c> si ningún jugador tiene ningún Pokemon con vida.</returns>
    public bool GameStatus()
    {
        foreach (var player in Players)
        {
            bool ongoing = false;
            foreach (var pokemon in player.GetPokemonTeam())
            {
                if (pokemon.CurrentLife > 0)
                {
                    ongoing = true;
                }
            }
            if (!ongoing)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determina el ganador y el perdedor del juego basándose en la cantidad de vida de los Pokemon de cada jugador.
    /// </summary>
    /// <returns> <c>string</c> indicando al ganador y al perdedor de la partida. </returns>
    public string Winner()
    {
        int winner = 0;
        foreach (var pokemon in Players[1].GetPokemonTeam())
        {
            if (pokemon.CurrentLife > 0)
            {
                winner = 1;
            }
        }

        int loser = (winner + 1) % 2;
        return $"Ganador: {Players[winner]}. Perdedor: {Players[loser]}";

    }

    public void CooldownCheck()
    { 
        foreach (var player in Players)
        {
            foreach (var pokemon in player.GetPokemonTeam())
            {
                foreach (var attack in pokemon.GetAttacks())
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
        if (GameStatus())
        {
           this.TurnCount++;
           CooldownCheck();          
           this.ActivePlayer = (this.ActivePlayer + 1) % 2;
        }
    }

    public string ExecuteAttack(Attack attack)
    {
        if (attack != null)
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

        return null;
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