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
        string result;
        result = Facade.StartGame(displayName, opponentDisplayName);
        await ReplyAsync(result);
        if(result.Contains(" Vs. "))
            await ReplyAsync("!choose <<Nombre del Pokemon>> para elegir un Pokemon\n!catalogue para ver el catalogo de Pokemones.\n!help para más comandos.");
    }
}
