using System.Net;

namespace Library;

public class Flying : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Flying()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}