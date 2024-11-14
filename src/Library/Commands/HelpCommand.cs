using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'help' del bot.
/// </summary>
public class HelpCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra todos los comandos que el usuario puede utilizar junto a una breve descripcion.
    /// </summary>
    [Command("help")]
    [Summary(
        """
        Muestra todos los comandos que el usuario puede utilizar junto a una breve descripcion.
        """)]
    public async Task ExecuteAsync()
    {
        await ReplyAsync(Facade.Help());
    }

}