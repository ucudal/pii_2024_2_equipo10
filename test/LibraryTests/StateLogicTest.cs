using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class StateLogicTest
{
    /// <summary>
    /// Verifica que la lógica de AsleepEffect disminuya correctamente los AsleepTurn
    /// del Pokemon y devuelva true si aún está dormido.
    /// /// </summary>
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

    /// <summary>
    /// Verifica que la lógica de AsleepEffect despierte al Pokemon 
    /// (estableciendo su estado en null) y devuelva false si su AsleepTurns llega a 0.    /// </summary>
    [Test]
    public void AsleepEffectWakesPokemonAndReturnsFalse()
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

    /// Verifica que AsleepEffect devuelva false si el Pokemon no está dormido.
    [Test]
    public void AsleepEffectIsNotSet()
    {
        Dragonite dragonite = new Dragonite();

        bool result = StateLogic.AsleepEffect(dragonite);
        
        Assert.That(result, Is.EqualTo(false));
    }

    /// <summary>
    /// Verifica que la probabilidad de que ParalizedEffect devuelva true 
    /// se mantenga  dentro del rango esperado (25% con tolerancia).
    /// </summary>
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

    /// <summary>
    /// Verifica que PoisonedEffect reduzca correctamente la vida actual de un Pokemon envenenado,
    /// basado en su vida base.
    /// </summary>
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

    /// <summary>
    /// Verifica que BurnedEffect reduzca correctamente la vida actual de un Pokemon quemado,
    /// basado en su vida base.
    /// </summary>
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