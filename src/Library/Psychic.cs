
namespace Library;

public class Psychic: IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Psychic()
    {
        //Aplicamos Creator
        this.Name = "Psychic";
        Bug bug = new Bug();
        Ghost ghost = new Ghost();
        Dark dark = new Dark();
        this.SuperEffective = [bug,ghost,dark];
        Fighting fighting = new Fighting();
        this.NotVeryEffective = [fighting];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }
}