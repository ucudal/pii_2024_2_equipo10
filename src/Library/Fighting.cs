namespace Library;

public class Fighting : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set; }
    public IType[] NotVeryEffective { get; private set; }
    public IType[] NoEffect { get; private set; }
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Fighting()
    {
        //Aplicamos Creator
        this.Name = "Fighting";
        Fairy fairy = new Fairy();
        Psychic psychic = new Psychic();
        Flying flying = new Flying();
        this.SuperEffective = [fairy,psychic,flying];
        Dark dark = new Dark();
        Rock rock = new Rock();
        Bug bug = new Bug();
        this.NotVeryEffective = [dark,rock,bug];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = false;
    }
}