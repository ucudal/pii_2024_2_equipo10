namespace Library;

public class Normal: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Normal()
    {
        this.Name = "Normal";
        Fighting fighting = new Fighting();
        this.SuperEffective = [fighting];
        this.NotVeryEffective = [];
        Ghost ghost = new Ghost();
        this.NoEffect = [ghost];

    }
}