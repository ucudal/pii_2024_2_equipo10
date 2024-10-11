namespace Library;

public class Bug : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Bug()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }

}