using System.Diagnostics;

namespace Library;

public class Dragon : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Dragon()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}