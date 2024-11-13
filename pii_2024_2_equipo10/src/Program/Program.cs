using Library;
using Ucu.Poo.DiscordBot.Services;

namespace Program;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Punto de entrada al programa.
    /// </summary>
    private static void Main()
    {
        // DemoFacade();
        DemoBot();
    }

    private static void DemoFacade()
    {
        Console.WriteLine(Facade.AddPlayerToWaitingList("player"));
        Console.WriteLine(Facade.AddPlayerToWaitingList("opponent"));
        Console.WriteLine(Facade.GetAllPlayersWaiting());
        Console.WriteLine(Facade.StartGame("player", "opponent"));
        Console.WriteLine(Facade.GetAllPlayersWaiting());
    }

    private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
}
