using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'choose' del bot.
/// </summary>
public class ChooseCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Envía a la fachada un mensaje con el Pokemon seleccionado.
    /// </summary>
    /// <param name="pokemonName">Nombre del Pokemon seleccionado.</param>
    [Command("choose")]
    [Summary(
        """
        Agrega al equipo del jugador el Pokemon seleccionado.
        Si no se logra agregar envía un mensaje avisando al usuario.
        """)]
    public async Task ExecuteAsync(
        [Remainder] [Summary("Nombre del pokemon.")]
        string pokemonName)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result;
        result = Facade.ChooseTeam(displayName, pokemonName);
        await ReplyAsync(result);

    }
}