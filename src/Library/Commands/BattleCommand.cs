using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library.Commands;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'battle' del bot. Este comando une al
/// jugador que envía el mensaje con el oponente que se recibe como parámetro,
/// si lo hubiera, en una batalla; si no se recibe un oponente, lo une con
/// cualquiera que esté esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class BattleCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'battle'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    /// <param name="opponentDisplayName">Nombre de oponente, puede ser nulo.</param>
    [Command("battle")]
    [Summary(
        """
        Une al jugador que envía el mensaje con el oponente que se recibe
        como parámetro, si lo hubiera, en una batalla; si no se recibe un
        oponente, lo une con cualquiera que esté esperando para jugar.
        """)]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync(
        [Remainder] [Summary("Display name del oponente, opcional")]
        string? opponentDisplayName = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        
        SocketGuildUser? opponentUser = CommandHelper.GetUser(
            Context, opponentDisplayName);
        string result;
        if (opponentUser != null)
        {
            result = Facade.StartGame(displayName, opponentUser.DisplayName);
            if(result.Contains(" Vs. "))
            {
                await Context.Message.Author.SendMessageAsync(result);
                await opponentUser.SendMessageAsync(result);
                await Context.Message.Author.SendMessageAsync("!choose 'Nombre del Pokemon' para elegir un Pokemon, !help para más comandos.\nElegí uno de estos:");
                await opponentUser.SendMessageAsync("!choose 'Nombre del Pokemon' para elegir un Pokemon, !help para más comandos.\nElegí uno de estos:");
                await Context.Message.Author.SendMessageAsync(Facade.ShowCatalogue());
                await opponentUser.SendMessageAsync(Facade.ShowCatalogue());
            }
        }
        else
        {
            result = Facade.StartGame(displayName, opponentDisplayName);
            if (result.Contains(" Vs. "))
            {
                string[] splitResult = result.Split(" Vs. ");
                opponentUser = CommandHelper.GetUser(Context, splitResult[1]);
                await Context.Message.Author.SendMessageAsync(result);
                await opponentUser.SendMessageAsync(result);
                await Context.Message.Author.SendMessageAsync("!choose 'Nombre del Pokemon' para elegir un Pokemon, !help para más comandos.\nElegí uno de estos:");
                await opponentUser.SendMessageAsync("!choose 'Nombre del Pokemon' para elegir un Pokemon, !help para más comandos.\nElegí uno de estos:");
                await Context.Message.Author.SendMessageAsync(Facade.ShowCatalogue());
                await opponentUser.SendMessageAsync(Facade.ShowCatalogue());
            }
        }
        await ReplyAsync(result);
    }
}
