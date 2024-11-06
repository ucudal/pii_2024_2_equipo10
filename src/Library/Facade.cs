using System.Runtime.CompilerServices;

namespace Library;

public static class Facade
{
    private static WaitingList WaitingList { get; } = new WaitingList();

    public static GameList GameList{ get; } = new GameList();
    // historia de usuario 2
    public static string ShowAtacks(string playerName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player != null)
        {
            return "El jugador no está en ninguna partida.";
        }
        string result = "";
        foreach (IAttack atack in player.ActivePokemon.Attacks)
        {
            result += atack.Name + "\n";
        }

        return result;
    }

    // historia de usuario 3
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
}