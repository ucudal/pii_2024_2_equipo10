namespace Library;

public class Fire : IType
{
    public string Name;
    public IType[] SuperEffective;
    public IType[] NormalEffective;
    public IType[] NotVeryEffective;
    public IType[] NoEffect;

    public Fire()
    {
        Name = "Fire";
        IType[] SuperEffective = new IType[Grass, Ice, Bug, Steel];
        IType[] NormalEffective = new IType[Normal, Electric, Fighting, Poison, Ground, Flying, Psychic, Ghost, Dark, Fairy];
        IType[] NotVeryEffective = new IType[Fire, Water, Rock];
        IType[] NoEffect = null;
    }

}