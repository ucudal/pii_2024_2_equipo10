
namespace Library;

public class Dark : IType
{
    public string Name { get; private set;}
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool NotVeryEffectiveAgainstItself { get; private set; }
    public bool EffectiveAgainstItself { get; private set; }


    public Dark()
    {        
        //Aplicamos Creator
        this.Name = "Dark";
        Bug bug = new Bug();
        Fairy fairy = new Fairy();
        Fighting fighting = new Fighting();
        this.SuperEffective = [fighting,bug,fairy];
        Ghost ghost = new Ghost();
        this.NotVeryEffective = [ghost];
        Psychic psychic = new Psychic();
        this.NoEffect = [psychic];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }
}