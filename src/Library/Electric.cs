using Library.Tipos;

namespace Library;

public class Electric : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Electric()
    {
        this.Name = "Electric";
        Ground ground = new Ground();
        this.SuperEffective = [ground];
        Flying flying = new Flying();
        Steel steel = new Steel();
        Electric electric = new Electric();
        this.NotVeryEffective = [flying,steel,electric];
        this.NoEffect = [];

    }

}