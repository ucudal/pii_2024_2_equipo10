using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Tests de la clase WaitingList
/// </summary>
[TestFixture]
[TestOf(typeof(WaitingList))]
public class WaitingListTest
{
    private WaitingList waitingList;

    [SetUp]
    public void SetUp()
    {
        waitingList = new WaitingList();
    }
    /// <summary>
    /// Verifica que los jugadores sean añadidos correctamente a la lista de espera y maneja los casos de jugadores duplicados y entradas inválidas.
    /// </summary>
    [Test]
    public void TestAddPlayer()
    {
        Assert.That(waitingList.AddPlayer("jugador1"));
        Assert.That(!waitingList.AddPlayer("jugador1"));
        
        Assert.That(waitingList.GetWaitingList()[0].Name, Is.EqualTo("jugador1"));
        Assert.That(waitingList.GetWaitingList().Count, Is.EqualTo(1));
        
        Assert.Throws<ArgumentException>(() => waitingList.AddPlayer(null));
        Assert.Throws<ArgumentException>(() => waitingList.AddPlayer(string.Empty));
    }
    /// <summary>
    /// Verifica que un jugador sea eliminado correctamente de la lista de espera.
    /// </summary>
    [Test]
    public void TestRemovePlayer()
    {
        Assert.That(!waitingList.RemovePlayer("jugador1"));
        waitingList.AddPlayer("jugador1");
        Assert.That(waitingList.RemovePlayer("jugador1"));
        Assert.That(waitingList.GetWaitingList().Count, Is.EqualTo(0));
    }
    /// <summary>
    /// Verifica que un jugador pueda ser encontrado correctamente por su nombre.
    /// </summary>
    [Test]
    public void TestFindPlayerByName()
    {
        waitingList.AddPlayer("jugador1");
        Assert.That(waitingList.FindPlayerByName("jugador1").Name, Is.EqualTo("jugador1"));
        Assert.That(waitingList.FindPlayerByName(""), Is.Null);
    }
    /// <summary>
    /// Verifica que el método pueda agregar correctamente a otro jugador de la lista de espera.
    /// </summary>
    [Test]
    public void TestGetSomeone()
    {
        Assert.That(waitingList.GetSomeone("Player1"), Is.Null);
        
        waitingList.AddPlayer("Player1");
        Assert.That(waitingList.GetSomeone("Player1"), Is.Null);
        
        waitingList.AddPlayer("Player1");
        waitingList.AddPlayer("Player2");
        waitingList.AddPlayer("Player3");
        Assert.That(waitingList.GetSomeone("Player1"), Is.Not.Null);
        Assert.That(waitingList.GetSomeone("Player1").Name, Is.Not.EqualTo("Player1"));
    }
    /// <summary>
    /// Verifica que se pueda obtener correctamente la lista de jugadores en espera.
    /// </summary>
    [Test]
    public void TestGetWaitingList()
    {
        Assert.That(waitingList.GetWaitingList(), Is.Empty);
        
        waitingList.AddPlayer("Player1");
        Assert.That(waitingList.GetWaitingList().Count, Is.EqualTo(1));
    }
}