using System.Runtime.CompilerServices;

namespace Library;

public static class Facade
{
    private static WaitingList WaitingList { get; } = new WaitingList();

    public static GameList GameList { get; } = new GameList();


    public static string ShowAtacks(string playerName)
    {
        //chequear que esté en la partida
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
}