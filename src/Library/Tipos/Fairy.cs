using System.Diagnostics;
using Library.Tipos;

namespace Library;

public class Fairy : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Fairy()
    {
        this.Name = "Fairy";
        Steel steel = new Steel();
        Poison poison = new Poison();
        this.SuperEffective = [steel,poison];
        Bug bug = new Bug();
        Fighting fighting = new Fighting();
        Dark dark = new Dark();
        this.NotVeryEffective = [fighting,bug,dark];
        Dragon dragon = new Dragon();
        this.NoEffect = [dragon];
    }
}