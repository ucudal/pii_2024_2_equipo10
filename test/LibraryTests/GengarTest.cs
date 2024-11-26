using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Gengar"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Gengar))]
public class GengarTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Gengar gengar = new Gengar();
        string gengarName = gengar.Name;
        string expectedName = "Gengar";
        Assert.That(gengarName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Gengar gengar = new Gengar();
        Type gengarType = gengar.GetTypes()[0];
        Type expectedType = Type.Ghost;
        Assert.That(gengarType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Gengar gengar = new Gengar();
        double gengarBaseLife = gengar.BaseLife;
        double expectedBaseLife = 324;
        Assert.That(gengarBaseLife.Equals(expectedBaseLife));
        double gengarCurentLife = gengar.CurrentLife;
        double expectedCurrentLife = 324;
        Assert.That(gengarCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Gengar
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Gengar gengar = new Gengar();
        List<IAttack> gengarAttacks = gengar.GetAttacks();
        int expectedLenght = 4;
        Assert.That( gengarAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Gengar
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Gengar gengar= new Gengar();
        List<IAttack> gengarAttacks = gengar.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        gengar.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(gengarAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Gengar gengar = new Gengar();
        State? gengarCurrentState = gengar.CurrentState;
        Assert.That(gengarCurrentState.Equals(null));
        gengar.EditState(State.Burned);
        State? gengarCurrentState2 = gengar.CurrentState;
        Assert.That(gengarCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Gengar gengar = new Gengar();
        int gengarCurrentState = gengar.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(gengarCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Gengar, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Gengar gengar = new Gengar();
        Attack attack1 = gengar.FindAttackByName("Shadow Ball");
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
        Attack attack2 = gengar.FindAttackByName("Sludge Bomb");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Sludge Bomb";
        Type attack2ExcpectedType = Type.Poison;
        double attack2ExcpectedAccuracy = 0.95;
        int attack2ExcpectedPower = 70;
        
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        if (attack2 is SpecialAttack specialAttack2)
        {
            State sAttack2SpecialEffect = specialAttack2.SpecialEffect;
            int sAttack2Cooldown = specialAttack2.Cooldown;
            State attack2ExcpectedSpecialEffect = State.Poisoned;
            int attack2ExcpectedCooldown = 0;
            Assert.That(sAttack2SpecialEffect.Equals(attack2ExcpectedSpecialEffect));
            Assert.That(sAttack2Cooldown.Equals(attack2ExcpectedCooldown));

        }
        Attack attack3 = gengar.FindAttackByName("Shadow Punch");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Shadow Punch";
        Type attack3ExcpectedType = Type.Ghost;
        double attack3ExcpectedAccuracy = 0.75;
        int attack3ExcpectedPower = 100;
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));

        Attack attack4 = gengar.FindAttackByName("Focus Punch");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Focus Punch";
        Type attack4ExcpectedType = Type.Normal;
        double attack4ExcpectedAccuracy = 0.45;
        int attack4ExcpectedPower = 155;
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
        Gengar gengar= new Gengar();
        double actualLife = gengar.CurrentLife;
        string actualLifeText = gengar.GetLife();
        gengar.GainLife(100);
        Assert.That(actualLife.Equals(gengar.BaseLife));
        Assert.That(actualLifeText.Equals("324/324", StringComparison.Ordinal));
        gengar.TakeDamage(120);
        double actualLife2 = gengar.CurrentLife;
        string actualLifeText2 = gengar.GetLife();
        Assert.That(actualLife2.Equals(204));
        Assert.That(actualLifeText2.Equals("204/324", StringComparison.Ordinal));
        gengar.GainLife(100);
        double actualLife3 = gengar.CurrentLife;
        string actualLifeText3 = gengar.GetLife();
        Assert.That(actualLife3.Equals(304));
        Assert.That(actualLifeText3.Equals("304/324", StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del método Instance
    /// </summary>
    [Test]
    public void TestInstance()
    {
        Gengar gengar = new Gengar();
        Pokemon gengarClone = gengar.Instance();
        Assert.That(gengarClone,Is.TypeOf<Gengar>());
    }
    
}