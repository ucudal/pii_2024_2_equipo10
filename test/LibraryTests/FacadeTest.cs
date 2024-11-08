using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Charizard))]
public class FacadeTest
{
    /// <summary>
    /// Test de la historia de usuario 2.
    /// </summary>
    [Test]
    public void TestShowAttacks()
    {
        Facade.AddPlayerToWaitingList("mateo");
        Facade.AddPlayerToWaitingList("ines");
        Facade.CreateGame("mateo", "ines");
        Facade.StartBattle("mateo", "ines");
        Facade.ChooseTeam("mateo", "Caterpie");
        string result = "Bug bite\nTackle\nBug Stomp\nString Shot";
        Assert.That(Facade.ShowAtacks("mateo"), Is.EqualTo(result));
    }
}