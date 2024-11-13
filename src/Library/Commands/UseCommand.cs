using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'use' del bot.
/// </summary>
public class UseCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Envía a la fachada un mensaje con el item a usar y el Pokemons que se verá beneficiado.
    /// </summary>
    /// <param name="pokemonAndItemName">Nombre de Pokemon a ser beneficiado y del item a utilizar concatenados.</param>
    [Command("useitem")]
    [Summary(
        """
        Usa el item seleccionado para beneficiar al Pokemon especificado.
        Si no se pudo utilizar el item el jugador no pierde el turno.
        Este comando solo puede ser utilizado por un jugador mientras
        sea su turno.
        """)]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Nombre de Pokemon a ser beneficiado y del item a utilizar concatenados")]
        string pokemonAndItemName
        )
    {
        
    }
}