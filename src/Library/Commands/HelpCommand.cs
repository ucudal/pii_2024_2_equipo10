using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'help' del bot.
/// </summary>
public class HelpCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra todos los comandos que el usuario puede utilizar junto a una breve descripcion.
    /// </summary>
    [Command("help")]
    [Summary(
        """
        Muestra todos los comandos que el usuario puede utilizar junto a una breve descripcion.
        """)]
    public async Task ExecuteAsync()
    {
        string help = "**Comandos disponibles:**\n" +
                      "\n" +
                      "**!attack** <**nombre del ataque**>\n(Ataca al rival con el ataque que quieras)\n" +
                      "\n" +
                      "**!battle**\n" +
                      "(Inicia la batalla con un jugador aleatorio)\n" +
                      "\n" +
                      "**!battle** <**nombre de jugador**>\n" +
                      "(Inicia la batalla con el jugador que ingreses)\n" +
                      "\n" +
                      "**!catalogue**\n" +
                      "(Muestra los pokemon del catalogo)\n" +
                      "\n" +
                      "**!change** <**nombre del pokemon**>\n" +
                      "(Cambia el pokemon activo por el que ingreses)\n" +
                      "\n" +
                      "**!checkturn**\n" +
                      "(Verifica de quien es el turno)\n" +
                      "\n" +
                      "**!choose** <**nombre del pokemon**>\n" +
                      "(Introduce en tu equipo el pokemon que ingreses)\n" +
                      "\n" +
                      "**!chooserandom** \n" +
                      "(Completa tu equipo Pokemon aleatoriamente)\n" +
                      "\n" +
                      "**!help**\n" +
                      "(Muestra los comandos disponibles)\n" +
                      "\n" +
                      "**!hp**\n" +
                      "(Muestra la vida de tus pokemon)\n" +
                      "\n" +
                      "**!hp** <**nombre del rival**>\n" +
                      "(Muestra la vida de los pokemon del rival)\n" +
                      "\n" +
                      "**!join**\n" +
                      "(Te agrega a la lista de espera)\n" +
                      "\n" +
                      "**!leave**\n" +
                      "(Te saca de la lista de espera)\n" +
                      "\n" +
                      "**!showattacks**\n" +
                      "(Muestra los ataques disponibles de tu pokemon activo)\n" +
                      "\n" +
                      "**!showitems**\n" +
                      "(Muestra los items disponibles que tenes)\n" +
                      "\n" +
                      "**!surrender**\n" +
                      "(Rendirse)\n" +
                      "\n" +
                      "**!use** <**item**> <**pokemon**>\n" +
                      "(Usa un item en el pokemon que quieras)\n" +
                      "\n" +
                      "**!waitinglist**\n" +
                      "(Muestra los usuarios en la lista de espera)\n" +
                      "\n";
        await ReplyAsync(help);

    }
}