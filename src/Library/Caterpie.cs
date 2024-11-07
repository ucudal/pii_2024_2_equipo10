namespace Library;

public class Caterpie: Pokemon
{
    public Caterpie():base(name: "Caterpie", life: 40, type: Library.Type.Bug, new Attack("Bug bite", Type.Bug, 1,20),new Attack("Tackle",Type.Normal,1,30),new SpecialAttack("Bug stomp", Type.Bug, 0.95,70, State.Paralized),new Attack("String shot", Type.Bug, 1,15))
    {
        
    }
}