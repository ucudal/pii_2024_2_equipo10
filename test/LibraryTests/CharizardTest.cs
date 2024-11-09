using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;
/// <summary>
/// Test de la clase <see cref="Charizard"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Charizard))]
public class CharizardTest
{

    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Charizard charizard = new Charizard();
        string charizardName = charizard.Name;
        string expectedName = "Charizard";
        Assert.That(charizardName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Charizard charizard = new Charizard();
        Type charizardType = charizard.GetTypes()[0];
        Type expectedType = Type.Fire;
        Assert.That(charizardType.Equals(expectedType));
    }
    
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Charizard charizard = new Charizard();
        double charizardBaseLife = charizard.BaseLife;
        double expectedBaseLife = 360;
        Assert.That(charizardBaseLife.Equals(expectedBaseLife));
        double charizardCurentLife = charizard.CurrentLife;
        double expectedCurrentLife = 360;
        Assert.That(charizardCurentLife.Equals(expectedCurrentLife));
    }
    
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Charizard
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Charizard charizard = new Charizard();
        List<IAttack> charizardAttacks = charizard.GetAttacks();
        int expectedLenght = 4;
        Assert.That(charizardAttacks.Count.Equals(expectedLenght));
    }
    
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Charizard
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Charizard charizard = new Charizard();
        List<IAttack> charizardAttacks = charizard.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        charizard.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(charizardAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Charizard charizard = new Charizard();
        State? charizardCurrentState = charizard.CurrentState;
        Assert.That(charizardCurrentState.Equals(null));
        charizard.EditState(State.Burned);
        State? charizardCurrentState2 = charizard.CurrentState;
        Assert.That(charizardCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Charizard charizard = new Charizard();
        int charizardCurrentState = charizard.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(charizardCurrentState.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de los ataques que tiene Charizard, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Charizard charizard = new Charizard();
        Attack attack1 = charizard.FindAttackByName("Dragon claw");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Dragon claw";
        Type attack1ExcpectedType = Type.Dragon;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 55;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        Attack attack2 = charizard.FindAttackByName("Flamethrower");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Flamethrower";
        Type attack2ExcpectedType = Type.Fire;
        double attack2ExcpectedAccuracy = 0.95;
        int attack2ExcpectedPower = 75;
        if (attack2 is SpecialAttack specialAttack2)
        {
            State sAttack2SpecialEffect = specialAttack2.SpecialEffect;
            int sAttack2Cooldown = specialAttack2.Cooldown;
            State attack2ExcpectedSpecialEffect = State.Burned;
            int attack2ExcpectedCooldown = 0;
            Assert.That(sAttack2SpecialEffect.Equals(attack2ExcpectedSpecialEffect));
            Assert.That(sAttack2Cooldown.Equals(attack2ExcpectedCooldown));

        }
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        Attack attack3 = charizard.FindAttackByName("Wing Attack");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Wing Attack";
        Type attack3ExcpectedType = Type.Flying;
        double attack3ExcpectedAccuracy = 0.9;
        int attack3ExcpectedPower = 40;
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));
        Attack attack4 = charizard.FindAttackByName("Fire punch");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Fire punch";
        Type attack4ExcpectedType = Type.Fire;
        double attack4ExcpectedAccuracy = 1;
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
        Charizard charizard = new Charizard();
        double actualLife = charizard.CurrentLife;
        string actualLifeText = charizard.GetLife();
        charizard.GainLife(100);
        Assert.That(actualLife.Equals(charizard.BaseLife));
        Assert.That(actualLifeText.Equals("360/360", StringComparison.Ordinal));
        charizard.TakeDamage(120);
        double actualLife2 = charizard.CurrentLife;
        string actualLifeText2 = charizard.GetLife();
        Assert.That(actualLife2.Equals(240));
        Assert.That(actualLifeText2.Equals("240/360", StringComparison.Ordinal));
        charizard.GainLife(100);
        double actualLife3 = charizard.CurrentLife;
        string actualLifeText3 = charizard.GetLife();
        Assert.That(actualLife3.Equals(340));
        Assert.That(actualLifeText3.Equals("340/360", StringComparison.Ordinal));
    }

    /// <summary>
    /// Test del método FindAttackByName
    /// </summary>
    [Test]
    public void TestFindAttackByName()
    {
        Charizard charizard = new Charizard();
        Attack attack = charizard.FindAttackByName("Dragon claw");
        string attack1Name = attack.Name;
        Type attack1Type = attack.Type;
        double attack1Accuracy = attack.Accuracy;
        int attack1Power = attack.Power;
        string attack1ExcpectedName = "Dragon claw";
        Type attack1ExcpectedType = Type.Dragon;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 55;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
    }
}