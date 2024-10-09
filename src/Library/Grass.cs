using System.Diagnostics;

namespace Library;

public class Grass : IType
{
    public string Name;
    public IType[] SuperEffective;
    public IType[] NormalEffective;
    public IType[] NotVeryEffective;
    public IType[] NoEffect;

    public Grass()
    {
        Name = "Grass";
        IType[] SuperEffective = new IType[Water, Ground, Rock;
        IType[] NormalEffective = new IType[Normal, Electric, Fighting, Psychic, Ghost, Dark, Fairy];
        IType[] NotVeryEffective = new IType[Fire, Grass, Poison, Flying, Bug, Dragon];
        IType[] NoEffect = null;
    }
}