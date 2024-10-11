namespace Library;

public class Ground: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Ground()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}