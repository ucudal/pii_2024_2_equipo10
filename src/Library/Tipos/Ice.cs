namespace Library;

public class Ice : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Ice()
    {
        this.Name = "Hielo";
        SuperEffective.Aggregate();
    }

}