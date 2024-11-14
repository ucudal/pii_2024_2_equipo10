using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'change' del bot.
/// </summary>
public class ChangeCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Envía a la fachada un mensaje con el nombre del Pokemon que el jugador seleccionó
    /// para ser su nuevo Pokemon activo.
    /// </summary>
    /// <param name="pokemonName">Nombre del Pokemon seleccionado.</param>
    [Command("change")]
    [Summary(
        """
        Envía a la fachada un mensaje con el nombre del Pokemon que el jugador seleccionó
        para ser su nuevo Pokemon activo.
        Si no se pudo concretar el cambio de Pokemon el jugador no pierde el turno.
        Este comando solo puede ser utilizado por un jugador mientras
        sea su turno.
        """)]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Nombre del Pokemon")]
        string pokemonName)
    {
        if (pokemonName == null)
            {await ReplyAsync("Para cambiar de Pokemon activo debes usar el siguiente formato: \n**!change** <**nombre del pokemon**>");}
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Facade.ChangePokemon(playerName, pokemonName);
        await ReplyAsync(result);
    }

}