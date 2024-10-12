namespace Library;

public class Poison: IType
{
    public string Name { get; private set;}
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

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
        this.NotVeryEffective = [fighting,grass,bug,fairy];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }
}