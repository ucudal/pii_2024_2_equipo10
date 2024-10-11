using System.Net;

namespace Library;

public class Fighting : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Fighting()
    {
        //Aplicamos Creator
        this.Name = "Fighting";
        Fairy fairy = new Fairy();
        Psychic psychic = new Psychic();
        Flying flying = new Flying();
        this.NotVeryEffective = [fairy,psychic,flying];
        Dark dark = new Dark();
        Rock rock = new Rock();
        Bug bug = new Bug();
        this.NotVeryEffective = [dark,rock,bug];
        this.NotVeryEffective = [];
    }
}