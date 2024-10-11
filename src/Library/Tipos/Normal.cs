namespace Library;

public class Normal: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Normal()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}