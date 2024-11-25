using Library.Strategies;
using NUnit.Framework;

namespace LibraryTests.Strategies;

[TestFixture]
[TestOf(typeof(StrategyNonCrit))]
public class StrategyNonCritTest
{

    [Test]
    public void TestCriticalCheck()
    {
        StrategyNonCrit critCheck = new StrategyNonCrit();
        Assert.That(critCheck.CriticalCheck(),Is.EqualTo(1));
    }
}