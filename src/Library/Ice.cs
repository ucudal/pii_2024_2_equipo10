namespace Library;

public class Ice : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Ice()
    {
        //Aplicamos Creator
        this.Name = "Ice";
        Steel steel = new Steel();
        Fire fire = new Fire();
        Fighting fighting = new Fighting();
        Rock rock = new Rock();
        this.SuperEffective = [fighting, fire,steel,rock];
        this.NotVeryEffective = [];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }

}