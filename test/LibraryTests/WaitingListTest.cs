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
    /// Test del método AddPlayer
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
    /// Test del método RemovePlayer
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
    /// Test del método FindPlayerByName
    /// </summary>
    [Test]
    public void TestFindPlayerByName()
    {
        waitingList.AddPlayer("jugador1");
        Assert.That(waitingList.FindPlayerByName("jugador1").Name, Is.EqualTo("jugador1"));
        Assert.That(waitingList.FindPlayerByName(""), Is.Null);
    }
    /// <summary>
    /// Test del método GetSomeone
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
    /// Test del método GetWaitingList
    /// </summary>
    [Test]
    public void TestGetWaitingList()
    {
        Assert.That(waitingList.GetWaitingList(), Is.Empty);
        
        waitingList.AddPlayer("Player1");
        Assert.That(waitingList.GetWaitingList().Count, Is.EqualTo(1));
    }
}