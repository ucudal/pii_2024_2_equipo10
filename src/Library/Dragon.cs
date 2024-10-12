
namespace Library;

public class Dragon : IType
{
    public string Name { get; private set;}
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }

    public Dragon()
    {
        //Aplicamos Creator
        this.Name = "Dragon";
        Fairy fairy = new Fairy();
        Ice ice = new Ice();
        this.SuperEffective = [fairy,ice];
        Water water = new Water();
        Electric electric = new Electric();
        Fire fire = new Fire();
        Grass grass = new Grass();
        this.NotVeryEffective = [water,electric,fire,grass];
        this.NoEffect = [];
        this.EffectiveAgainstItself = true;
        this.NotVeryEffectiveAgainstItself = false;
    }
}