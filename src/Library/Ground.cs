namespace Library;

public class Ground: IType
{
    public string Name { get;private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Ground()
    {
        //Aplicamos Creator
        this.Name = "Ground";
        Water water = new Water();
        Ice ice = new Ice();
        Grass grass = new Grass();
        this.SuperEffective = [water,ice,grass];
        Rock rock = new Rock();
        Poison poison = new Poison();
        this.NotVeryEffective = [rock,poison];
        Electric electric = new Electric();
        this.NoEffect = [electric];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = false;

    }
}