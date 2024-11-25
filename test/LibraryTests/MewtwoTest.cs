using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Mewtwo"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Mewtwo))]
public class MewtwoTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Mewtwo mewtwo = new Mewtwo();
        string mewtwoName = mewtwo.Name;
        string expectedName = "Mewtwo";
        Assert.That(mewtwoName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Mewtwo mewtwo = new Mewtwo();
        Type mewtwoType = mewtwo.GetTypes()[0];
        Type expectedType = Type.Psychic;
        Assert.That(mewtwoType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Mewtwo mewtwo = new Mewtwo();
        double mewtwoBaseLife = mewtwo.BaseLife;
        double expectedBaseLife = 416;
        Assert.That(mewtwoBaseLife.Equals(expectedBaseLife));
        double mewtwoCurentLife = mewtwo.CurrentLife;
        double expectedCurrentLife = 416;
        Assert.That(mewtwoCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Mewtwo
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Mewtwo mewtwo = new Mewtwo();
        List<IAttack> mewtwoAttacks = mewtwo.GetAttacks();
        int expectedLenght = 4;
        Assert.That( mewtwoAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Mewtwo
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Mewtwo mewtwo = new Mewtwo();
        List<IAttack> mewtwoAttacks = mewtwo.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        mewtwo.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(mewtwoAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Mewtwo mewtwo = new Mewtwo();
        State? mewtwoCurrentState = mewtwo.CurrentState;
        Assert.That(mewtwoCurrentState.Equals(null));
        mewtwo.EditState(State.Burned);
        State? mewtwoCurrentState2 = mewtwo.CurrentState;
        Assert.That(mewtwoCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Mewtwo mewtwo = new Mewtwo();
        int mewtwoCurrentState = mewtwo.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(mewtwoCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Mewtwo, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Mewtwo mewtwo = new Mewtwo();
        Attack attack1 = mewtwo.FindAttackByName("Shadow Ball");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Shadow Ball";
        Type attack1ExcpectedType = Type.Ghost;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 60;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        Attack attack2 = mewtwo.FindAttackByName("Psystrike");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Psystrike";
        Type attack2ExcpectedType = Type.Psychic;
        double attack2ExcpectedAccuracy = 1;
        int attack2ExcpectedPower = 100;
        
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        Attack attack3 = mewtwo.FindAttackByName("Mental Shock");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Mental Shock";
        Type attack3ExcpectedType = Type.Psychic;
        double attack3ExcpectedAccuracy = 0.75;
        int attack3ExcpectedPower = 100;
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));

        Attack attack4 = mewtwo.FindAttackByName("Drain Punch");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Drain Punch";
        Type attack4ExcpectedType = Type.Fighting;
        double attack4ExcpectedAccuracy = 0.95;
        int attack4ExcpectedPower = 80;
        Assert.That(attack4Name.Equals(attack4ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack4Type.Equals(attack4ExcpectedType));
        Assert.That(attack4Accuracy.Equals(attack4ExcpectedAccuracy));
        Assert.That(attack4Power.Equals(attack4ExcpectedPower));
    }
  
    /// <summary>
    /// Test de los métodos RestoreBaseLife, TakeDamage y GetLife
    /// </summary>
    [Test]
    public void TestRestoreBaseLifeTakeDamageAndGetLife()
    {
        Mewtwo mewtwo = new Mewtwo();
        double actualLife = mewtwo.CurrentLife;
        string actualLifeText = mewtwo.GetLife();
        mewtwo.GainLife(100);
        Assert.That(actualLife.Equals(mewtwo .BaseLife));
        Assert.That(actualLifeText.Equals("416/416", StringComparison.Ordinal));
        mewtwo.TakeDamage(120);
        double actualLife2 = mewtwo.CurrentLife;
        string actualLifeText2 = mewtwo.GetLife();
        Assert.That(actualLife2.Equals(296));
        Assert.That(actualLifeText2.Equals("296/416", StringComparison.Ordinal));
        mewtwo.GainLife(100);
        double actualLife3 = mewtwo.CurrentLife;
        string actualLifeText3 = mewtwo.GetLife();
        Assert.That(actualLife3.Equals(396));
        Assert.That(actualLifeText3.Equals("396/416", StringComparison.Ordinal));
    }

    [Test]
    public void TestInstance()
    {
        Mewtwo mewtwo = new Mewtwo();
        Pokemon mewtwoClone = mewtwo.Instance();
        Assert.That(mewtwoClone,Is.TypeOf<Mewtwo>());
    }
}