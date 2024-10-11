using System.Diagnostics;

namespace Library;

public class Fairy : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Fairy()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}