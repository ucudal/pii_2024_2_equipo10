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

    /// <summary>
    /// Constructor de la clase. Agrega a los jugadores a la partida y determina de forma aleatoria cual comienza la partida. Inicializa el contador de turnos en 0.
    /// </summary>
    /// <param name="player1"> Primer jugador.</param>
    /// <param name="player2"> Segundo jugador.</param>
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
        return $"Ganador: {Players[winner].Name}. Perdedor: {Players[loser].Name}";

    }
    /// <summary>
    /// Reduce el tiempo de enfriamiento (cooldown) de todos los ataques especiales de cada Pokemon en los equipos de los jugadores.
    /// </summary>
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

    /// <summary>
    /// Avanza al siguiente turno del juego. Actualiza el contador de turnos, reduce el cooldown de los ataques especiales
    /// y cambia al siguiente jugador activo, siempre que el juego esté en curso.</summary>
    public void NextTurn()
    {
        if (GameStatus())
        {
           this.TurnCount++;
           CooldownCheck();          
           this.ActivePlayer = (this.ActivePlayer + 1) % 2;
        }
    }


    /// <summary>
    /// Ejecuta un ataque por parte del Pokemon activo del jugador actual, siempre y cuando no se encuentre dormido ni paralizado.
    /// </summary>
    /// <param name="attack">El ataque que se va a ejecutar.</param>
    /// <returns>
    /// <c>string</c>Un mensaje que indica el daño infligido al Pokemon objetivo o el estado actual que impidió el ataque.
    /// Devuelve null si no se proporciona un ataque válido.
    /// </returns>
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
                if (attack.Power == 0)
                {
                    return $"El poder del ataque {attack} era de 0, por lo tanto no hizo daño";
                }
                if (damage == 0.0)
                {
                    return "El ataque falló y no fue exitoso";
                }
                return $"{attackedPokemon.Name} recibió {damage} puntos de daño";
            }
            else return $"{this.Players[ActivePlayer].ActivePokemon} está {this.Players[ActivePlayer].ActivePokemon.CurrentState}";
        }
        return null;
    }


    /// <summary>
    /// Permite que un jugador use un item en un Pokemon específico de su equipo, verificando la validez del item y del Pokemon.
    /// </summary>
    /// <param name="item">El item que se va a usar.</param>
    /// <param name="pokemon">El Pokemon sobre el que se usará el item.</param>
    /// <returns>
    /// Un mensaje indicando el resultado del uso del objeto, o un mensaje de error si el objeto o el Pokemon no son válidos.
    /// </returns>
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

    /// <summary>
    /// Cambia el Pokemon activo del jugador actual por otro de su equipo, verificando si el cambio es válido.
    /// </summary>
    /// <param name="pokemon">El nuevo Pokemon que se intentará establecer como activo.</param>
    /// <returns>
    /// <c>string</c>Un mensaje indicando que el cambio fue exitoso, o un mensaje de error si el Pokemon proporcionado no es válido
    /// o si no tiene vida.
    /// </returns>

    public string ChangePokemon(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            return "Ese Pokemon no está en tu equipo.";
        }

        if (pokemon.Name  == Players[ActivePlayer].ActivePokemon.Name)
        {
            return "Ese ya es tu pokemon activo";
        }

        if (this.Players[ActivePlayer].SetActivePokemon(pokemon))
        { 
            return $"{pokemon.Name} es tu nuevo Pokemon activo.";
        }

        return $"{pokemon.Name} no tiene vida. Suerte bro, lo siento :/";
    }

    /// <summary>
    /// Busca si hay un jugador con el mismo nombre que el del parámetro en una partida.
    /// </summary>
    /// <param name="checkPlayer"> El jugador a buscar</param>
    /// <returns> <c>true</c> si lo encontró, <c>false</c> en caso contrario </returns>
    public bool CheckPlayerInGame(Player checkPlayer)
    {
        if (checkPlayer != null)
        {
            foreach (Player player in Players)
            {
                if (player.Name == checkPlayer.Name)
                {
                    return true;
                }
            }
            
        }
        return false;
    }
    
}