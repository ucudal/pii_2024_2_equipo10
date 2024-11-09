using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Haxorus"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Haxorus))]
public class HaxorusTest
{
    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Haxorus haxorus = new Haxorus();
        string haxorusName = haxorus.Name;
        string expectedName = "Haxorus";
        Assert.That(haxorusName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Haxorus haxorus = new Haxorus();
        Type haxorusType = haxorus.GetTypes()[0];
        Type expectedType = Type.Dragon;
        Assert.That(haxorusType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Haxorus haxorus = new Haxorus();
        double haxorusBaseLife = haxorus.BaseLife;
        double expectedBaseLife = 356;
        Assert.That(haxorusBaseLife.Equals(expectedBaseLife));
        double haxorusCurentLife = haxorus.CurrentLife;
        double expectedCurrentLife = 356;
        Assert.That(haxorusCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Haxorus
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Haxorus haxorus = new Haxorus();
        List<IAttack> haxorusAttacks = haxorus.GetAttacks();
        int expectedLenght = 4;
        Assert.That( haxorusAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Haxorus
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Haxorus haxorus = new Haxorus();
        List<IAttack> haxorusAttacks = haxorus.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        haxorus.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(haxorusAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Haxorus haxorus = new Haxorus();
        State? haxorusCurrentState = haxorus.CurrentState;
        Assert.That(haxorusCurrentState.Equals(null));
        haxorus.EditState(State.Burned);
        State? haxorusCurrentState2 = haxorus.CurrentState;
        Assert.That(haxorusCurrentState2.Equals(State.Burned));
    }

    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Haxorus haxorus = new Haxorus();
        int haxorusCurrentState = haxorus.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(haxorusCurrentState.Equals(expectedLenght));
    }

    /// <summary>
    /// Test de los ataques que tiene Haxorus, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Haxorus haxorus = new Haxorus();
        Attack attack1 = haxorus.FindAttackByName("Outrage");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Outrage";
        Type attack1ExcpectedType = Type.Dragon;
        double attack1ExcpectedAccuracy = 0.75;
        int attack1ExcpectedPower = 120;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        Attack attack2 = haxorus.FindAttackByName("Assurance");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Assurance";
        Type attack2ExcpectedType = Type.Normal;
        double attack2ExcpectedAccuracy = 0.95;
        int attack2ExcpectedPower = 80;
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        Attack attack3 = haxorus.FindAttackByName("Close Combat");
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

        Attack attack4 = haxorus.FindAttackByName("Dragon claw");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "Dragon claw";
        Type attack4ExcpectedType = Type.Dragon;
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
        Haxorus haxorus = new Haxorus();
        double actualLife = haxorus.CurrentLife;
        string actualLifeText = haxorus.GetLife();
        haxorus.GainLife(100);
        Assert.That(actualLife.Equals(haxorus .BaseLife));
        Assert.That(actualLifeText.Equals("356/356", StringComparison.Ordinal));
        haxorus.TakeDamage(120);
        double actualLife2 = haxorus.CurrentLife;
        string actualLifeText2 = haxorus.GetLife();
        Assert.That(actualLife2.Equals(236));
        Assert.That(actualLifeText2.Equals("236/356", StringComparison.Ordinal));
        haxorus.GainLife(100);
        double actualLife3 = haxorus.CurrentLife;
        string actualLifeText3 = haxorus.GetLife();
        Assert.That(actualLife3.Equals(336));
        Assert.That(actualLifeText3.Equals("336/356", StringComparison.Ordinal));
    }

    /// <summary>
    /// Test del método FindAttackByName
    /// </summary>
    [Test]
    public void TestFindAttackByName()
    {
        Haxorus haxorus = new Haxorus();
        Attack attack = haxorus.FindAttackByName("Outrage");
        string attack1Name = attack.Name;
        Type attack1Type = attack.Type;
        double attack1Accuracy = attack.Accuracy;
        int attack1Power = attack.Power;
        string attack1ExcpectedName = "Outrage";
        Type attack1ExcpectedType = Type.Dragon;
        double attack1ExcpectedAccuracy = 0.75;
        int attack1ExcpectedPower = 120;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
    }
}