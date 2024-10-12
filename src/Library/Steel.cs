namespace Library;

public class Steel: IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set; }
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Steel()
    {
        //Aplicamos Creator
        this.Name = "Steel";
        Ground ground = new Ground();
        Fighting fight = new Fighting();
        Fire fire = new Fire();
        this.SuperEffective = [ground,fight,fire];
        Ice ice = new Ice();
        Bug bug = new Bug();
        Rock rock = new Rock();
        Fairy fairy = new Fairy();
        Dragon dragon = new Dragon();
        Normal normal = new Normal();
        Grass grass = new Grass();
        Psychic psychic = new Psychic();
        Flying flying = new Flying();
        this.NotVeryEffective = [ice,bug,rock,fairy,dragon,normal,grass,psychic,flying];
        Poison poison = new Poison();
        this.NoEffect = [poison];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }
}