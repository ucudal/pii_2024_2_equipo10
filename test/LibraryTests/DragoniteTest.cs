using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Dragonite"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Dragonite))]
public class DragoniteTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Dragonite dragonite = new Dragonite();
        string dragoniteName = dragonite.Name;
        string expectedName = "Dragonite";
        Assert.That(dragoniteName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Dragonite dragonite = new Dragonite();
        Type dragoniteType = dragonite.GetTypes()[0];
        Type expectedType = Type.Dragon;
        Assert.That(dragoniteType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Dragonite dragonite = new Dragonite();
        double dragoniteBaseLife = dragonite.BaseLife;
        double expectedBaseLife = 460;
        Assert.That(dragoniteBaseLife.Equals(expectedBaseLife));
        double dragoniteCurentLife = dragonite.CurrentLife;
        double expectedCurrentLife = 460;
        Assert.That(dragoniteCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Dragonite
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Dragonite dragonite = new Dragonite();
        List<IAttack> dragoniteAttacks = dragonite.GetAttacks();
        int expectedLenght = 4;
        Assert.That(dragoniteAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Dragonite
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Dragonite dragonite= new Dragonite();
        List<IAttack> dragoniteAttacks = dragonite.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        dragonite.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(dragoniteAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Dragonite dragonite = new Dragonite();
        State? dragoniteCurrentState = dragonite.CurrentState;
        Assert.That(dragoniteCurrentState.Equals(null));
        dragonite.EditState(State.Burned);
        State? dragoniteCurrentState2 = dragonite.CurrentState;
        Assert.That(dragoniteCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Dragonite dragonite = new Dragonite();
        int dragoniteCurrentState = dragonite.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(dragoniteCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Dragonite, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Dragonite dragonite = new Dragonite();
        Attack attack1 = dragonite.FindAttackByName("Wing Attack");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Wing Attack";
        Type attack1ExcpectedType = Type.Flying;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 60;
        
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        
        Attack attack2 = dragonite.FindAttackByName("Slam");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Slam";
        Type attack2ExcpectedType = Type.Normal;
        double attack2ExcpectedAccuracy = 0.75;
        int attack2ExcpectedPower = 80;
        
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        
        Attack attack3 = dragonite.FindAttackByName("Twister");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Twister";
        Type attack3ExcpectedType = Type.Dragon;
        double attack3ExcpectedAccuracy = 1;
        int attack3ExcpectedPower = 40;
        
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));
        
        if (attack3 is SpecialAttack specialAttack3)
        {
            State sAttack3SpecialEffect = specialAttack3.SpecialEffect;
            int sAttack3Cooldown = specialAttack3.Cooldown;
            State attack3ExcpectedSpecialEffect = State.Paralized;
            int attack2ExcpectedCooldown = 0;
            Assert.That(sAttack3SpecialEffect.Equals(attack3ExcpectedSpecialEffect));
            Assert.That(sAttack3Cooldown.Equals(attack2ExcpectedCooldown));

        }

        Attack attack4 = dragonite.FindAttackByName("Wrap");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Wrap";
        Type attack4ExcpectedType = Type.Normal;
        double attack4ExcpectedAccuracy = 0.9;
        int attack4ExcpectedPower = 15;
        
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
        Dragonite dragonite= new Dragonite();
        double actualLife = dragonite.CurrentLife;
        string actualLifeText = dragonite.GetLife();
        dragonite.GainLife(100);
        Assert.That(actualLife.Equals(dragonite.BaseLife));
        Assert.That(actualLifeText.Equals("460/460", StringComparison.Ordinal));
        dragonite.TakeDamage(120);
        double actualLife2 = dragonite.CurrentLife;
        string actualLifeText2 = dragonite.GetLife();
        Assert.That(actualLife2.Equals(340));
        Assert.That(actualLifeText2.Equals("340/460", StringComparison.Ordinal));
        dragonite.GainLife(100);
        double actualLife3 = dragonite.CurrentLife;
        string actualLifeText3 = dragonite.GetLife();
        Assert.That(actualLife3.Equals(440));
        Assert.That(actualLifeText3.Equals("440/460", StringComparison.Ordinal));
    }
    
    
    /// <summary>
    /// Test del método Instance
    /// </summary>
    [Test]
    public void TestInstance()
    {
        Dragonite dragonite = new Dragonite();
        Pokemon dragoniteClone = dragonite.Instance();
        Assert.That(dragoniteClone,Is.TypeOf<Dragonite>());
    }
    
}