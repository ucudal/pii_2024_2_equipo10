namespace Library;

public interface IType
{
    string Name { get; }
    IType[] SuperEffective { get; }
    IType[] NormalEffective { get; }
    IType[] NotVeryEffective { get; }
    IType[] NoEffect { get; }
}