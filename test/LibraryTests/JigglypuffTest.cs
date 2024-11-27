using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Jigglypuff"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Jigglypuff))]
public class JigglypuffTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Jigglypuff jigglypuff = new Jigglypuff();
        string jigglypuffName = jigglypuff.Name;
        string expectedName = "Jigglypuff";
        Assert.That(jigglypuffName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Jigglypuff jigglypuff = new Jigglypuff();
        Type jigglypuffType = jigglypuff.GetTypes()[0];
        Type expectedType = Type.Normal;
        Assert.That(jigglypuffType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Jigglypuff jigglypuff = new Jigglypuff();
        double jigglypuffBaseLife = jigglypuff.BaseLife;
        double expectedBaseLife = 280;
        Assert.That(jigglypuffBaseLife.Equals(expectedBaseLife));
        double jigglypuffCurentLife = jigglypuff.CurrentLife;
        double expectedCurrentLife = 280;
        Assert.That(jigglypuffCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Jigglypuff
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Jigglypuff jigglypuff = new Jigglypuff();
        List<IAttack> jigglypuffAttacks = jigglypuff.GetAttacks();
        int expectedLenght = 4;
        Assert.That(jigglypuffAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Jigglypuff
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Jigglypuff jigglypuff= new Jigglypuff();
        List<IAttack> jigglypuffAttacks = jigglypuff.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        jigglypuff.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(jigglypuffAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Jigglypuff jigglypuff = new Jigglypuff();
        State? jigglypuffCurrentState = jigglypuff.CurrentState;
        Assert.That(jigglypuffCurrentState.Equals(null));
        jigglypuff.EditState(State.Burned);
        State? jigglypuffCurrentState2 = jigglypuff.CurrentState;
        Assert.That(jigglypuffCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Jigglypuff jigglypuff = new Jigglypuff();
        int jigglypuffCurrentState = jigglypuff.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(jigglypuffCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Jigglypuff, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Jigglypuff jigglypuff = new Jigglypuff();
        Attack attack1 = jigglypuff.FindAttackByName("Disarming Voice");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Disarming Voice";
        Type attack1ExcpectedType = Type.Normal;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 40;
        
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        
        Attack attack2 = jigglypuff.FindAttackByName("Pound");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Pound";
        Type attack2ExcpectedType = Type.Normal;
        double attack2ExcpectedAccuracy = 0.95;
        int attack2ExcpectedPower = 45;
        
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        
        Attack attack3 = jigglypuff.FindAttackByName("Rest");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Rest";
        Type attack3ExcpectedType = Type.Psychic;
        double attack3ExcpectedAccuracy = 0.95;
        int attack3ExcpectedPower = 30;
        
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));
        
        if (attack2 is SpecialAttack specialAttack2)
        {
            State sAttack2SpecialEffect = specialAttack2.SpecialEffect;
            int sAttack2Cooldown = specialAttack2.Cooldown;
            State attack2ExcpectedSpecialEffect = State.Asleep;
            int attack2ExcpectedCooldown = 0;
            Assert.That(sAttack2SpecialEffect.Equals(attack2ExcpectedSpecialEffect));
            Assert.That(sAttack2Cooldown.Equals(attack2ExcpectedCooldown));

        }

        Attack attack4 = jigglypuff.FindAttackByName("Covet");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Covet";
        Type attack4ExcpectedType = Type.Normal;
        double attack4ExcpectedAccuracy = 0.9;
        int attack4ExcpectedPower = 50;
        
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
        Jigglypuff jigglypuff= new Jigglypuff();
        double actualLife = jigglypuff.CurrentLife;
        string actualLifeText = jigglypuff.GetLife();
        jigglypuff.GainLife(100);
        Assert.That(actualLife.Equals(jigglypuff.BaseLife));
        Assert.That(actualLifeText.Equals("280/280", StringComparison.Ordinal));
        jigglypuff.TakeDamage(120);
        double actualLife2 = jigglypuff.CurrentLife;
        string actualLifeText2 = jigglypuff.GetLife();
        Assert.That(actualLife2.Equals(160));
        Assert.That(actualLifeText2.Equals("160/280", StringComparison.Ordinal));
        jigglypuff.GainLife(100);
        double actualLife3 = jigglypuff.CurrentLife;
        string actualLifeText3 = jigglypuff.GetLife();
        Assert.That(actualLife3.Equals(260));
        Assert.That(actualLifeText3.Equals("260/280", StringComparison.Ordinal));
    }
    
    [Test]
    public void TestInstance()
    {
        Jigglypuff jigglypuff = new Jigglypuff();
        Pokemon jigglypuffClone = jigglypuff.Instance();
        Assert.That(jigglypuffClone,Is.TypeOf<Jigglypuff>());
    }
    
}