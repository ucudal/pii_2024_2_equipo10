using System.Net;

namespace Library;

public class Ghost : IType
{
    public string Name { get;  }
    public IType[] SuperEffective { get;  }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Ghost()
    {
        this.Name = "Fuego";
        SuperEffective.Aggregate();
    }
}