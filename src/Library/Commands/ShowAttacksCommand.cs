using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'showattacks' del bot.
/// </summary>
public class ShowAttacksCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra los ataques disponibles del Pokemon activo del jugador.
    /// </summary>
    [Command("showattacks")]
    [Summary(
        """
        Muestra los los ataques disponibles del Pokemon activo del jugador.
        Se debe estar en partida para utilizar este comando.
        """)]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.ShowAtacks(displayName);
        await ReplyAsync(result); 
    }
}