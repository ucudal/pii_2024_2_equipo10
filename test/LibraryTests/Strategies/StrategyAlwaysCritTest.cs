using Library.Strategies;
using NUnit.Framework;

namespace LibraryTests.Strategies;

[TestFixture]
[TestOf(typeof(StrategyAlwaysCrit))]
public class StrategyAlwaysCritTest
{

    [Test]
    public void TestCriticalCheck()
    {
        StrategyAlwaysCrit critCheck = new StrategyAlwaysCrit();
        Assert.That(critCheck.CriticalCheck(),Is.EqualTo(1.20));
    }
}