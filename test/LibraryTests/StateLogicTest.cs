using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class StateLogicTest
{
    [Test]
    public void AsleepEffectDecreasesTurnsAndReturnsTrue()
    {
        Dragonite dragonite = new Dragonite()
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
        Dragonite dragonite = new Dragonite()
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
        Dragonite dragonite = new Dragonite();

        bool result = StateLogic.AsleepEffect(dragonite);
        
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void ParalizedEffectRandomness()
    {
        Jigglypuff jigglypuff = new Jigglypuff()
        {
            CurrentState = State.Paralized
        };

        int trueCount = 0;
        int iterations = 1000;

        for (int i = 0; i < iterations; i++)
        {
            if (StateLogic.ParalizedEffect(jigglypuff))
            {
                trueCount++;
            }
        }

        double probability = trueCount / (double)iterations;
        Assert.That(probability, Is.InRange(0.20, 0.30));
    }

    [Test]
    public void PoisonedEffectDecreasesLife()
    {
        Pikachu pikachu = new Pikachu()
        {
            CurrentState = State.Poisoned,
            CurrentLife = 100.0
        };
        
        double poisonDamage = (int)(pikachu.BaseLife * 0.05);
        double result = pikachu.CurrentLife - poisonDamage;
        
        StateLogic.PoisonedEffect(pikachu);
        Assert.That(pikachu.CurrentLife, Is.EqualTo(result));
    }

    [Test]
    public void BurnedEffectDecreaseLife()
    {
        Pikachu pikachu = new Pikachu()
        {
            CurrentState = State.Burned,
            CurrentLife = 100.0
        };
        
        double burnDamage = (int)(pikachu.BaseLife * 0.10);
        double result = pikachu.CurrentLife - burnDamage;
        
        StateLogic.BurnedEffect(pikachu);
        Assert.That(pikachu.CurrentLife, Is.EqualTo(result));
    }

}