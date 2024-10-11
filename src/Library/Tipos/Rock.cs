using Library.Movimientos;
using Library.Tipos;

namespace Library;

public class Rock: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Rock()
    {
        this.Name = "Rock";
        Steel steel = new Steel();
        Water water = new Water();
        Fighting fighting = new Fighting();
        Grass grass = new Grass();
        Ground ground = new Ground();
        this.SuperEffective = [fighting,steel,water,grass,ground];
        Fire fire = new Fire();
        Normal normal = new Normal();
        Poison poison = new Poison();
        Flying flying = new Flying();
        this.NotVeryEffective = [fire,normal,poison,flying];
        this.NoEffect = [];
    }
}