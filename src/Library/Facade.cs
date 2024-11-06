using System.Runtime.CompilerServices;

namespace Library;

public static class Facade
{
    private static WaitingList WaitingList { get;} = new WaitingList();

    public static GameList GameList{ get;} = new GameList();
    public static string ShowAtacks(string playerName)
    {
        //chequear que este en la partida
        string result = "";
        Player player = GameList.FindPlayerByName(playerName);
        foreach (IAttack atack in player.ActivePokemon.Attacks)
        {
            result += atack.Name + "\n";
        }

        return result;
    }

    public static string ShowPokemonsHP(string playerName, string playerToCheckName = null)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
            return "El jugador no está en ninguna partida.";
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
            string result = "";
            foreach (Game game in GameList.Games)
            {
                if (game.Players.Contains(player) && game.Players.Contains(playerToCheck))
                {
                    foreach (Pokemon pokemon in playerToCheck.PokemonTeam)
                        result += pokemon.Name + ": " + pokemon.GetLife() + "\n";
                    return result;
                }
            }
            return "El jugador no pertenece a tu partida.";
        }
    }

    public static string CheckTurn(string playerName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return "El jugador no está en ninguna partida.";

        }
        foreach (Game game in GameList.Games)
        {
            string opciones = $"1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)";
            if (game.Players.Contains(player))
            {
               int activePlayerIndex = game.ActivePlayer;
               Player activePlayer = game.Players[activePlayerIndex];
               if (activePlayer.Name == playerName)
               {
                    return "Es tu turno:\n" + opciones;
               }
               else
               {
                    return "no puedes jugar porque no es tu turno";
               }
            }
        }
        return null;
    }
}