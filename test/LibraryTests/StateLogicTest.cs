using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class StateLogicTest
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void AsleepEffectDecreasesTurnsAndReturnsTrue()
    {
        Pokemon dragonite = new Dragonite()
        {
            CurrentState = State.Asleep,
            AsleepTurns = 2
        };

        bool result = StateLogic.AsleepEffect(dragonite);

        Assert.That(result, Is.EqualTo(true));
        Assert.That(dragonite.AsleepTurns, Is.EqualTo(1));
    }

    [Test]
    public void AsleepEffectWakesPokemonWhenTurnsAreZero()
    {
        Pokemon dragonite = new Dragonite()
        {
            CurrentState = State.Asleep,
            AsleepTurns = 0
        };

        bool result = StateLogic.AsleepEffect(dragonite);

        Assert.That(result, Is.EqualTo(false));
        Assert.That(dragonite.CurrentState, Is.EqualTo(null));
    }

    [Test]
    public void AsleepEffectIsNotSet()
    {
        Pokemon dragonite = new Dragonite();

        bool result = StateLogic.AsleepEffect(dragonite);
        
        Assert.That(result, Is.EqualTo(false));
    }
    
    [Test]
    public void 
    
}