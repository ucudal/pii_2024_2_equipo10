namespace Library;

public class Normal: IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Normal()
    {
        //Aplicamos Creator
        this.Name = "Normal";
        Fighting fighting = new Fighting();
        this.SuperEffective = [fighting];
        this.NotVeryEffective = [];
        Ghost ghost = new Ghost();
        this.NoEffect = [ghost];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = false;
    }
}