using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'surrender' del bot.
/// </summary>
public class SurrenderCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Termina la partida en curso dandole la victoria al oponente.
    /// </summary>
    [Command("surrender")]
    [Summary(
        """
        Termina la partida en curso dandole la vicotria al oponente.
        Este comando solo puede ser utilizado por un jugador que esté en una partida..
        """)]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.Surrender(displayName);
        await ReplyAsync(result);
    }

}