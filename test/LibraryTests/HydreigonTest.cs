using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Hydreigon"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Hydreigon))]
public class HydreigonTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Hydreigon hydreigon = new Hydreigon();
        string hydreigonName = hydreigon.Name;
        string expectedName = "Hydreigon";
        Assert.That(hydreigonName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Hydreigon hydreigon = new Hydreigon();
        Type hydreigonType = hydreigon.GetTypes()[0];
        Type expectedType = Type.Dragon;
        Assert.That(hydreigonType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Hydreigon hydreigon = new Hydreigon();
        double hydreigonBaseLife = hydreigon.BaseLife;
        double expectedBaseLife = 388;
        Assert.That(hydreigonBaseLife.Equals(expectedBaseLife));
        double hydreigonCurentLife = hydreigon.CurrentLife;
        double expectedCurrentLife = 388;
        Assert.That(hydreigonCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Hydreigon
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Hydreigon hydreigon = new Hydreigon();
        List<IAttack> hydreigonAttacks = hydreigon.GetAttacks();
        int expectedLenght = 4;
        Assert.That(hydreigonAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Hydreigon
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Hydreigon hydreigon= new Hydreigon();
        List<IAttack> hydreigonAttacks = hydreigon.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        hydreigon.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(hydreigonAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Hydreigon hydreigon = new Hydreigon();
        State? hydreigonCurrentState = hydreigon.CurrentState;
        Assert.That(hydreigonCurrentState.Equals(null));
        hydreigon.EditState(State.Burned);
        State? hydreigonCurrentState2 = hydreigon.CurrentState;
        Assert.That(hydreigonCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Hydreigon hydreigon = new Hydreigon();
        int hydreigonCurrentState = hydreigon.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(hydreigonCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Hydreigon, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Hydreigon hydreigon = new Hydreigon();
        Attack attack1 = hydreigon.FindAttackByName("Surf");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Surf";
        Type attack1ExcpectedType = Type.Water;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 80;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        
        Attack attack2 = hydreigon.FindAttackByName("Draco meteor");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Draco meteor";
        Type attack2ExcpectedType = Type.Dragon;
        double attack2ExcpectedAccuracy = 0.80;
        int attack2ExcpectedPower = 110;
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        
        Attack attack3 = hydreigon.FindAttackByName("Focus Blast");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Focus Blast";
        Type attack3ExcpectedType = Type.Fighting;
        double attack3ExcpectedAccuracy = 0.75;
        int attack3ExcpectedPower = 120;
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));

        Attack attack4 = hydreigon.FindAttackByName("Fire Blast");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Fire Blast";
        Type attack4ExcpectedType = Type.Fire;
        double attack4ExcpectedAccuracy = 0.85;
        int attack4ExcpectedPower = 100;
        Assert.That(attack4Name.Equals(attack4ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack4Type.Equals(attack4ExcpectedType));
        Assert.That(attack4Accuracy.Equals(attack4ExcpectedAccuracy));
        Assert.That(attack4Power.Equals(attack4ExcpectedPower));
        
        if (attack4 is SpecialAttack specialAttack2)
        {
            State sAttack2SpecialEffect = specialAttack2.SpecialEffect;
            int sAttack2Cooldown = specialAttack2.Cooldown;
            State attack2ExcpectedSpecialEffect = State.Burned;
            int attack2ExcpectedCooldown = 0;
            Assert.That(sAttack2SpecialEffect.Equals(attack2ExcpectedSpecialEffect));
            Assert.That(sAttack2Cooldown.Equals(attack2ExcpectedCooldown));

        }
        
    }
  
    /// <summary>
    /// Test de los métodos RestoreBaseLife, TakeDamage y GetLife
    /// </summary>
    [Test]
    public void TestRestoreBaseLifeTakeDamageAndGetLife()
    {
        Hydreigon hydreigon= new Hydreigon();
        double actualLife = hydreigon.CurrentLife;
        string actualLifeText = hydreigon.GetLife();
        hydreigon.GainLife(100);
        Assert.That(actualLife.Equals(hydreigon.BaseLife));
        Assert.That(actualLifeText.Equals("388/388", StringComparison.Ordinal));
        hydreigon.TakeDamage(120);
        double actualLife2 = hydreigon.CurrentLife;
        string actualLifeText2 = hydreigon.GetLife();
        Assert.That(actualLife2.Equals(268));
        Assert.That(actualLifeText2.Equals("268/388", StringComparison.Ordinal));
        hydreigon.GainLife(100);
        double actualLife3 = hydreigon.CurrentLife;
        string actualLifeText3 = hydreigon.GetLife();
        Assert.That(actualLife3.Equals(368));
        Assert.That(actualLifeText3.Equals("368/388", StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del método Instance
    /// </summary>
    [Test]
    public void TestInstance()
    {
        Hydreigon hydreigon = new Hydreigon();
        Pokemon hydreigonClone = hydreigon.Instance();
        Assert.That(hydreigonClone,Is.TypeOf<Hydreigon>());
    }
    
}