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
        this.Name = "Flying";
        Electric electric = new Electric();
        Ice ice = new Ice();
        Rock rock = new Rock();
        this.SuperEffective = [electric,ice,rock];
        Bug bug = new Bug();
        Fighting fighting = new Fighting();
        Grass grass = new Grass();
        this.NotVeryEffective = [fighting,bug,grass];
        Ground ground = new Ground();
        this.NoEffect = [ground];
    }
}