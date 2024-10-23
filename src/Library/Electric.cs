namespace Library;

public class Electric : IType
{
    public string Name { get; private set; }
    public IType[] SuperEffective { get; private set;}
    public IType[] NotVeryEffective { get; private set;}
    public IType[] NoEffect { get; private set;}
    public bool EffectiveAgainstItself { get; private set; }
    public bool NotVeryEffectiveAgainstItself { get; private set; }


    public Electric()
    {
        //Aplicamos Creator
        this.Name = "Electric";
        Ground ground = new Ground();
        this.SuperEffective = [ground];
        Flying flying = new Flying();
        Steel steel = new Steel();
        this.NotVeryEffective = [flying,steel];
        this.NoEffect = [];
        this.EffectiveAgainstItself = false;
        this.NotVeryEffectiveAgainstItself = true;
    }

}