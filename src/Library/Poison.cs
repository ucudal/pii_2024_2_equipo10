namespace Library;

public class Poison: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Poison()
    {
        this.Name = "Poison";
        Psychic psychic = new Psychic();
        Ground ground = new Ground();
        this.SuperEffective = [psychic,ground];
        Bug bug = new Bug();
        Fairy fairy = new Fairy();
        Fighting fighting = new Fighting();
        Grass grass = new Grass();
        Poison poison = new Poison();
        this.NotVeryEffective = [fighting, poison,grass,bug,fairy];
        this.NoEffect = [];
    }
}