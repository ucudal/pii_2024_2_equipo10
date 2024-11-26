using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Entei"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Entei))]
public class EnteiTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Entei entei = new Entei();
        string enteiName = entei.Name;
        string expectedName = "Entei";
        Assert.That(enteiName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Entei entei = new Entei();
        Type enteiType = entei.GetTypes()[0];
        Type expectedType = Type.Fire;
        Assert.That(enteiType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Entei entei = new Entei();
        double enteiBaseLife = entei.BaseLife;
        double expectedBaseLife = 490;
        Assert.That(enteiBaseLife.Equals(expectedBaseLife));
        double enteiCurentLife = entei.CurrentLife;
        double expectedCurrentLife = 490;
        Assert.That(enteiCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Entei
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Entei entei = new Entei();
        List<IAttack> enteiAttacks = entei.GetAttacks();
        int expectedLenght = 4;
        Assert.That(enteiAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Entei
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Entei entei= new Entei();
        List<IAttack> enteiAttacks = entei.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        entei.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(enteiAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Entei entei = new Entei();
        State? enteiCurrentState = entei.CurrentState;
        Assert.That(enteiCurrentState.Equals(null));
        entei.EditState(State.Burned);
        State? enteiCurrentState2 = entei.CurrentState;
        Assert.That(enteiCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Entei entei = new Entei();
        int enteiCurrentState = entei.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(enteiCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Entei, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Entei entei = new Entei();
        Attack attack1 = entei.FindAttackByName("Ember");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Ember";
        Type attack1ExcpectedType = Type.Fire;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 40;
        
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        
        Attack attack2 = entei.FindAttackByName("Stomp");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Stomp";
        Type attack2ExcpectedType = Type.Normal;
        double attack2ExcpectedAccuracy = 1;
        int attack2ExcpectedPower = 60;
        
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        
        Attack attack3 = entei.FindAttackByName("Will-O-Wisp");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Will-O-Wisp";
        Type attack3ExcpectedType = Type.Dragon;
        double attack3ExcpectedAccuracy = 1;
        int attack3ExcpectedPower = 0;
        
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));
        
        if (attack3 is SpecialAttack specialAttack3)
        {
            State sAttack2SpecialEffect = specialAttack3.SpecialEffect;
            int sAttack2Cooldown = specialAttack3.Cooldown;
            State attack2ExcpectedSpecialEffect = State.Burned;
            int attack2ExcpectedCooldown = 0;
            Assert.That(sAttack2SpecialEffect.Equals(attack2ExcpectedSpecialEffect));
            Assert.That(sAttack2Cooldown.Equals(attack2ExcpectedCooldown));

        }

        Attack attack4 = entei.FindAttackByName("Extrasensory");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Extrasensory";
        Type attack4ExcpectedType = Type.Psychic;
        double attack4ExcpectedAccuracy = 0.9;
        int attack4ExcpectedPower = 60;
        
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
        Entei entei= new Entei();
        double actualLife = entei.CurrentLife;
        string actualLifeText = entei.GetLife();
        entei.GainLife(100);
        Assert.That(actualLife.Equals(entei.BaseLife));
        Assert.That(actualLifeText.Equals("490/490", StringComparison.Ordinal));
        entei.TakeDamage(120);
        double actualLife2 = entei.CurrentLife;
        string actualLifeText2 = entei.GetLife();
        Assert.That(actualLife2.Equals(370));
        Assert.That(actualLifeText2.Equals("370/490", StringComparison.Ordinal));
        entei.GainLife(100);
        double actualLife3 = entei.CurrentLife;
        string actualLifeText3 = entei.GetLife();
        Assert.That(actualLife3.Equals(470));
        Assert.That(actualLifeText3.Equals("470/490", StringComparison.Ordinal));
    }
    
    [Test]
    public void TestInstance()
    {
        Entei entei = new Entei();
        Pokemon enteiClone = entei.Instance();
        Assert.That(enteiClone,Is.TypeOf<Entei>());
    }
    
}