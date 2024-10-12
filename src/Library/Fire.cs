namespace Library;

public class Fire : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }
    
    public Fire()
    {
        //Aplicamos Creator
        this.Name = "Fire";
        Water water = new Water();
        Rock rock = new Rock();
        Ground ground = new Ground();
        this.SuperEffective = [water,rock,ground];
        Grass grass = new Grass();
        Steel steel = new Steel();
        Bug bug = new Bug();
        Fairy fairy = new Fairy();
        Ice ice = new Ice();
        this.NotVeryEffective = [grass,steel,bug,fairy,ice];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }

}