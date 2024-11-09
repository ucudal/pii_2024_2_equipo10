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
    public void TestUserStory1()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.CreateGame("mateo", "ines");
        Facade.StartBattle("mateo", "ines");
        string result = "El pokemon Caterpie fue añadido al equipo";
        Assert.That(Facade.ChooseTeam("mateo", "Caterpie"), Is.EqualTo(result));
    }
    
    /// <summary>
    /// Test de la historia de usuario 2.
    /// </summary>
    [Test]
    public void TestUserStory2()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.CreateGame("mateo", "ines");
        Facade.StartBattle("mateo", "ines");
        Facade.ChooseTeam("mateo", "Caterpie");
        string result = "Bug bite\nTackle\nBug stomp\nString shot\n";
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
        Facade.CreateGame("facu", "ines");
        Facade.StartBattle("facu", "ines");
        Facade.ChooseTeam("facu", "Charizard");
        Facade.ChooseTeam("ines", "Chikorita");
        string result1 = "Charizard: 360/360\n";
        Assert.That(Facade.ShowPokemonsHp("facu"), Is.EqualTo(result1));
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
        Facade.CreateGame("facu", "ines");
        Facade.StartBattle("facu", "ines");
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
        Facade.CreateGame("facu", "ines");
        Facade.StartBattle("facu", "ines");
        Assert.That(Facade.CheckTurn("facu"), Is.EqualTo("Es tu turno:\n1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)"));
        Assert.That(Facade.CheckTurn("ines"), Is.EqualTo("No es tu turno, las opciones disponibles cuando sea tu turno son:\n1- !Attack (ver los ataques con el pokemon activo)\n 2- !Item (ver los items disponibles)\n 3- !Change (ver pokemons disp. a cambiar)"));
    }
    
    
    /// <summary>
    /// Test de la historia de usuario 6.
    /// </summary>
    [Test]
    public void TestUserStory6()
    {
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Facade.CreateGame("facu", "ines");
        Facade.StartBattle("facu", "ines");
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
        Facade.CreateGame("facu", "ines");
        Facade.StartBattle("facu", "ines");
        Facade.ChooseTeam("facu", "Charizard");
        Facade.ChooseTeam("facu", "Gengar");
        Facade.ChooseTeam("ines", "Chikorita");
        string asd = Facade.ChangePokemon("facu", "Gengar");
        string change = "No eres el jugador activo, no puedes realizar acciones";
        Assert.That(asd, Is.EqualTo(change));
        string asd1 = Facade.ChangePokemon("facu", "Gengar");
        string change1 = "Tu equipo pokemon está incompleto, elige hasta tener 6 pokemones en tu equipo";
        Assert.That(asd1, Is.EqualTo(change1));
        Facade.ChooseTeam("ines", "Zeraora");
        Facade.ChooseTeam("ines", "Caterpie");
        Facade.ChooseTeam("ines", "Mewtwo");
        Facade.ChooseTeam("ines", "Gengar");
        Facade.ChooseTeam("ines", "Haxorus");
        string change2 = Facade.ChangePokemon("ines","Mewtwo");
        string excpected = "Ese ya es tu pokemon activo";
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
        Facade.CreateGame("facu", "ines");
        Facade.StartBattle("facu", "ines");
        Facade.ChooseTeam("facu", "Charizard");
        string excpected = Facade.UseAnItem("facu", "SuperPotion", "Charizard");
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
        Assert.That(Facade.GetAllPlayersWaiting(),Is.EqualTo("Esperan: facu; ines; "));
    }
    
    
    /// <summary>
    /// Test de la historia de usuario 11.
    /// </summary>
    [Test]
    public void TestUserStory11()
    {
        Assert.That(Facade.StartBattle("facu",null), Is.EqualTo("No hay nadie esperando"));
        Assert.That(Facade.StartBattle("facu","ines"), Is.EqualTo("ines no está esperando"));
        Facade.AddPlayerToWaitingList("facu");
        Facade.AddPlayerToWaitingList("ines");
        Assert.That(Facade.StartBattle("facu", "ines"), Is.EqualTo("Comienza facu vs ines"));
    }
    
}