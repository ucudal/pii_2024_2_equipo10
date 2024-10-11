using System.Diagnostics;
using Library.Movimientos;

namespace Library;

public class Dragon : IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }

    public Dragon()
    {
        this.Name = "Dragon";
        Dragon dragon = new Dragon();
        Fairy fairy = new Fairy();
        Ice ice = new Ice();
        this.SuperEffective = [dragon,fairy,ice];
        Water water = new Water();
        Electric electric = new Electric();
        Fire fire = new Fire();
        Grass grass = new Grass();
        this.NotVeryEffective = [water,electric,fire,grass];
        this.NoEffect = [];
    }
}