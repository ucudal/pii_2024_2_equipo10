namespace Library;

public class Poison: IType
{
    public string Name { get; private set;}
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    
    public Poison()
    {
        //Aplicamos Creator
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