using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Charizard))]
public class CharizardTest
{

    [Test]
    public void TestName()
    {
        Charizard charizard = new Charizard();
        string charizardName = charizard.Name;
        string expectedName = "Charizard";
        Assert.That(charizardName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    [Test]
    public void TestType()
    {
        Charizard charizard = new Charizard();
        Type charizardType = charizard.GetTypes()[0];
        Type expectedType = Type.Fire;
        Assert.That(charizardType.Equals(expectedType));
    }
    
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
    
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Charizard charizard = new Charizard();
        List<IAttack> charizardAttacks = charizard.GetAttacks();
        int expectedLenght = 4;
        Assert.That(charizardAttacks.Count.Equals(expectedLenght));
    }
    
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
    
    [Test]
    public void TestCurrentState()
    {
        Charizard charizard = new Charizard();
        State? charizardCurrentState = charizard.CurrentState;
        Assert.That(charizardCurrentState.Equals(null));
    }

    [Test]
    public void TestAsleepTurns()
    {
        Charizard charizard = new Charizard();
        int charizardCurrentState = charizard.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(charizardCurrentState.Equals(expectedLenght));
    }

    [Test]
    public void TestAttacks()
    {
        Charizard charizard = new Charizard();
        Attack attack1 = charizard.FindAttackByName("Dragon Claw");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string excpectedName = "Dragon claw";
        Type excpectedType = Type.Dragon;
        double excpectedAccuracy = 1;
        int excpectedPower = 55;
        Assert.That(attack1Name.Equals(excpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(excpectedType));
        Assert.That(attack1Accuracy.Equals(excpectedAccuracy));
        Assert.That(attack1Power.Equals(excpectedPower));
        Attack attack2 = charizard.FindAttackByIndex(1);
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power; 
        
        State sattack2SpecialEffect = attack2.SpecialEffect
    }
}