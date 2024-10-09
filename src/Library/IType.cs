namespace Library;

public interface IType
{
    string Name { get; }
    Array[] SuperEffective { get; }
    Array[] NormalEffective { get; }
    Array[] NotVeryEffective { get; }
    Array[] NoEffect { get; }
}