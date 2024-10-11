using System.Diagnostics;

namespace Library;

public class Dark : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Dark()
    {
        this.Name = "Dark";
        Bug bug = new Bug();
        Fairy fairy = new Fairy();
        Fighting fighting = new Fighting();
        this.SuperEffective = [fighting,bug,fairy];
        Ghost ghost = new Ghost();
        Dark dark = new Dark();
        this.NotVeryEffective = [ghost,dark];
        Psychic psychic = new Psychic();
        this.NoEffect = [psychic];

    }
}