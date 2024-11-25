using Library.Strategies;
using NUnit.Framework;

namespace LibraryTests.Strategies;

[TestFixture]
[TestOf(typeof(StrategyPlayerTwoStart))]
public class StrategyPlayerTwoStartTest
{

    [Test]
    public void TestStartingPlayer()
    {
        StrategyPlayerTwoStart strategyStartingPlayer = new StrategyPlayerTwoStart();
        Assert.That(strategyStartingPlayer.StartingPlayer(),Is.EqualTo(1));
    }
}