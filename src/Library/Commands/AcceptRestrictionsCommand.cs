using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;


public class AcceptRestrictionCommand : ModuleBase<SocketCommandContext>
{

    [Command("accept")]
    [Summary(
        """
        Envía a la fachada un mensaje para que acepte las restricciones.
        """)]
    public async Task ExecuteAsync()
    {
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.AcceptRestrictions(playerName);
        await ReplyAsync(result);
    }

}