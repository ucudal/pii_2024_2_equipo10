namespace Library;

public class Poison: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Poison()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}