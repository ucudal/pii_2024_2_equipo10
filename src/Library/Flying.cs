namespace Library;

public class Flying : IType
{
    public string Name { get; private set;}
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Flying()
    {
        //Aplicamos Creator
        this.Name = "Flying";
        Electric electric = new Electric();
        Ice ice = new Ice();
        Rock rock = new Rock();
        this.SuperEffective = [electric,ice,rock];
        Bug bug = new Bug();
        Fighting fighting = new Fighting();
        Grass grass = new Grass();
        this.NotVeryEffective = [fighting,bug,grass];
        Ground ground = new Ground();
        this.NoEffect = [ground];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = false;
    }
}