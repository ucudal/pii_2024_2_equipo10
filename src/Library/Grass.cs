using System.Diagnostics;

namespace Library;

public class Grass : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NormalEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }


}