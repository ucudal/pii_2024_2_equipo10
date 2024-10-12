namespace Library;

public class Fairy : IType
{
    public string Name { get; private set;}
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Fairy()
    {
        //Aplicamos Creator
        this.Name = "Fairy";
        Steel steel = new Steel();
        Poison poison = new Poison();
        this.SuperEffective = [steel,poison];
        Bug bug = new Bug();
        Fighting fighting = new Fighting();
        Dark dark = new Dark();
        this.NotVeryEffective = [fighting,bug,dark];
        Dragon dragon = new Dragon();
        this.NoEffect = [dragon];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = false;
    }
}