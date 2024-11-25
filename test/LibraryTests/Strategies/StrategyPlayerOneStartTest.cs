using Library.Strategies;
using NUnit.Framework;

namespace LibraryTests.Strategies;

[TestFixture]
[TestOf(typeof(StrategyPlayerOneStart))]
public class StrategyPlayerOneStartTest
{

    [Test]
    public void TestStartingPlayer()
    {
        StrategyPlayerOneStart strategyStartingPlayer = new StrategyPlayerOneStart();
        Assert.That(strategyStartingPlayer.StartingPlayer(),Is.EqualTo(0));
    }
}