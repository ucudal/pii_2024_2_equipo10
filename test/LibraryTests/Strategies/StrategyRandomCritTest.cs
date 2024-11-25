using Library.Strategies;
using NUnit.Framework;

namespace LibraryTests.Strategies;

[TestFixture]
[TestOf(typeof(StrategyRandomCrit))]
public class StrategyRandomCritTest
{

    [Test]
    public void TestCriticalCheck()
    {
        IStrategyCritCheck critCheck = new StrategyRandomCrit();
        Assert.That(critCheck.CriticalCheck(),Is.InRange(1,1.20));
    }
}