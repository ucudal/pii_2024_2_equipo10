namespace Library;

public class Psychic: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Psychic()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}