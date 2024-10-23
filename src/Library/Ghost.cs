namespace Library;

public class Ghost : IType
{
    public string Name { get;  private set;}
    public IType[] SuperEffective { get;  private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Ghost()
    {
        //Aplicamos Creator
        this.Name = "Fantasma";
        Dark dark = new Dark();
        this.SuperEffective = [dark];
        Bug bug = new Bug();
        Poison poison = new Poison();
        this.NotVeryEffective = [bug,poison];
        Normal normal = new Normal();
        Fighting fighting = new Fighting();
        this.NoEffect = [normal, fighting];
        this.EffectiveAgainstItself = true;
        this.NotVeryEffectiveAgainstItself = false;
    }
}