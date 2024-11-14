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
    /// 
    /// </summary>
    [Command("chooserandom")]
    [Summary(
        """
        Muestra los Pokemons del catálogo.
        """)]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Facade.ChooseRandom(displayName);
        await ReplyAsync(result);
    }

}