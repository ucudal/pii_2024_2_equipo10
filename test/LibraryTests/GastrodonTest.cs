using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Gastrodon"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Gastrodon))]
public class GastrodonTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Gastrodon gastrodon = new Gastrodon();
        string gastrodonName = gastrodon.Name;
        string expectedName = "Gastrodon";
        Assert.That(gastrodonName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Gastrodon gastrodon = new Gastrodon();
        Type gastrodonType = gastrodon.GetTypes()[0];
        Type expectedType = Type.Water;
        Assert.That(gastrodonType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Gastrodon gastrodon = new Gastrodon();
        double gastrodonBaseLife = gastrodon.BaseLife;
        double expectedBaseLife = 426;
        Assert.That(gastrodonBaseLife.Equals(expectedBaseLife));
        double gastrodonCurentLife = gastrodon.CurrentLife;
        double expectedCurrentLife = 426;
        Assert.That(gastrodonCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Gastrodon
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Gastrodon gastrodon = new Gastrodon();
        List<IAttack> gastrodonAttacks = gastrodon.GetAttacks();
        int expectedLenght = 4;
        Assert.That(gastrodonAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Gastrodon
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Gastrodon gastrodon= new Gastrodon();
        List<IAttack> gastrodonAttacks = gastrodon.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        gastrodon.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(gastrodonAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Gastrodon gastrodon = new Gastrodon();
        State? gastrodonCurrentState = gastrodon.CurrentState;
        Assert.That(gastrodonCurrentState.Equals(null));
        gastrodon.EditState(State.Burned);
        State? gastrodonCurrentState2 = gastrodon.CurrentState;
        Assert.That(gastrodonCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Gastrodon gastrodon = new Gastrodon();
        int gastrodonCurrentState = gastrodon.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(gastrodonCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Gastrodon, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Gastrodon gastrodon = new Gastrodon();
        Attack attack1 = gastrodon.FindAttackByName("Scald");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Scald";
        Type attack1ExcpectedType = Type.Water;
        double attack1ExcpectedAccuracy = 0.95;
        int attack1ExcpectedPower = 90;
        
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        
        if (attack1 is SpecialAttack specialAttack1)
        {
            State sAttack2SpecialEffect = specialAttack1.SpecialEffect;
            int sAttack2Cooldown = specialAttack1.Cooldown;
            State attack2ExcpectedSpecialEffect = State.Burned;
            int attack2ExcpectedCooldown = 0;
            Assert.That(sAttack2SpecialEffect.Equals(attack2ExcpectedSpecialEffect));
            Assert.That(sAttack2Cooldown.Equals(attack2ExcpectedCooldown));
        }
        
        Attack attack2 = gastrodon.FindAttackByName("Earthquake");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Earthquake";
        Type attack2ExcpectedType = Type.Ground;
        double attack2ExcpectedAccuracy = 0.80;
        int attack2ExcpectedPower = 120;
        
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        
        Attack attack3 = gastrodon.FindAttackByName("Ice beam");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Ice beam";
        Type attack3ExcpectedType = Type.Ice;
        double attack3ExcpectedAccuracy = 1;
        int attack3ExcpectedPower = 70;
        
        Assert.That(attack3Name.Equals(attack3ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));

        Attack attack4 = gastrodon.FindAttackByName("Sludge Bomb");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Sludge Bomb";
        Type attack4ExcpectedType = Type.Poison;
        double attack4ExcpectedAccuracy = 0.95;
        int attack4ExcpectedPower = 70;
        
        Assert.That(attack4Name.Equals(attack4ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack4Type.Equals(attack4ExcpectedType));
        Assert.That(attack4Accuracy.Equals(attack4ExcpectedAccuracy));
        Assert.That(attack4Power.Equals(attack4ExcpectedPower));
        
        if (attack4 is SpecialAttack specialAttack4)
        {
            State sAttack2SpecialEffect = specialAttack4.SpecialEffect;
            int sAttack2Cooldown = specialAttack4.Cooldown;
            State attack2ExcpectedSpecialEffect = State.Poisoned;
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
        Gastrodon gastrodon= new Gastrodon();
        double actualLife = gastrodon.CurrentLife;
        string actualLifeText = gastrodon.GetLife();
        gastrodon.GainLife(100);
        Assert.That(actualLife.Equals(gastrodon.BaseLife));
        Assert.That(actualLifeText.Equals("426/426", StringComparison.Ordinal));
        gastrodon.TakeDamage(120);
        double actualLife2 = gastrodon.CurrentLife;
        string actualLifeText2 = gastrodon.GetLife();
        Assert.That(actualLife2.Equals(306));
        Assert.That(actualLifeText2.Equals("306/426", StringComparison.Ordinal));
        gastrodon.GainLife(100);
        double actualLife3 = gastrodon.CurrentLife;
        string actualLifeText3 = gastrodon.GetLife();
        Assert.That(actualLife3.Equals(406));
        Assert.That(actualLifeText3.Equals("406/426", StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del método Instance
    /// </summary>
    [Test]
    public void TestInstance()
    {
        Gastrodon gastrodon = new Gastrodon();
        Pokemon gastrodonClone = gastrodon.Instance();
        Assert.That(gastrodonClone,Is.TypeOf<Gastrodon>());
    }
    
}