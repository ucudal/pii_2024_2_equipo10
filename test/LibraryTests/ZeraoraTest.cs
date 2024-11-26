using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Zeraora"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Zeraora))]
public class ZeraoraTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Zeraora zeraora = new Zeraora();
        string zeraoraName = zeraora.Name;
        string expectedName = "Zeraora";
        Assert.That(zeraoraName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Zeraora zeraora = new Zeraora();
        Type zeraoraType = zeraora.GetTypes()[0];
        Type expectedType = Type.Electric;
        Assert.That(zeraoraType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Zeraora zeraora = new Zeraora();
        double zeraoraBaseLife = zeraora.BaseLife;
        double expectedBaseLife = 380;
        Assert.That(zeraoraBaseLife.Equals(expectedBaseLife));
        double zeraoraCurentLife = zeraora.CurrentLife;
        double expectedCurrentLife = 380;
        Assert.That(zeraoraCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Zeraora
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Zeraora zeraora = new Zeraora();
        List<IAttack> zeraoraAttacks = zeraora.GetAttacks();
        int expectedLenght = 4;
        Assert.That( zeraoraAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Zeraora
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Zeraora zeraora = new Zeraora();
        List<IAttack> zeraoraAttacks = zeraora.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        zeraora.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(zeraoraAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Zeraora zeraora = new Zeraora();
        State? zeraoraCurrentState = zeraora.CurrentState;
        Assert.That(zeraoraCurrentState.Equals(null));
        zeraora.EditState(State.Burned);
        State? zeraoraCurrentState2 = zeraora.CurrentState;
        Assert.That(zeraoraCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Zeraora zeraora = new Zeraora();
        int zeraoraCurrentState = zeraora.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(zeraoraCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Zeraora, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Zeraora zeraora = new Zeraora();
        Attack attack1 = zeraora.FindAttackByName("Plasma Fist");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Plasma Fist";
        Type attack1ExcpectedType = Type.Electric;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 65;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        Attack attack2 = zeraora.FindAttackByName("Thunderbolt");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Thunderbolt";
        Type attack2ExcpectedType = Type.Electric;
        double attack2ExcpectedAccuracy = 1;
        int attack2ExcpectedPower = 75;

        if (attack2 is SpecialAttack specialAttack2)
        {
            State sAttack2SpecialEffect = specialAttack2.SpecialEffect;
            int sAttack2Cooldown = specialAttack2.Cooldown;
            State attack2ExcpectedSpecialEffect = State.Paralized;
            int attack2ExcpectedCooldown = 0;
            Assert.That(sAttack2SpecialEffect.Equals(attack2ExcpectedSpecialEffect));
            Assert.That(sAttack2Cooldown.Equals(attack2ExcpectedCooldown));

        }
        
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        Attack attack3 = zeraora.FindAttackByName("Close Combat");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Close Combat";
        Type attack3ExcpectedType = Type.Fighting;
        double attack3ExcpectedAccuracy = 0.75;
        int attack3ExcpectedPower = 120;
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));

        Attack attack4 = zeraora.FindAttackByName("Wild Charge");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Wild Charge";
        Type attack4ExcpectedType = Type.Electric;
        double attack4ExcpectedAccuracy = 0.6;
        int attack4ExcpectedPower = 160;
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
        Zeraora zeraora = new Zeraora();
        double actualLife = zeraora.CurrentLife;
        string actualLifeText = zeraora.GetLife();
        zeraora.GainLife(100);
        Assert.That(actualLife.Equals(zeraora.BaseLife));
        Assert.That(actualLifeText.Equals("380/380", StringComparison.Ordinal));
        zeraora.TakeDamage(120);
        double actualLife2 = zeraora.CurrentLife;
        string actualLifeText2 = zeraora.GetLife();
        Assert.That(actualLife2.Equals(260));
        Assert.That(actualLifeText2.Equals("260/380", StringComparison.Ordinal));
        zeraora.GainLife(100);
        double actualLife3 = zeraora.CurrentLife;
        string actualLifeText3 = zeraora.GetLife();
        Assert.That(actualLife3.Equals(360));
        Assert.That(actualLifeText3.Equals("360/380", StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del método Instance
    /// </summary>
    [Test]
    public void TestInstance()
    {
        Zeraora zeraora = new Zeraora();
        Pokemon zeraoraClone = zeraora.Instance();
        Assert.That(zeraoraClone,Is.TypeOf<Zeraora>());
    }
}