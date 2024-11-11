using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'attack' del bot.
/// </summary>
public class AttackCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Envía a la fachada un mensaje con el ataque a utilizar.
    /// </summary>
    /// <param name="attack">Ataque a utilizar.</param>
    [Command("attack")]
    [Summary(
        """
        Ataca al Pokemon activo del otro jugador utilizando el ataque pasado
        por parámetro. Envía un mensaje con el resultado de la operación, si no 
        se pudo concretar el ataque el jugador pierde el turno.
        Este comando solo puede ser utilizado por un jugador mientras
        sea su turno.
        """)]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Ataque que desea utilizar.")]
        string attack)
    {
        
    }

}