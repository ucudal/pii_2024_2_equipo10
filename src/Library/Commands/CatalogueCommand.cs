using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'catalogue' del bot.
/// </summary>
public class CatalogueCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra los Pokemons del catálogo.
    /// </summary>
    [Command("catalogue")]
    [Summary(
        """
        Muestra los Pokemons del catálogo.
        """)]
    public async Task ExecuteAsync()
    {
        
    }

}