using System.Security.AccessControl;
using Library;
using NUnit.Framework;
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
    public void TestUserStory1Add1Pokemon()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("mateo", "ines");
        string result = "El pokemon Caterpie fue añadido al equipo de mateo.\nElegiste 1/6";
        Assert.That(Facade.ChooseTeam("mateo", "Caterpie"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1RepeatedPokemon()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("mateo", "ines");
        Facade.ChooseTeam("mateo", "Caterpie");
        string result = "El pokemon Caterpie ya está en el equipo de mateo, no puedes volver a añadirlo";
        Assert.That(Facade.ChooseTeam("mateo", "Caterpie"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1LastPokemon()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("mateo", "ines");
        Facade.ChooseTeam("mateo", "Caterpie");
        Facade.ChooseTeam("mateo", "Charizard");
        Facade.ChooseTeam("mateo", "Gengar");
        Facade.ChooseTeam("mateo", "Dragonite");
        Facade.ChooseTeam("mateo", "Haxorus");

        string result = $"El pokemon Pikachu fue añadido al equipo de mateo\nTu equipo está completo.";
        Assert.That(Facade.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1FullTeam()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("mateo", "ines");
        Facade.ChooseTeam("mateo", "Caterpie");
        Facade.ChooseTeam("mateo", "Charizard");
        Facade.ChooseTeam("mateo", "Gengar");
        Facade.ChooseTeam("mateo", "Dragonite");
        Facade.ChooseTeam("mateo", "Haxorus");
        Facade.ChooseTeam("mateo", "Pikachu");

        string result = "mateo, ya tienes 6 pokemones en el equipo, no puedes elegir más";
        Assert.That(Facade.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1PlayerNotInGame()
    {
        string result = "mateo, para poder elegir un equipo, primero debes estar en una batalla";
        Assert.That(Facade.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }

    [Test]
    public void TestUserStory1UnknownPokemon()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("mateo", "ines");
        string result = "mateo, el pokemon Chocolate no fue encontrado";
        Assert.That(Facade.ChooseTeam("mateo", "Chocolate"), Is.EqualTo(result));
    }
    

    /// <summary>
    /// Test de la historia de usuario 2.
    /// </summary>
    [Test]
    public void TestUserStory2()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.StartGame("mateo", "ines");
        Facade.ChooseTeam("mateo", "Caterpie");
        string result =
            "Bug bite: tipo Bug, precisión 100, potencia 20\nTackle: tipo Normal, precisión 100, potencia 30\nBug stomp: tipo Bug, precisión 95, potencia 70, efecto especial Paralized, cooldown de uso 0\nString shot: tipo Bug, precisión 100, potencia 15\n";
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
        Facade.StartGame("facu", "ines");
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
        Facade.StartGame("facu", "ines");
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
        Facade.StartGame("facu", "ines");
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
        Facade.StartGame("facu", "ines");
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
        Facade.StartGame("facu", "ines");
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
        Facade.StartGame("facu", "ines");
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
        Assert.That(Facade.StartGame("facu", null), Is.EqualTo("No hay nadie esperando"));
        Assert.That(Facade.StartGame("facu", "ines"), Is.EqualTo("ines no está esperando"));
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Assert.That(Facade.StartGame("facu", "ines"), Is.EqualTo("Comienza facu vs ines"));
    }

    [Test]
    public void TestSurrender()
    {
        Facade.AddPlayerToWaitingList("Facu");
        string result1 = Facade.Surrender("Facu");
        Assert.That(result1, Is.EqualTo("Para rendirte primero debes estar en una batalla"));
        Facade.AddPlayerToWaitingList("Mati");
        Facade.StartGame("Facu", "Mati");
        string result2 = Facade.Surrender("Facu");
        Assert.That(result1, Is.EqualTo("Ganador: Mati. Perdedor: Facu"));
    }

}