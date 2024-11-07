using System.Runtime.CompilerServices;

namespace Library;

public static class Facade
{
    private static WaitingList WaitingList { get; } = new WaitingList();

    public static GameList GameList{ get; } = new GameList();
    
    public static string ChooseTeam(string playerName, string cPokemon)
    {
        PokemonCatalogue.SetCatalogue();
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return "Para poder elegir un equipo, primero debes estar en una batalla";
        }
        else if (cPokemon != null)
        {
            foreach (Pokemon pokemon in PokemonCatalogue.PokemonList)
            {
                if (pokemon.Name == cPokemon && !player.PokemonTeam.Contains(pokemon))
                {
                    player.AddToTeam(pokemon);
                    return $"El pokemon {cPokemon} fue añadido al equipo";
                }
                else if (player.PokemonTeam.Contains(pokemon))
                {
                    return $"El pokemon {cPokemon} ya está en el equipo, no puedes volver a añadirlo";
                }
            }
        }
        return $"El pokemon {cPokemon} no fue encontrado";
    }

    public static string ShowCatalogue()
    {
        PokemonCatalogue.SetCatalogue();
        return PokemonCatalogue.ShowCatalogue();
    }
    
    // historia de usuario 2
    public static string ShowAtacks(string playerName)
    {
        
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return $"El jugador {playerName} no está en ninguna partida.";
        }
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
            foreach (Pokemon pokemon in player.PokemonTeam)
                result += pokemon.Name + ": " + pokemon.GetLife() + "\n";
            return result;
        }
        else
        {
            Player playerToCheck = GameList.FindPlayerByName(playerToCheckName);
            if (playerToCheck == null)
            {
                return $"El jugador {playerToCheckName} no pudo ser encontrado";
            }
            string result = "";
            Game game = GameList.FindGameByPlayer(player);
            if (game != null && game.Players.Contains(player) && game.Players.Contains(playerToCheck))
            {
                foreach (Pokemon pokemon in playerToCheck.PokemonTeam)
                    result += pokemon.Name + ": " + pokemon.GetLife() + "\n";
                return result;
            }
            return $"El jugador {playerToCheckName} no está en tu partida.";
        }
    }

    public static string CheckTurn(string playerName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
            return $"El jugador {playerName} no está en ninguna partida.";
        Game game = GameList.FindGameByPlayer(player);
        string opciones = $"1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)";
        if (game.Players.Contains(player))
        {
            int activePlayerIndex = game.ActivePlayer;
            Player activePlayer = game.Players[activePlayerIndex];
            if (activePlayer.Name == playerName)
                return "Es tu turno:\n" + opciones;
            return "No es tu turno" + "Las opciones disponibles cuando sea tu turno son:\n" + opciones;
        }
        return null;
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
        {
            return "No hay nadie esperando";
        }

        string result = "Esperan: ";
        foreach (Player player in WaitingList.Players)
        {
            result = result + player.Name + "; ";
        }
        
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

    public static string ChooseAttack(string playerName, string attackName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return "Para poder atacar necesitas estar en una batalla";
        }
        
        IAttack attack = player.ChooseAttack(attackName);
        if (attack == null)
        {
            return $"El ataque {attackName} no pudo ser encontrado";
        }

        if (attack is Attack)
        { 
            Game game = GameList.FindGameByPlayer(player);
            if (game == null)
            {
                return "Esa partida no está en curso";
            }
            string gameResult = game.ExecuteAttack(attack);
            string nextTurn = game.NextTurn();
            return gameResult + nextTurn;
        } 
        return "El ataque no hace nada";
    }

}