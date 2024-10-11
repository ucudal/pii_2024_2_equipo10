
using Library.Tipos;

namespace Library.Movimientos;

public class Water : IType
{
    public string Name { get;  }
    public IType[] SuperEffective { get;  }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Water()
    {
        this.Name = "Water";
        Grass grass = new Grass();
        Electric electric = new Electric();
        this.SuperEffective = [grass,electric];
        Fire fire = new Fire();
        Steel steel = new Steel();
        Water water = new Water();
        Ice ice = new Ice();
        this.NotVeryEffective = [fire,steel,water,ice];
        this.NoEffect = [];
    }
}