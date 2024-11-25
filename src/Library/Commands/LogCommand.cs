using Discord.Commands;

namespace Library.Commands;

public class LogCommand: ModuleBase<SocketCommandContext>
{
    [Command("Log")]
    [Summary(
        """
        Muestra el log de la batalla en la que el jugador se encuentre.
        """)]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        await ReplyAsync(Facade.ShowLog(displayName));
    }
}