using System.Net;

namespace Library;

public class Water : IType
{
    public string Name;
    public IType[] SuperEffective;
    public IType[] NormalEffective;
    public IType[] NotVeryEffective;
    public IType[] NoEffect;

    public Water()
    {
        Name = "Water";
        IType[] SuperEffective = new IType[Fire, Ground, Rock];
        IType[] NormalEffective = new IType[Normal, Electric, Ice, Fighting, Poison, Flying, Psychic, Bug, Ghost, Dark, Steel, Fairy];
        IType[] NotVeryEffective = new IType[Water, Grass, Dragon];
        IType[] NoEffect = null;
    }

}