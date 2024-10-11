using System.Net;

namespace Library;

public class Fighting : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Fighting()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}