using Library.Strategies;
using NUnit.Framework;

namespace LibraryTests.Strategies;

[TestFixture]
[TestOf(typeof(StrategyRandomStartingPlayer))]
public class StrategyRandomStartingPlayerTest
{

    [Test]
    public void TestStartingPlayer()
    {
        StrategyRandomStartingPlayer strategyStartingPlayer = new StrategyRandomStartingPlayer();
        Assert.That(strategyStartingPlayer.StartingPlayer(),Is.InRange(0,1));
    }
}