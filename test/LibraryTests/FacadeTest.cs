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
    [SetUp]
    public void SetUp()
    {
        Facade.Instance.Reset();
    }
    
    /// <summary>
    /// Test de la historia de usuario 1.
    /// </summary>
    [Test]
    public void TestUserStory1Add1Pokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        string result = "El pokemon Caterpie fue añadido al equipo de mateo.\nElegiste 1/6";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Caterpie"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1RepeatedPokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("mateo", "Caterpie");
        string result = "El pokemon Caterpie ya está en el equipo de mateo, no puedes volver a añadirlo";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Caterpie"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1LastPokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("mateo", "Caterpie");
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");

        string result = $"El pokemon Pikachu fue añadido al equipo de mateo\nTu equipo está completo.";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1FullTeam()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("mateo", "Caterpie");
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");

        string result = "mateo, ya tienes 6 pokemones en el equipo, no puedes elegir más";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1PlayerNotInGame()
    {
        string result = "mateo, para poder elegir un equipo, primero debes estar en una batalla";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1UnknownPokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        string result = "mateo, el pokemon Chocolate no fue encontrado";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Chocolate"), Is.EqualTo(result));
    }
    

    /// <summary>
    /// Test de la historia de usuario 2.
    /// </summary>
    [Test]
    public void TestUserStory2()
    {
        Assert.That(Facade.Instance.ShowAtacks("mateo"), Is.EqualTo("mateo, no estás en ninguna partida."));
        
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines",  new StrategyRandomStartingPlayer());
        
        Assert.That(Facade.Instance.ShowAtacks("mateo"), Is.EqualTo("mateo, no tienes ningun Pokemon."));
        
        Facade.Instance.ChooseTeam("mateo", "Caterpie");
        string result =
            "mateo, estos son los ataques de tu Pokemon activo:\n**Bug bite**: tipo *Bug*, precisión *100*, potencia *20*\n**Tackle**: tipo *Normal*, precisión *100*, potencia *30*\n**Bug stomp**: tipo *Bug*, precisión *95*, potencia *70*, efecto especial *Paralized*, cooldown de uso actual *0*\n**String shot**: tipo *Bug*, precisión *100*, potencia *15*\n";
        string mateo = Facade.Instance.ShowAtacks("mateo");
        Assert.That(mateo, Is.EqualTo(result));
    }

    /// <summary>
    /// Test de la historia de usuario 3.
    /// </summary>
    [Test]
    public void TestUserStory3NullPlayer()
    {
        string result = "El jugador facu no está en ninguna partida.";
        Assert.That(Facade.Instance.ShowPokemonsHp("facu", null), Is.EqualTo(result));
    }
    
    [Test]
    public void TestUserStory31Pokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        string result1 = $"facu esta es la vida de tus Pokemons: \n**Charizard: 360/360 (Fire)**\n";
        Assert.That(Facade.Instance.ShowPokemonsHp("facu", null), Is.EqualTo(result1));
        string result2 = "ines aún no tiene su equipo completo.";
        Assert.That(Facade.Instance.ShowPokemonsHp("facu", "ines"), Is.EqualTo(result2));
    }

    [Test]

    public void TestUserStory3FullTeams()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");
        
        
        string result1 =
            "mateo esta es la vida de tus Pokemons: \n**Charizard: 360/360 (Fire)**\nChikorita: 294/294 (Grass)\n" +
            "Gengar: 324/324 (Ghost)\nDragonite: 460/460 (Dragon)\nHaxorus: 356/356 (Dragon)\nPikachu: 295/295 (Electric)\n";
        
        string result2 =
            "Esta es la vida de los Pokemons de ines: \n**Caterpie: 115/294 (Bug)** **(Burned)**\nChikorita: 294/294 (Grass)\n" +
            "Gengar: 324/324 (Ghost)\nDragonite: 460/460 (Dragon)\nHaxorus: 356/356 (Dragon)\nPikachu: 295/295 (Electric)\n";

        Facade.Instance.ChooseAttack("mateo", "Flamethrower");
        
        Assert.That(Facade.Instance.ShowPokemonsHp("mateo", null), Is.EqualTo(result1));
        Assert.That(Facade.Instance.ShowPokemonsHp("mateo", "ines"), Is.EqualTo(result2));
    }


    /// <summary>
    /// Test de la historia de usuario 4.
    /// </summary>
    [Test]
    public void TestUserStory4NullPlayer()
    {
        string result = Facade.Instance.ChooseAttack("facu", "Flamethrower");
        Assert.That(result, Is.EqualTo("facu, para poder atacar necesitas estar en una batalla."));
    }
    
    [Test]
    public void TestUserStory4IncompleteTeams()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseAttack("facu", "Flamethrower");
        string result = "facu, alguno de los jugadores no ha completado el equipo";
    }

    [Test]
    public void TestUserStory4FullTeams()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");

        string result1 = Facade.Instance.ChooseAttack("ines", "Bug bite");
        string result2 = Facade.Instance.ChooseAttack("mateo", "aaa");
        string expectedResult2 = "El ataque aaa no pudo ser encontrado";
        
        Assert.That(result1, Is.EqualTo("ines, no eres el jugador activo"));
        Assert.That(result2, Is.EqualTo(expectedResult2));
    }


    /// <summary>
    /// Test de la historia de usuario 5.
    /// </summary>
    [Test]
    public void TestUserStory5()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Assert.That(Facade.Instance.CheckTurn("facu"),
            Is.EqualTo(
                "Es tu turno:\n1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)"));
        Assert.That(Facade.Instance.CheckTurn("ines"),
            Is.EqualTo(
                "No es tu turno, las opciones disponibles cuando sea tu turno son:\n1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)"));
    }


    /// <summary>
    /// Test de la historia de usuario 6.
    /// </summary>
    [Test]
    public void TestUserStory6()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        string attack = Facade.Instance.ChooseAttack("facu", "Flamethrower");
        string excpected = "El equipo está incompleto, por favor elige 6 pokemones para poder comenzar la batalla";
        Assert.That(attack.Equals(excpected, StringComparison.Ordinal));
        Facade.Instance.ChooseTeam("facu", "Zeraora");
        Facade.Instance.ChooseTeam("facu", "Caterpie");
        Facade.Instance.ChooseTeam("facu", "Mewtwo");
        Facade.Instance.ChooseTeam("facu", "Chikorita");
        Facade.Instance.ChooseTeam("facu", "Haxorus");
        string attack1 = Facade.Instance.ChooseAttack("facu", "Flamethrower");
        string excpected1 = $"Chikorita recibió 150 puntos de daño Próximo turno, ahora es el turno de ines";
        Assert.That(attack1.Equals(excpected1, StringComparison.Ordinal));
        string attack2 = Facade.Instance.ChooseAttack("facu", "Flamethrower");
        string excpected2 = "No eres el jugador activo";
        Assert.That(attack2.Equals(excpected2, StringComparison.Ordinal));

    }

    /// <summary>
    /// Test de la historia de usuario 7.
    /// </summary>
    [Test]
    public void TestUserStory7()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        Facade.Instance.ChooseTeam("facu", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        string asd = Facade.Instance.ChangePokemon("facu", "Gengar");
        string change = "No eres el jugador activo, no puedes realizar acciones";
        Assert.That(asd, Is.EqualTo(change));
        string asd1 = Facade.Instance.ChangePokemon("facu", "Gengar");
        string change1 = "No eres el jugador activo, no puedes realizar acciones";
        Assert.That(asd1, Is.EqualTo(change1));
        Facade.Instance.ChooseTeam("ines", "Zeraora");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Mewtwo");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        string change2 = Facade.Instance.ChangePokemon("ines", "Mewtwo");
        string excpected = "Mewtwo es tu nuevo pokemon activo. Próximo turno ahora es el turno de facu";
        Assert.That(change1, Is.EqualTo(excpected));
    }


    /// <summary>
    /// Test de la historia de usuario 8.
    /// </summary>
    [Test]
    public void TestUserStory8()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        string excpected = Facade.Instance.UseAnItem("facu", "Super Potion", "Charizard");
        Assert.That(excpected, Is.EqualTo("Charizard ha ganado 70HP."));
    }


    /// <summary>
    /// Test de la historia de usuario 9.
    /// </summary>
    [Test]
    public void TestUserStory9()
    {
        Assert.That(Facade.Instance.AddPlayerToWaitingList("facu"), Is.EqualTo("facu agregado a la lista de espera"));
        Assert.That(Facade.Instance.AddPlayerToWaitingList("facu"), Is.EqualTo("facu ya está en la lista de espera"));
    }


    /// <summary>
    /// Test de la historia de usuario 10.
    /// </summary>
    [Test]
    public void TestUserStory10()
    {
        Assert.That(Facade.Instance.GetAllPlayersWaiting(), Is.EqualTo("No hay nadie esperando"));
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Assert.That(Facade.Instance.GetAllPlayersWaiting(), Is.EqualTo("Esperan: facu; ines; "));
    }


    /// <summary>
    /// Test de la historia de usuario 11.
    /// </summary>
    [Test]
    public void TestUserStory11()
    {
        Assert.That(Facade.Instance.StartGame("facu", null,  new StrategyRandomStartingPlayer()), Is.EqualTo("facu, no estás en la lista de espera"));
        Assert.That(Facade.Instance.StartGame("facu", "ines",  new StrategyRandomStartingPlayer()), Is.EqualTo("facu, no estás en la lista de espera"));
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Assert.That(Facade.Instance.StartGame("facu", "ines",  new StrategyRandomStartingPlayer()).Contains("Comienza facu Vs. ines"));
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Assert.That(Facade.Instance.StartGame("facu", null, new StrategyRandomStartingPlayer()), Is.EqualTo("facu ya está en una partida"));
        Assert.That(Facade.Instance.StartGame("mateo", "facu", new StrategyRandomStartingPlayer()), Is.EqualTo("facu no está esperando"));
        Assert.That(Facade.Instance.StartGame("mateo", null, new StrategyRandomStartingPlayer()), Is.EqualTo("No hay nadie más en la lista de espera"));
        Facade.Instance.AddPlayerToWaitingList("mati");
        Assert.That(Facade.Instance.StartGame("mateo", null, new StrategyRandomStartingPlayer()).Contains("Comienza mateo Vs. mati"));
    }

    [Test]
    public void TestSurrender()
    {
        Facade.Instance.AddPlayerToWaitingList("Facu");
        string result1 = Facade.Instance.Surrender("Facu");
        Assert.That(result1, Is.EqualTo("Facu, Para rendirte primero debes estar en una batalla"));
        Facade.Instance.AddPlayerToWaitingList("Mati");
        Facade.Instance.StartGame("Facu", "Mati", new StrategyRandomStartingPlayer());
        string result2 = Facade.Instance.Surrender("Facu");
        Assert.That(result2, Is.EqualTo("El jugador Facu se ha rendido.\nGanador: Mati \nPerdedor: Facu"));
    }

    [Test]
    public void TestShowItems()
    {
        Assert.That(Facade.Instance.ShowItems("mateo"), Is.EqualTo(("mateo, no estás en una partida.")));
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("pepe");
        Facade.Instance.StartGame("mateo", "pepe", new StrategyPlayerOneStart());
        Assert.That(Facade.Instance.ShowItems("mateo"), Is.EqualTo("mateo, estos son tus items disponibles:\n1 Revive\n4 Super Potion\n2 Full Health\n"));
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("pepe", "Charizard");
        Facade.Instance.ChooseRandom("mateo");
        Facade.Instance.ChooseRandom("pepe");
        Facade.Instance.ChooseAttack("mateo", "Thunder Shock");
        Facade.Instance.UseAnItem("pepe", "Super Potion", "Charizard");
        Assert.That(Facade.Instance.ShowItems("pepe"), Is.EqualTo("pepe, estos son tus items disponibles:\n1 Revive\n3 Super Potion\n2 Full Health\n"));
    }

}