using Library.Tipos;

namespace Library;

public class Ice : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}

    public Ice()
    {
        this.Name = "Ice";
        Steel steel = new Steel();
        Fire fire = new Fire();
        Fighting fighting = new Fighting();
        Rock rock = new Rock();
        this.SuperEffective = [fighting, fire,steel];
        Ice ice = new Ice();
        this.NotVeryEffective = [ice];
        this.NotVeryEffective = [];
    }

}