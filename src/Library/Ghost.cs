using System.Net;

namespace Library;

public class Ghost : IType
{
    public string Name { get;  private set;}
    public IType[] SuperEffective { get;  private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Ghost()
    {
        //Aplicamos Creator
        this.Name = "Fantasma";
        Ghost ghost = new Ghost();
        Dark dark = new Dark();
        this.SuperEffective = [ghost,dark];
        Bug bug = new Bug();
        Poison poison = new Poison();
        this.NotVeryEffective = [bug,poison];
        Normal normal = new Normal();
        Fighting fighting = new Fighting();
        this.NoEffect = [normal, fighting];
    }
}