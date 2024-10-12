namespace Library;

public interface IType
{
    string Name { get; }
    IType[] SuperEffective { get; }
    IType[] NotVeryEffective { get; }
    IType[] NoEffect { get; }
    bool EffectiveAgainstItself { get; }
    bool NotVeryEffectiveAgainstItself { get; }

}