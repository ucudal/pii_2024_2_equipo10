using Library.Movimientos;

namespace Library;

public class Ground: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Ground()
    {
        this.Name = "Ground";
        Water water = new Water();
        Ice ice = new Ice();
        Grass grass = new Grass();
        this.SuperEffective = [water,ice,grass];
        Rock rock = new Rock();
        Poison poison = new Poison();
        this.NotVeryEffective = [rock,poison];
        Electric electric = new Electric();
        this.NoEffect = [electric];

    }
}