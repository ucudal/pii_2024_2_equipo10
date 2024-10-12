namespace Library;

public class Grass : IType
{
    public string Name { get; private set;}
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Grass()
    {
        //Aplicamos Creator
        this.Name = "Grass";
        Bug bug = new Bug();
        Fire fire = new Fire();
        Ice ice = new Ice();
        Poison poison = new Poison();
        Flying flying = new Flying();
        this.SuperEffective = [bug,fire,ice,poison,flying];
        Water water = new Water();
        Electric electric = new Electric();
        Ground ground = new Ground();
        this.NotVeryEffective = [water,electric,ground];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }
}