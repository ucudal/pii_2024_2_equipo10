namespace Library;

public class Rock: IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set; }
    public IType[] NotVeryEffective { get; private set; }
    public IType[] NoEffect { get; private set; }
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Rock()
    {
        //Aplicamos Creator
        this.Name = "Rock";
        Steel steel = new Steel();
        Water water = new Water();
        Fighting fighting = new Fighting();
        Grass grass = new Grass();
        Ground ground = new Ground();
        this.SuperEffective = [fighting,steel,water,grass,ground];
        Fire fire = new Fire();
        Normal normal = new Normal();
        Poison poison = new Poison();
        Flying flying = new Flying();
        this.NotVeryEffective = [fire,normal,poison,flying];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = false;
    }
}