
namespace Library;

public class Dragon : IType
{
    public string Name { get; private set;}
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Dragon()
    {
        //Aplicamos Creator
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