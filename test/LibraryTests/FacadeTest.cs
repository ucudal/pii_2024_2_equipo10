using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Facade))]

public class FacadeTest
{
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
        Assert.That(Facade.ShowAtacks("mateo"), Is.EqualTo(result));
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
        Assert.That(Facade.ShowPokemonsHP("facu"), Is.EqualTo(result1));
        string result2 = "Chikorita: 294/294\n";
        Assert.That(Facade.ShowPokemonsHP("facu", "ines"), Is.EqualTo(result2));
    }
}