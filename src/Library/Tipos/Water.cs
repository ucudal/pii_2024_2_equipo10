using System.Net;

namespace Library;

public class Water : IType
{
    public string Name { get;  }
    public IType[] SuperEffective { get;  }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Water()
    {
        this.Name = "Agua";
        Fire fire = new Fire();
        Ground ground = new Ground();
        Rock rock = new Rock();
        SuperEffective.Append(fire);
        SuperEffective.Append(ground);
        SuperEffective.Append();
    }
}