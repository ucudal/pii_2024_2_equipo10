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

    //Historia de usuario 5
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

    //Historia de usuario 7
    public static string MidBattlePokemonChange(string playerName, string pokemonName)
    {
        Player player = GameList.FindPlayerByName(playerName);
        if (player == null)
        {
            return $"El jugador {player.Name} no está en ninguna partida.";
        }
        Game game = GameList.FindGameByPlayer(player); 
        return game.ChangePokemon(player.ChoosePokemon(pokemonName));

    }

    /*
    public void MenuCambioPokemon()
    {
        
            int n = 1;
            Console.WriteLine($"Que pokemon va a luchar?:");
            foreach (var pokemon in this.players[ActivePlayer].PokemonTeam)
            {
                Console.WriteLine($"{n}) {pokemon.Name}");
                n++;
            }
            while (true)
            {
                pokeball.ChangePokemon(this.Players[ActivePlayer]);
            }
            return "accion no reconocida, introduzcala nuevamente";
            //StateLogic.PoisonedEffect(Players[ActivePlayer].ActivePokemon);
            //StateLogic.BurnedEffect(Players[ActivePlayer].ActivePokemon);

      
              Console.Write(">");
                int R = Convert.ToInt32(Console.ReadLine());//posible error si se ingresa str
                if (R > 1 && R <= n)
                {
                    this.players[ActivePlayer].ChangeActivePokemon(players[ActivePlayer].PokemonTeam[R - 1]);
                    return;
                }
                else
                {
                    Console.WriteLine("Opcion invalida");
                }
            }
        
    }
    */


}