using System.Runtime.CompilerServices;

namespace Library;
/// <summary>
/// Esta clase representa la fachada, la cual tiene los métodos escenciales para el funcionamiento del chatbot
/// </summary>
public static class Facade
{
    /// <summary>
    /// Lista de espera para jugadores que aún no están en una partida.
    /// </summary>
    private static WaitingList WaitingList { get; } = new WaitingList();

    /// <summary>
    /// Lista de partidas en curso.
    /// </summary>
    private static GameList GameList { get; } = new GameList();

    /// <summary>
    /// Catalogo de Pokemons.
    /// </summary>
    //private static PokemonCatalogue pokemonCatalogue { get; } = PokemonCatalogue.Instance;

    private static PokemonCatalogue Pokedex { get; } = PokemonCatalogue.Instance;
    
    /// <summary>
    /// Historia 1:
    /// Permite a un jugador agregar un Pokemon al equipo desde el catálogo.
    /// </summary>
    /// <param name="playerName">Nombre del jugador.</param>
    /// <param name="pokemonName">Nombre del Pokemon que se quiere añadir al equipo.</param>
    /// <returns>Mensaje <c>string</c> indicando si el Pokemon fue añadido, si ya estaba ne el equipo o si hubo un error.</returns>
    public static string ChooseTeam(string playerName, string pokemonName)
    {
        Player player = GameList.FindPlayerByName(playerName);

        if (player == null)
            return $"{playerName}, para poder elegir un equipo, primero debes estar en una batalla";

        if (player.TeamCount < 6)
        { 
            if (player.FindPokemonByName(pokemonName))
                return $"El pokemon {pokemonName} ya está en el equipo de {playerName}, no puedes volver a añadirlo";
            foreach (Pokemon pokemon in Pokedex.PokemonList)
            {
                if (pokemon.Name == pokemonName)
                {
                    Pokemon newPokemon = pokemon.Instance();
                    player.AddToTeam(newPokemon);
                    if (player.TeamCount == 6)
                        return $"El pokemon {pokemonName} fue añadido al equipo de {playerName}\nTu equipo está completo.";
                    return $"El pokemon {pokemonName} fue añadido al equipo de {playerName}.\nElegiste {player.TeamCount}/6";
                }
            }
            return $"{playerName}, el pokemon {pokemonName} no fue encontrado";
        }
        return $"{playerName} ya tienes 6 pokemones en el equipo, no puedes elegir más";
    }


    /// <summary>
    /// Historia de usuario 2:
    /// Muestra los ataques disponibles del Pokemon activo de un jugador.
    /// </summary>
    /// <param name="playerName">Nombre del jugador activo.</param>
    /// <returns>Un <c>string</c> de los ataques del Pokémon activo o un mensaje de error en
    /// caso de que el jugador no exista.</returns>
    public static string ShowAtacks(string playerName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
            return $"{playerName}, no estás en ninguna partida.";
        if (player.TeamCount == 0)
            return $"{playerName}, no tienes ningun Pokemon.";
        
        return $"{playerName}, estos son los ataques de tu Pokemon activo:\n" + player.GetPokemonAttacks();
    }

    /// <summary>
    /// Historia de usuario 3:
    /// Muestra los puntos de vida (HP) de los Pokemon de un jugador.
    /// </summary>
    /// <param name="playerName">Nombre del jugador.</param>
    /// <param name="playerToCheckName">Nombre del jugador cuya lista de Pokemon se va a comprobar (opcional). Si es
    /// <c>null</c> hace referencia al propio jugador. Si no, hace referencia a otro.</param>
    /// <returns>Un <c>string</c> de los Pokemon y sus HP o un mensaje de error.</returns>
    public static string ShowPokemonsHp(string playerName, string? playerToCheckName = null)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
            return $"El jugador {playerName} no está en ninguna partida.";
        if (playerToCheckName == null)
        {
            string result = "";
           
            foreach (Pokemon pokemon in player.GetPokemonTeam())
            {
                string types = "";
                foreach (Type type in pokemon.GetTypes())
                {
                    types += $"{type}";
                }

                if (pokemon == player.ActivePokemon)
                {
                    result += $"**{pokemon.Name}: {pokemon.GetLife()} ({types})**\n";
                }
                else if (pokemon.CurrentLife == 0)
                {
                    result += $"~~{pokemon.Name}: {pokemon.GetLife()} ({types})~~\n";
                }
                else
                {
                    result += $"{pokemon.Name}: {pokemon.GetLife()} ({types})\n";
                }
            }
            return result;
        }
        else
        {
            Player playerToCheck = GameList.FindPlayerByName(playerToCheckName);
            string result = "";
            Game game = GameList.FindGameByPlayer(player);
            if (game != null && game.CheckPlayerInGame(player) && game.CheckPlayerInGame(playerToCheck) &&
                playerToCheck != null)
            {
                if (playerToCheck.TeamCount < 6)
                {
                    return $"{playerToCheckName} aún no tiene su equipo completo.";
                }

                foreach (Pokemon pokemon in playerToCheck.GetPokemonTeam())
                {
                    string types = "";
                    foreach (Type type in pokemon.GetTypes())
                    {
                        types += $"{type}";
                    }
                    result += $"{pokemon.Name}:{pokemon.GetLife()} ({types})\n";
                }

                return result;
            }

            return $"El jugador {playerToCheckName} no está en tu partida.";
        }
    }

    /// <summary>
    /// Historia de usuario 4:
    /// Permite a un jugador elegir y ejecutar un ataque durante su turno en una partida.
    /// </summary>
    /// <param name="playerName">Nombre del jugador que realiza el ataque.</param>
    /// <param name="attackName">Nombre del ataque que se desea utilizar.</param>
    /// <returns>
    /// Un mensaje <c>string</c> que indica el resultado de la acción.
    /// </returns>
    public static string ChooseAttack(string playerName, string attackName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return "Para poder atacar necesitas estar en una batalla";
        }

        if (player.GetPokemonTeam().Count < 6)
        {
            return "El equipo está incompleto, por favor elige 6 pokemones para poder comenzar la batalla";
        }

        Attack attack = player.FindAttack(attackName);
        if (attack == null)
        {
            return $"El ataque {attackName} no pudo ser encontrado";
        }

        Game actualGame = GameList.FindGameByPlayer(player);
        if (actualGame == null)
        {
            return "Esa partida no está en curso";
        }

        foreach (Game game in GameList.GetGameList())
        {
            if (game.CheckPlayerInGame(player))
            {
                if (game.GetPlayers()[game.ActivePlayer].Name == player.Name)
                {
                    string gameResult = game.ExecuteAttack(attack);
                    game.NextTurn();
                    string nextTurn = CheckGameStatus(game);
                    return gameResult + " " + nextTurn;
                }
                return "No eres el jugador activo";
            }
        }

        return "Error inesperado";
    }

    /// <summary>
    /// Historia de usuario 5:
    /// Comprueba si es el turno de un jugador y muestra las opciones disponibles.
    /// </summary>
    /// <param name="playerName">Nombre del jugador.</param>
    /// <returns>Mensaje <c>string</c> indicando si es o no su turno, junto con las opciones.</returns>
    public static string CheckTurn(string playerName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return $"El jugador {playerName} no está en ninguna partida.";
        }

        Game game = GameList.FindGameByPlayer(player);
        if (game != null)
        {
            if (game.CheckPlayerInGame(player))
            {
                int activePlayerIndex = game.ActivePlayer;
                Player activePlayer = game.GetPlayers()[activePlayerIndex];
                if (activePlayer.Name == playerName)
                    return $"{playerName}, es tu turno";
                return $"{playerName}, no es tu turno";
            }
        }

        return null;
    }

    /// <summary>
    /// Historia de usuario 6:
    /// Comprueba el estado de una partida y determina si continúa o hay un ganador.
    /// </summary>
    /// <param name="game">La partida actual.</param>
    /// <returns><c>"Próximo turno"</c> en caso de que la partida siga o un <c>string</c> conteniendo el
    /// ganador y el perdedor.</returns>
    public static string CheckGameStatus(Game game)
    {
        if (game != null)
        {
            if (game.GameStatus())
            {
                return $"Próximo turno, ahora es el turno de {game.GetPlayers()[game.ActivePlayer].Name}";
            }
            GameList.RemoveGame(game);
            return game.Winner();
        }
        return "La partida no pudo ser encontrada";
    }


    /// <summary>
    /// Historia de usuario 7:
    /// Permite a un jugador activo cambiar su Pokemon actual durante su turno en una partida.
    /// </summary>
    /// <param name="playerName">Nombre del jugador que desea cambiar de Pokemon.</param>
    /// <param name="pokemonName">Nombre del Pokemon al que se desea cambiar.</param>
    /// <returns>
    /// Un mensaje <c>string</c> que indica el resultado de la acción.
    /// </returns>
    public static string ChangePokemon(string playerName, string pokemonName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return $"El jugador {playerName} no está en ninguna partida.";
        }

        Game game = GameList.FindGameByPlayer(player);
        if (game == null)
        {
            return "La partida no pudo ser encontrada";
        }

        if (game.GetPlayers()[game.ActivePlayer].Name == playerName)
        {
            if (!game.BothPlayersHaveChoosenTeam())
            {
                return "Ambos jugadores no han seleccionado 6 pokemones para iniciar el combate";
            }

            Pokemon choosenPokemon = player.FindPokemon(pokemonName);
            if (choosenPokemon == null)
            {
                return $"El pokemon {pokemonName} no fue encontrado en tu equipo";
            }

            string result = game.ChangePokemon(choosenPokemon);
            if (result == "Ese Pokemon no está en tu equipo.")
            {
                return result;
            }

            game.NextTurn();
            string nextTurn = CheckGameStatus(game);
            return result + "\n" + nextTurn;
        }

        return "No eres el jugador activo, no puedes realizar acciones";
    }

    /// <summary>
    /// Historia de usuario 8
    /// Permite a un jugador usar un item en un Pokemon.
    /// </summary>
    /// <param name="playerName">Nombre del jugador.</param>
    /// <param name="item">Nombre del item a usar.</param>
    /// <param name="pokemon">Nombre del Pokemon objetivo.</param>
    /// <returns>Resultado del uso del item <c>string</c>.</returns>
    public static string UseAnItem(string playerName, string item, string pokemon)
    {
        Player player = GameList.FindPlayerByName(playerName);
        Game game = GameList.FindGameByPlayer(player);

        if (player == null)
        {
            return $"El jugador {playerName} no está en ninguna partida.";
        }

        if (game == null)
        {
            return "Partida inexistente.";
        }
        return game.UseItem(player.FindItem(item), player.FindPokemon(pokemon));
    }


    /// <summary>
    /// Historia de usuario 9:
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="playerName">Nombre del jugador.</param>
    /// <returns>Mensaje indicando si el jugador fue agregado o ya estaba en la lista.</returns>
    public static string AddPlayerToWaitingList(string playerName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (GameList.FindGameByPlayer(player) != null)
        {
            return $"{playerName} ya está en una partida";
        }
        if (WaitingList.AddPlayer(playerName))
        {
            return $"{playerName} agregado a la lista de espera";
        }

        return $"{playerName} ya está en la lista de espera";
    }

    /// <summary>
    /// Historia de usuario 9.1:
    /// Remueve un jugador de la lista de espera.
    /// </summary>
    /// <param name="playerName">Nombre del jugador.</param>
    /// <returns>Mensaje <c>string</c> indicando si el jugador fue removido o no estaba en la lista.</returns>
    public static string RemovePlayerFromWaitingList(string playerName)
    {
        if (WaitingList.RemovePlayer(playerName))
            return $"{playerName} removido de la lista de espera";
        return $"{playerName} no está en la lista de espera";
    }

    /// <summary>
    /// Historia de usuario 10
    /// Muestra todos los jugadores actualmente en la lista de espera.
    /// </summary>
    /// <returns>Lista de jugadores en espera o un mensaje indicando que no hay nadie esperando.</returns>
    public static string GetAllPlayersWaiting()
    {
        if (WaitingList.Count == 0)
        {
            return "No hay nadie esperando";
        }

        string result = "Esperan: ";
        foreach (Player player in WaitingList.GetWaitingList())
        {
            result = result + player.Name + "; ";
        }

        return result;
    }

    //
    /// <summary>
    /// Historia de usuario 11:
    /// Crea una nueva partida entre dos jugadores, quitándolos de la lista de espera y agregando la partida a la lista de
    /// juegos activos.
    /// </summary>
    /// <param name="playerName">Nombre del primer jugador.</param>
    /// <param name="opponentName">Nombre del oponente.</param>
    /// <returns>Mensaje <c>string</c> confirmando el inicio de la partida entre ambos jugadores.</returns>
    private static string CreateGame(string playerName, string opponentName)
    {
        Player player = WaitingList.FindPlayerByName(playerName);
        Player opponent = WaitingList.FindPlayerByName(opponentName);
        WaitingList.RemovePlayer(playerName);
        WaitingList.RemovePlayer(opponentName);
        GameList.AddGame(player, opponent);
        Game game = GameList.FindGameByPlayer(player);
        string ActivePlayerName = game.GetPlayers()[game.ActivePlayer].Name;
        return $"¡Comienza @{playerName} Vs. @{opponentName}!\nComienza atacando {ActivePlayerName}\n";
    }

    /// <summary>
    /// Historia de usuario 11.1:
    /// Inicia una batalla entre dos jugadores, eligiendo un oponente específico o un jugador
    /// al azar de la lista de espera.
    /// </summary>
    /// <param name="playerName">Nombre del jugador que inicia la batalla.</param>
    /// <param name="opponentName">Nombre del oponente (opcional).</param>
    /// <returns> <c>string</c> indicando si la batalla comenzó o si hubo algún error.</returns>
    public static string StartGame(string playerName, string opponentName)
    {
        Player opponent;
        Player player = GameList.FindPlayerByName(playerName);
        if (GameList.FindGameByPlayer(player) != null)
        {
            return $"{playerName} ya está en una partida";
        }

        if (WaitingList.FindPlayerByName(playerName) == null)
            return $"{playerName}, no estas en la lista de espera";
        
        if (!OpponentProvided() && !SomebodyIsWaiting())
            return "No hay nadie esperando";
        
        if (!OpponentProvided())
        {
            opponent = GameList.FindPlayerByName(opponentName);
            if (GameList.FindGameByPlayer(opponent) != null)
                return $"{opponentName} ya está en una partida";
            opponent = WaitingList.GetSomeone(playerName);
            if(opponent == null)
                return "No hay nadie más en la lista de espera";
            return CreateGame(playerName, opponent!.Name);
        }
        
        opponent = WaitingList.FindPlayerByName(opponentName!);
        if (!OpponentFound())
        {
            return $"{opponentName} no está esperando";
        }

        if (GameList.FindGameByPlayer(opponent) != null)
            return $"{opponentName} ya está en una partida";
        
        return CreateGame(playerName, opponent!.Name);

        bool OpponentProvided()
        {
            return !string.IsNullOrEmpty(opponentName);
        }

        bool SomebodyIsWaiting()
        {
            return WaitingList.Count != 0;
        }

        bool OpponentFound()
        {
            return opponent != null;
        }
    }
    
    /// <summary>
    /// Muestra el catálogo de Pokemon disponibles.
    /// </summary>
    /// <returns> <c>Lista</c> de Pokemon en el catálogo.</returns>
    public static string ShowCatalogue()
    {
        return "**Catalogo de Pokemons:**\n" + Pokedex.ShowCatalogue();
    }

    public static string Surrender(string playerName)
    {
        Player? surrenderPlayer = GameList.FindPlayerByName(playerName);
        if (surrenderPlayer == null)
        {
            return $"{playerName}, ara rendirte primero debes estar en una batalla";
        }
        Game? game = GameList.FindGameByPlayer(surrenderPlayer);
        int notActivePlayer = (game.ActivePlayer+1)%2;
        GameList.RemoveGame(game);
        if (game.GetPlayers()[game.ActivePlayer].Name == playerName)
        {
            return $"El jugador {game.GetPlayers()[game.ActivePlayer].Name} se ha rendido.\nGanador: {game.GetPlayers()[notActivePlayer].Name} \nPerdedor: {game.GetPlayers()[game.ActivePlayer].Name}";
        }
        return $"El jugador {game.GetPlayers()[notActivePlayer].Name} se ha rendido.\nGanador: {game.GetPlayers()[game.ActivePlayer].Name} \nPerdedor: {game.GetPlayers()[notActivePlayer].Name}";
    }

    public static string ShowItems(string playerName)
    {
        Player? player = GameList.FindPlayerByName(playerName);
        if (GameList.FindGameByPlayer(player) == null)
            return $"{playerName}, no estás en una partida.";
        string result = $"{playerName}, estos son tus items disponibles:\n";
        List<string> repeatedItems = new List<string>();
        foreach (IItem item in player.GetItemList() )
        {
            if (!repeatedItems.Contains(item.Name))
            {
                result += player.itemCount(item.Name) + " " + item.Name + "\n";
                repeatedItems.Add(item.Name);
            }
        }
        return result;
    }

    public static string ChooseRandom(string playerName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
            return $"{playerName}, no estás en una partida.";
        List<int> pokemonIndexes = new List<int>();
        for (int i = 0; i < Pokedex.PokemonCount; i++)
        {
            pokemonIndexes.Add(i);
        }
        string result = $"{playerName}, este es tu equipo Pokemon:\n";
        while (player.TeamCount < 6)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, pokemonIndexes.Count);
            if (!player.FindPokemonByName(Pokedex.PokemonList[randomIndex].Name))
            {
                player.AddToTeam(Pokedex.PokemonList[randomIndex].Instance());
                result += Pokedex.PokemonList[randomIndex].Name + "\n";
                pokemonIndexes.Remove(pokemonIndexes[randomIndex]);
            }
        }
        return result;
    }
}