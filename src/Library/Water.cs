using System.Net;

namespace Library;

public class Water : IType
{
    public string Name { get;  }
    public IType[] SuperEffective { get;  }
    public IType[] NormalEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

 
}