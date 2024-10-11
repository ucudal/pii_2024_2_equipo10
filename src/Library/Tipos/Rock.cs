namespace Library;

public class Rock: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Rock()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}