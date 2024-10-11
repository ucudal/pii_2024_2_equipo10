namespace Library.Tipos;

public class Steel: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; private set; }
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    
    public Steel()
    {
        this.Name = "Acero";
        Ice ice = new Ice();
        Rock rock = new Rock();
        Fairy fairy = new Fairy();
        SuperEffective.Append(ice);
        SuperEffective.Append(rock);
        SuperEffective.Append(fairy);
        Ground ground = new Ground();
        Fighting fight = new Fighting();
        Fire fire = new Fire();
        NotVeryEffective.Append(ground);
        NotVeryEffective.Append(fight);
        NotVeryEffective.Append(fire);
    }
}