using System.Threading.Tasks.Dataflow;

namespace Library;

public class Psychic: IType
{
    public string Name { get; }
    public IType[] SuperEffective { get; }
    public IType[] NotVeryEffective { get; }
    public IType[] NoEffect { get; }
    
    public Psychic()
    {
        this.Name = "Psychic";
        Bug bug = new Bug();
        Ghost ghost = new Ghost();
        Dark dark = new Dark();
        this.SuperEffective = [bug,ghost,dark];
        Fighting fighting = new Fighting();
        Psychic psychic = new Psychic(); 
        this.NotVeryEffective = [fighting,psychic];
        this.NoEffect = [];
    }
}