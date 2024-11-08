namespace Library;

public static class Facade
{
    private static WaitingList WaitingList { get; } = new WaitingList();

    private static GameList GameList{ get; } = new GameList();
    
    // historia de usuario 2
    public static string ShowAtacks(string playerName)
    {
        
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
            return $"El jugador {playerName} no está en ninguna partida.";
         
        return player.GetPokemonAttacks();
    }

    // historia de usuario 3
    public static string ShowPokemonsHP(string playerName, string playerToCheckName = null)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
            return $"El jugador {playerName} no está en ninguna partida.";
        if (playerToCheckName == null)
        {
            string result = "";
            foreach (Pokemon pokemon in player.GetPokemonTeam())
                result += pokemon.Name + ": " + pokemon.GetLife() + "\n";
            return result;
        }
        else
        {
            Player playerToCheck = GameList.FindPlayerByName(playerToCheckName);
            string result = "";
            Game game = GameList.FindGameByPlayer(player);
            if (playerToCheck != null && game != null && game.GetPlayers().Contains(player) && game.GetPlayers().Contains(playerToCheck))
            {
                foreach (Pokemon pokemon in playerToCheck.GetPokemonTeam())
                    result += pokemon.Name + ": " + pokemon.GetLife() + "\n";
                return result;
            }
            return $"El jugador {playerToCheckName} no está en tu partida.";
        }
    }

    //Historia de usuario 5
    public static string CheckTurn(string playerName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {return $"El jugador {playerName} no está en ninguna partida.";}
        Game game = GameList.FindGameByPlayer(player);
        string opciones = $"1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)";
        if (game.GetPlayers().Contains(player))
        {
            int activePlayerIndex = game.ActivePlayer;
            Player activePlayer = game.GetPlayers()[activePlayerIndex];
            if (activePlayer.Name == playerName)
                return "Es tu turno:\n" + opciones;
            return "No es tu turno" + "Las opciones disponibles cuando sea tu turno son:\n" + opciones;
        }
        return null;
    }
    
    //Historia de usuario 6
    public static string CheckGameStatus(Game game)
    {
        if (game != null)
        {
            if (game.GameStatus())
            {
                return $"Próximo turno, ahora es el turno de {game.GetPlayers()[game.ActivePlayer]}";
            }
            //eliminar game de la lista de games, ya que este finalizó
            return game.Winner();
        }
        return "La partida no pudo ser encontrada";
    }
    
    //Historia de usuario 7
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
            if (game.GetPlayers()[game.ActivePlayer].GetPokemonTeam().Count < 6)
            {
                return "Tu equipo pokemon está incompleto, elige hasta tener 6 pokemones en tu equipo";
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

    //Historia de usuario 8
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
    
    
    // historia de usuario 9
    public static string AddPlayerToWaitingList(string playerName)
    {
        if (WaitingList.AddPlayer(playerName))
        {
            return $"{playerName} agregado a la lista de espera";
        }
        return $"{playerName} ya está en la lista de espera";
    }
    
    public static string RemovePlayerFromWaitingList(string playerName)
    {
        if (WaitingList.RemovePlayer(playerName))
            return $"{playerName} removido de la lista de espera";
        return $"{playerName} no está en la lista de espera";
    }
    //historia de usuario 10
    public static string GetAllPlayersWaiting()
    {
        if (WaitingList.Count == 0)
            return "No hay nadie esperando";
        string result = "Esperan: ";
        foreach (Player player in WaitingList.GetWaitingList())
            result = result + player.Name + "; ";
        return result;
    }
    //historia de usuario 11
    private static string CreateGame(string playerName, string opponentName)
    {
        Player player = WaitingList.FindPlayerByName(playerName);
        Player opponent = WaitingList.FindPlayerByName(opponentName);
        WaitingList.RemovePlayer(playerName);
        WaitingList.RemovePlayer(opponentName);
        GameList.AddGame(player, opponent);
        return $"Comienza {playerName} vs {opponentName}";
    }
    
    public static string StartBattle(string playerName, string? opponentName)
    {
        Player? opponent;
        if (!OpponentProvided() && !SomebodyIsWaiting())
            return "No hay nadie esperando";
        if (!OpponentProvided())
        {
            opponent = WaitingList.GetAnyoneWaiting();
            return CreateGame(playerName, opponent!.Name);
        }
        opponent = WaitingList.FindPlayerByName(opponentName!);
        if (!OpponentFound())
        {
            return $"{opponentName} no está esperando";
        }
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
    
    // Historia 1
    
    public static string ChooseTeam(string playerName, string cPokemon)
    {
        PokemonCatalogue.SetCatalogue();
        Player player = GameList.FindPlayerByName(playerName);
        
        if (player == null)
        {
            return "Para poder elegir un equipo, primero debes estar en una batalla";
        }
        if (player.GetPokemonTeam().Count < 6)
        {
            if (cPokemon != null)
            {
                foreach (Pokemon pokemon in PokemonCatalogue.SetCatalogue())
                {
                    if (pokemon.Name == cPokemon && !player.GetPokemonTeam().Contains(pokemon))
                    {
                        player.AddToTeam(pokemon);
                        return $"El pokemon {cPokemon} fue añadido al equipo";
                    }
                    return $"El pokemon {cPokemon} ya está en el equipo, no puedes volver a añadirlo";
                }
            }
            return $"El pokemon {cPokemon} no fue encontrado";
        }

        return "El equipo está incompleto, por favor elige 6 pokemones para poder comenzar la batalla";
    }

    public static string ShowCatalogue()
    {
        return PokemonCatalogue.ShowCatalogue();
    }

    public static string ChooseAttack(string playerName, string attackName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return "Para poder atacar necesitas estar en una batalla";
        }
        Attack attack = player.FindAttack(attackName);
        if (attack == null)
        {
            return $"El ataque {attackName} no pudo ser encontrado";
        }
        foreach (Game game in GameList.GetGameList())
        {
            if (game.GetPlayers().Contains(player))
            {
                string gameResult = game.ExecuteAttack(attack);
                game.NextTurn();
                return gameResult;
            }
        }
        return "El ataque no pudo ser concretado";
    }

}