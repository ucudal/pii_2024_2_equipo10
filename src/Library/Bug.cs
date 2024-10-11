using System.Reflection;

namespace Library;

public class Bug : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Bug()
    {
        this.Name = "Bug";
        Fire fire = new Fire();
        Rock rock = new Rock();
        Flying flying = new Flying();
        this.NotVeryEffective = [fire,rock];
        Fighting fighting = new Fighting();
        Grass grass = new Grass();
        Ground ground = new Ground();
        this.NotVeryEffective = [fighting,grass,ground];
        this.NoEffect = [];
    }

}