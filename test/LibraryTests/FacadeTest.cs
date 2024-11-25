using System.Security.AccessControl;
using Library;
using Library.Strategies;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using Type = System.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Facade"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Facade))]
public class FacadeTest
{
    /// <summary>
    /// Test de la historia de usuario 1.
    /// </summary>
    [Test]
    public void TestUserStory1()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        string result = "El pokemon Caterpie fue añadido al equipo";
        Assert.That(Facade.ChooseTeam("mateo", "Caterpie"), Is.EqualTo(result));
    }

    /// <summary>
    /// Test de la historia de usuario 2.
    /// </summary>
    [Test]
    public void TestUserStory2()
    {
        Assert.That(Facade.ShowAtacks("mateo"), Is.EqualTo("mateo, no estás en ninguna partida."));
        
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("mateo", "ines",  new StrategyRandomStartingPlayer());
        
        Assert.That(Facade.ShowAtacks("mateo"), Is.EqualTo("mateo, no tienes ningun Pokemon."));
        
        Facade.ChooseTeam("mateo", "Caterpie");
        string result =
            "mateo, estos son los ataques de tu Pokemon activo:\n**Bug bite**: tipo *Bug*, precisión *100*, potencia *20*\n**Tackle**: tipo *Normal*, precisión *100*, potencia *30*\n**Bug stomp**: tipo *Bug*, precisión *95*, potencia *70*, efecto especial *Paralized*, cooldown de uso actual *0*\n**String shot**: tipo *Bug*, precisión *100*, potencia *15*\n";
        string mateo = Facade.ShowAtacks("mateo");
        Assert.That(mateo, Is.EqualTo(result));
    }

    /// <summary>
    /// Test de la historia de usuario 3.
    /// </summary>
    [Test]
    public void TestUserStory3()
    {
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.ChooseTeam("facu", "Charizard");
        Facade.ChooseTeam("ines", "Chikorita");
        string result1 = "Charizard: 360/360\n";
        Assert.That(Facade.ShowPokemonsHp("facu", null), Is.EqualTo(result1));
        string result2 = "Chikorita: 294/294\n";
        Assert.That(Facade.ShowPokemonsHp("facu", "ines"), Is.EqualTo(result2));
    }

    /// <summary>
    /// Test de la historia de usuario 4.
    /// </summary>
    [Test]
    public void TestUserStory4()
    {
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.ChooseTeam("facu", "Charizard");
        Facade.ChooseTeam("ines", "Chikorita");
        Facade.ChooseAttack("facu", "Flamethrower");
    }


    /// <summary>
    /// Test de la historia de usuario 5.
    /// </summary>
    [Test]
    public void TestUserStory5()
    {
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Assert.That(Facade.CheckTurn("facu"),
            Is.EqualTo(
                "Es tu turno:\n1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)"));
        Assert.That(Facade.CheckTurn("ines"),
            Is.EqualTo(
                "No es tu turno, las opciones disponibles cuando sea tu turno son:\n1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)"));
    }


    /// <summary>
    /// Test de la historia de usuario 6.
    /// </summary>
    [Test]
    public void TestUserStory6()
    {
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.ChooseTeam("facu", "Charizard");
        Facade.ChooseTeam("ines", "Chikorita");
        string attack = Facade.ChooseAttack("facu", "Flamethrower");
        string excpected = "El equipo está incompleto, por favor elige 6 pokemones para poder comenzar la batalla";
        Assert.That(attack.Equals(excpected, StringComparison.Ordinal));
        Facade.ChooseTeam("facu", "Zeraora");
        Facade.ChooseTeam("facu", "Caterpie");
        Facade.ChooseTeam("facu", "Mewtwo");
        Facade.ChooseTeam("facu", "Chikorita");
        Facade.ChooseTeam("facu", "Haxorus");
        string attack1 = Facade.ChooseAttack("facu", "Flamethrower");
        string excpected1 = $"Chikorita recibió 150 puntos de daño Próximo turno, ahora es el turno de ines";
        Assert.That(attack1.Equals(excpected1, StringComparison.Ordinal));
        string attack2 = Facade.ChooseAttack("facu", "Flamethrower");
        string excpected2 = "No eres el jugador activo";
        Assert.That(attack2.Equals(excpected2, StringComparison.Ordinal));

    }

    /// <summary>
    /// Test de la historia de usuario 7.
    /// </summary>
    [Test]
    public void TestUserStory7()
    {
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.ChooseTeam("facu", "Charizard");
        Facade.ChooseTeam("facu", "Gengar");
        Facade.ChooseTeam("ines", "Chikorita");
        string asd = Facade.ChangePokemon("facu", "Gengar");
        string change = "No eres el jugador activo, no puedes realizar acciones";
        Assert.That(asd, Is.EqualTo(change));
        string asd1 = Facade.ChangePokemon("facu", "Gengar");
        string change1 = "No eres el jugador activo, no puedes realizar acciones";
        Assert.That(asd1, Is.EqualTo(change1));
        Facade.ChooseTeam("ines", "Zeraora");
        Facade.ChooseTeam("ines", "Caterpie");
        Facade.ChooseTeam("ines", "Mewtwo");
        Facade.ChooseTeam("ines", "Gengar");
        Facade.ChooseTeam("ines", "Haxorus");
        string change2 = Facade.ChangePokemon("ines", "Mewtwo");
        string excpected = "Mewtwo es tu nuevo pokemon activo. Próximo turno ahora es el turno de facu";
        Assert.That(change1, Is.EqualTo(excpected));
    }


    /// <summary>
    /// Test de la historia de usuario 8.
    /// </summary>
    [Test]
    public void TestUserStory8()
    {
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.ChooseTeam("facu", "Charizard");
        string excpected = Facade.UseAnItem("facu", "Super Potion", "Charizard");
        Assert.That(excpected, Is.EqualTo("Charizard ha ganado 70HP."));
    }


    /// <summary>
    /// Test de la historia de usuario 9.
    /// </summary>
    [Test]
    public void TestUserStory9()
    {
        Assert.That(Facade.AddPlayerToWaitingList("facu"), Is.EqualTo("facu agregado a la lista de espera"));
        Assert.That(Facade.AddPlayerToWaitingList("facu"), Is.EqualTo("facu ya está en la lista de espera"));
    }


    /// <summary>
    /// Test de la historia de usuario 10.
    /// </summary>
    [Test]
    public void TestUserStory10()
    {
        Assert.That(Facade.GetAllPlayersWaiting(), Is.EqualTo("No hay nadie esperando"));
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Assert.That(Facade.GetAllPlayersWaiting(), Is.EqualTo("Esperan: facu; ines; "));
    }


    /// <summary>
    /// Test de la historia de usuario 11.
    /// </summary>
    [Test]
    public void TestUserStory11()
    {
        Assert.That(Facade.StartGame("facu", null,  new StrategyRandomStartingPlayer()), Is.EqualTo("facu, no estás en la lista de espera"));
        Assert.That(Facade.StartGame("facu", "ines",  new StrategyRandomStartingPlayer()), Is.EqualTo("facu, no estás en la lista de espera"));
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Assert.That(Facade.StartGame("facu", "ines",  new StrategyRandomStartingPlayer()).Contains("Comienza facu Vs. ines"));
        Facade.AddPlayerToWaitingList("mateo");
        Assert.That(Facade.StartGame("facu", null, new StrategyRandomStartingPlayer()), Is.EqualTo("facu ya está en una partida"));
        Assert.That(Facade.StartGame("mateo", "facu", new StrategyRandomStartingPlayer()), Is.EqualTo("facu no está esperando"));
        Assert.That(Facade.StartGame("mateo", null, new StrategyRandomStartingPlayer()), Is.EqualTo("No hay nadie más en la lista de espera"));
        Facade.AddPlayerToWaitingList("mati");
        Assert.That(Facade.StartGame("mateo", null, new StrategyRandomStartingPlayer()).Contains("Comienza mateo Vs. mati"));
    }

    [Test]
    public void TestSurrender()
    {
        Facade.AddPlayerToWaitingList("Facu");
        string result1 = Facade.Surrender("Facu");
        Assert.That(result1, Is.EqualTo("Facu, Para rendirte primero debes estar en una batalla"));
        Facade.AddPlayerToWaitingList("Mati");
        Facade.StartGame("Facu", "Mati", new StrategyRandomStartingPlayer());
        string result2 = Facade.Surrender("Facu");
        Assert.That(result2, Is.EqualTo("El jugador Facu se ha rendido.\nGanador: Mati \nPerdedor: Facu"));
    }

    [Test]
    public void TestShowItems()
    {
        Assert.That(Facade.ShowItems("mateo"), Is.EqualTo(("mateo, no estás en una partida.")));
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("pepe");
        Facade.StartGame("mateo", "pepe", new StrategyPlayerOneStart());
        Assert.That(Facade.ShowItems("mateo"), Is.EqualTo("mateo, estos son tus items disponibles:\n1 Revive\n4 Super Potion\n2 Full Health\n"));
        Facade.ChooseTeam("mateo", "Pikachu");
        Facade.ChooseTeam("pepe", "Charizard");
        Facade.ChooseRandom("mateo");
        Facade.ChooseRandom("pepe");
        Facade.ChooseAttack("mateo", "Thunder Shock");
        Facade.UseAnItem("pepe", "Super Potion", "Charizard");
        Assert.That(Facade.ShowItems("pepe"), Is.EqualTo("pepe, estos son tus items disponibles:\n1 Revive\n3 Super Potion\n2 Full Health\n"));
    }

}