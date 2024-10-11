namespace Library;

public class Fire : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Fire()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }

}