using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;


public class RejectRestrictionCommand : ModuleBase<SocketCommandContext>
{

    [Command("reject")]
    [Summary(
        """
        Envía a la fachada un mensaje para que rechace las restricciones.
        """)]
    public async Task ExecuteAsync()
    {
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.RejectRestrictions(playerName);
        await ReplyAsync(result);
    }

}