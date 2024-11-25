using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'checkturn' del bot.
/// </summary>
public class CheckTurnCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Devuelve de quien es el turno.
    /// </summary>
    [Command("checkturn")]
    [Summary(
        """
        Devuelve de quien es el turno.
        Se debe estar en partida para utilizar este comando.
        """)]
    public async Task ExecuteAsync()
    {
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.CheckTurn(playerName);
        await ReplyAsync(result);
    }

}