namespace Library;

public class Electric : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Electric()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }

}