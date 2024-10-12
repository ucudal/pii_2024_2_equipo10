namespace Library;

public class Water : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set; }
    public IType[] NotVeryEffective { get; private set; }
    public IType[] NoEffect { get; private set; }
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Water()
    {
        //Aplicamos Creator
        this.Name = "Water";
        Grass grass = new Grass();
        Electric electric = new Electric();
        this.SuperEffective = [grass,electric];
        Fire fire = new Fire();
        Steel steel = new Steel();
        Ice ice = new Ice();
        this.NotVeryEffective = [fire,steel,ice];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }
}