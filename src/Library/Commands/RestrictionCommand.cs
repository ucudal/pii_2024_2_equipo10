using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;


public class RestrictionCommand : ModuleBase<SocketCommandContext>
{

    [Command("restriction")]
    [Summary(
        """
        Envía a la fachada un mensaje con la restriccion que se desea agregar.
        """)]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Restriccion a agregar")]
        string restriccion)
    {
        if (restriccion == null)
            {await ReplyAsync("Debes indicar un Pokemon, Item o Tipo a restringir.");}
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.AddGameRestrictions(playerName, restriccion);
        await ReplyAsync(result);
    }

}