using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'chooserandom' del bot.
/// </summary>
public class ChooseRandomCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Completa el equipo del jugador aleatoriamnte.
    /// </summary>
    [Command("chooserandom")]
    [Summary(
        """
        Completa el equipo del jugador aleatoriamnte.
        El jugador debe estar en una partida para usar este comando.
        """)]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Facade.ChooseRandom(displayName);
        await ReplyAsync(result);
    }

}