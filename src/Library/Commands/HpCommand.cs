using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'hp' del bot.
/// </summary>
public class HpCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra la vida de los Pokemons del jugador que utiliza el comando
    /// si no se pasa el nombre del oponente como parámetro.
    /// Si se pasa el nombre del oponente muestra la vida de los Pokemons del rival.
    /// </summary>
    /// <param name="opponentDisplayName">Nombre del Pokemon seleccionado.</param>
    [Command("hp")]
    [Summary(
        """
        Muestra la vida de los Pokemons del jugador que utiliza el comando
        si no se pasa el nombre del oponente como parámetro.
        Si se pasa el nombre del oponente muestra la vida de los Pokemons del rival.
        """)]
    public async Task ExecuteAsync(
        [Remainder] [Summary("Display name del oponente, opcional")]
        string? opponentDisplayName = null)
    {
        
    }

}