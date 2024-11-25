using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;
/// <summary>
/// Test de la clase <see cref="Chikorita"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Chikorita))]
public class ChikoritaTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Chikorita chikorita = new Chikorita();
        string chikoritaName = chikorita.Name;
        string expectedName = "Chikorita";
        Assert.That(chikoritaName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Chikorita chikorita = new Chikorita();
        Type chikoritaType = chikorita.GetTypes()[0];
        Type expectedType = Type.Grass;
        Assert.That(chikoritaType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Chikorita chikorita = new Chikorita();
        double chikoritaBaseLife = chikorita.BaseLife;
        double expectedBaseLife = 294;
        Assert.That(chikoritaBaseLife.Equals(expectedBaseLife));
        double chikoritaCurentLife = chikorita.CurrentLife;
        double expectedCurrentLife = 294;
        Assert.That(chikoritaCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Chikorita
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Chikorita chikorita = new Chikorita();
        List<IAttack> chikoritaAttacks = chikorita.GetAttacks();
        int expectedLenght = 4;
        Assert.That(chikoritaAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Chikorita
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Chikorita chikorita = new Chikorita();
        List<IAttack> chikoritaAttacks = chikorita.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        chikorita.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(chikoritaAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Chikorita chikorita = new Chikorita();
        State? chikoritaCurrentState = chikorita.CurrentState;
        Assert.That(chikoritaCurrentState.Equals(null));
        chikorita.EditState(State.Burned);
        State? chikoritaCurrentState2 = chikorita.CurrentState;
        Assert.That(chikoritaCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Chikorita chikorita = new Chikorita();
        int chikoritaCurrentState = chikorita.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(chikoritaCurrentState.Equals(expectedLenght));
    }

    
    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Chikorita, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Chikorita chikorita = new Chikorita();
        Attack attack1 = chikorita.FindAttackByName("Razor leaf");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Razor leaf";
        Type attack1ExcpectedType = Type.Grass;
        double attack1ExcpectedAccuracy = 0.9;
        int attack1ExcpectedPower = 35;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        Attack attack2 = chikorita.FindAttackByName("Giga Drain");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Giga Drain";
        Type attack2ExcpectedType = Type.Grass;
        double attack2ExcpectedAccuracy = 0.95;
        int attack2ExcpectedPower = 70;
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
        Attack attack3 = chikorita.FindAttackByName("Magical leaf");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Magical leaf";
        Type attack3ExcpectedType = Type.Grass;
        double attack3ExcpectedAccuracy = 1;
        int attack3ExcpectedPower = 45;
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));
        Attack attack4 = chikorita.FindAttackByName("Body slam");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Body slam";
        Type attack4ExcpectedType = Type.Normal;
        double attack4ExcpectedAccuracy = 1;
        int attack4ExcpectedPower = 55;
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
        Chikorita chikorita = new Chikorita();
        double actualLife = chikorita.CurrentLife;
        string actualLifeText = chikorita.GetLife();
        chikorita.GainLife(100);
        Assert.That(actualLife.Equals(chikorita.BaseLife));
        Assert.That(actualLifeText.Equals("294/294", StringComparison.Ordinal));
        chikorita.TakeDamage(120);
        double actualLife2 = chikorita.CurrentLife;
        string actualLifeText2 = chikorita.GetLife();
        Assert.That(actualLife2.Equals(174));
        Assert.That(actualLifeText2.Equals("174/294", StringComparison.Ordinal));
        chikorita.GainLife(100);
        double actualLife3 = chikorita.CurrentLife;
        string actualLifeText3 = chikorita.GetLife();
        Assert.That(actualLife3.Equals(274));
        Assert.That(actualLifeText3.Equals("274/294", StringComparison.Ordinal));
    }
    
    [Test]
    public void TestInstance()
    {
        Chikorita chikorita = new Chikorita();
        Pokemon chikoritaClone = chikorita.Instance();
        Assert.That(chikoritaClone,Is.TypeOf<Chikorita>());
    }
    
}