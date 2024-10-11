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
        this.Name = "Fantasma";
        Ghost ghost = new Ghost();
        Dark dark = new Dark();
        SuperEffective.Append(ghost);
        SuperEffective.Append(dark);
        Bug bug = new Bug();
        Poison poison = new Poison();
        NotVeryEffective.Append(bug);
        NotVeryEffective.Append(poison);
        Normal normal = new Normal();
        Fighting fighting = new Fighting();
        NoEffect.Append(normal);
        NoEffect.Append(fighting);
    }
}