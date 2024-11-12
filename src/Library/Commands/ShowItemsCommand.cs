using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'showitems' del bot.
/// </summary>
public class ShowItemsCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra los items disponibles del jugador.
    /// </summary>
    [Command("showitems")]
    [Summary(
        """
        Muestra los items disponibles del jugador.
        Se debe estar en partida para utilizar este comando.
        """)]
    public async Task ExecuteAsync()
    {
        
    }

}