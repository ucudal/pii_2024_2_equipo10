using System.Diagnostics;

namespace Library;

public class Dark : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Dark()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}