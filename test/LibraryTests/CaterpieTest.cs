using Library;
using NUnit.Framework;
using Type = Library.Type;

namespace LibraryTests;

/// <summary>
/// Test de la clase <see cref="Caterpie"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Caterpie))]
public class CaterpieTest
{

    /// <summary>
    /// Test del atributo name
    /// </summary>
    [Test]
    public void TestName()
    {
        Caterpie caterpie = new Caterpie();
        string caterpieName = caterpie.Name;
        string expectedName = "Caterpie";
        Assert.That(caterpieName.Equals(expectedName, StringComparison.Ordinal));
    }
    
    /// <summary>
    /// Test del atributo type
    /// </summary>
    [Test]
    public void TestType()
    {
        Caterpie caterpie = new Caterpie();
        Type caterpieType = caterpie.GetTypes()[0];
        Type expectedType = Type.Bug;
        Assert.That(caterpieType.Equals(expectedType));
    }
    
    /// <summary>
    /// Test de los atributos life y currentLife
    /// </summary>
    [Test]
    public void TestLifeAndCurrentLife()
    {
        Caterpie caterpie = new Caterpie();
        double caterpieBaseLife = caterpie.BaseLife;
        double expectedBaseLife = 294;
        Assert.That(caterpieBaseLife.Equals(expectedBaseLife));
        double caterpieCurentLife = caterpie.CurrentLife;
        double expectedCurrentLife = 294;
        Assert.That(caterpieCurentLife.Equals(expectedCurrentLife));
    }
    
    /// <summary>
    /// Test de la cantidad de ataques que tiene Caterpie
    /// </summary>
    [Test]
    public void TestIfItHasFourAttacks()
    {
        Caterpie caterpie = new Caterpie();
        List<IAttack> caterpieAttacks = caterpie.GetAttacks();
        int expectedLenght = 4;
        Assert.That(caterpieAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de la limitación de movimientos que tiene Caterpie
    /// </summary>
    [Test]
    public void TestAddAFifthAttack()
    {
        Caterpie caterpie = new Caterpie();
        List<IAttack> caterpieAttacks = caterpie.GetAttacks();
        Attack attack = new Attack("TestAttack", Type.Fire, 1, 1);
        caterpie.AddAttack(attack);
        int expectedLenght = 4;
        Assert.That(caterpieAttacks.Count.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test del atributo CurrentState y el método EditSate
    /// </summary>
    [Test]
    public void TestCurrentStateAndEditState()
    {
        Caterpie caterpie = new Caterpie();
        State? caterpieCurrentState = caterpie.CurrentState;
        Assert.That(caterpieCurrentState.Equals(null));
        caterpie.EditState(State.Burned);
        State? caterpieCurrentState2 = caterpie.CurrentState;
        Assert.That(caterpieCurrentState2.Equals(State.Burned));
    }
    
    /// <summary>
    /// Test del atributo asleepTurns
    /// </summary>
    [Test]
    public void TestAsleepTurns()
    {
        Caterpie caterpie = new Caterpie();
        int caterpieCurrentState = caterpie.AsleepTurns;
        int expectedLenght = 0;
        Assert.That(caterpieCurrentState.Equals(expectedLenght));
    }
    
    /// <summary>
    /// Test de metodo FindAttackByName y los ataques que tiene Caterpie, confirmando que fueron creados correctamente
    /// </summary>
    [Test]
    public void TestAttacks()
    {
        Caterpie caterpie = new Caterpie();
        Attack attack1 = caterpie.FindAttackByName("Bug bite");
        string attack1Name = attack1.Name;
        Type attack1Type = attack1.Type;
        double attack1Accuracy = attack1.Accuracy;
        int attack1Power = attack1.Power;
        string attack1ExcpectedName = "Bug bite";
        Type attack1ExcpectedType = Type.Bug;
        double attack1ExcpectedAccuracy = 1;
        int attack1ExcpectedPower = 20;
        Assert.That(attack1Name.Equals(attack1ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack1Type.Equals(attack1ExcpectedType));
        Assert.That(attack1Accuracy.Equals(attack1ExcpectedAccuracy));
        Assert.That(attack1Power.Equals(attack1ExcpectedPower));
        Attack attack2 = caterpie.FindAttackByName("Tackle");
        string attack2Name = attack2.Name;
        Type attack2Type = attack2.Type;
        double attack2Accuracy = attack2.Accuracy;
        int attack2Power = attack2.Power;
        string attack2ExcpectedName = "Tackle";
        Type attack2ExcpectedType = Type.Normal;
        double attack2ExcpectedAccuracy = 1;
        int attack2ExcpectedPower = 30;
        
        Assert.That(attack2Name.Equals(attack2ExcpectedName, StringComparison.Ordinal));
        Assert.That(attack2Type.Equals(attack2ExcpectedType));
        Assert.That(attack2Accuracy.Equals(attack2ExcpectedAccuracy));
        Assert.That(attack2Power.Equals(attack2ExcpectedPower));
        Attack attack3 = caterpie.FindAttackByName("Bug stomp");
        string attack3Name = attack3.Name;
        Type attack3Type = attack3.Type;
        double attack3Accuracy = attack3.Accuracy;
        int attack3Power = attack3.Power;
        string attack3ExcpectedName = "Bug stomp";
        Type attack3ExcpectedType = Type.Bug;
        double attack3ExcpectedAccuracy = 0.95;
        int attack3ExcpectedPower = 70;
        Assert.That(attack3Name, Is.EqualTo(attack3ExcpectedName));
        Assert.That(attack3Type.Equals(attack3ExcpectedType));
        Assert.That(attack3Accuracy.Equals(attack3ExcpectedAccuracy));
        Assert.That(attack3Power.Equals(attack3ExcpectedPower));
        if (attack3 is SpecialAttack specialAttack3)
        {
            State sAttack3SpecialEffect = specialAttack3.SpecialEffect;
            int sAttack3Cooldown = specialAttack3.Cooldown;
            State attack3ExcpectedSpecialEffect = State.Paralized;
            int attack3ExcpectedCooldown = 0;
            Assert.That(sAttack3SpecialEffect.Equals(attack3ExcpectedSpecialEffect));
            Assert.That(sAttack3Cooldown.Equals(attack3ExcpectedCooldown));

        }

        Attack attack4 = caterpie.FindAttackByName("String shot");
        string attack4Name = attack4.Name;
        Type attack4Type = attack4.Type;
        double attack4Accuracy = attack4.Accuracy;
        int attack4Power = attack4.Power;
        string attack4ExcpectedName = "String shot";
        Type attack4ExcpectedType = Type.Bug;
        double attack4ExcpectedAccuracy = 1;
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
        Caterpie caterpie= new Caterpie();
        double actualLife = caterpie.CurrentLife;
        string actualLifeText = caterpie.GetLife();
        caterpie.GainLife(100);
        Assert.That(actualLife.Equals(caterpie.BaseLife));
        Assert.That(actualLifeText.Equals("294/294", StringComparison.Ordinal));
        caterpie.TakeDamage(120);
        double actualLife2 = caterpie.CurrentLife;
        string actualLifeText2 = caterpie.GetLife();
        Assert.That(actualLife2.Equals(174));
        Assert.That(actualLifeText2.Equals("174/294", StringComparison.Ordinal));
        caterpie.GainLife(100);
        double actualLife3 = caterpie.CurrentLife;
        string actualLifeText3 = caterpie.GetLife();
        Assert.That(actualLife3.Equals(274));
        Assert.That(actualLifeText3.Equals("274/294", StringComparison.Ordinal));
    }
    
    [Test]
    public void TestInstance()
    {
        Caterpie caterpie = new Caterpie();
        Pokemon caterpieClone = caterpie.Instance();
        Assert.That(caterpieClone,Is.TypeOf<Caterpie>());
    }
}