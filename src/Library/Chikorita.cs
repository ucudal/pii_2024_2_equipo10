namespace Library;

public class Chikorita : Pokemon
{
    public Chikorita():base(name: "Chikorita", life: 294, type: Type.Grass,new Attack("Razor leaf",Type.Grass,0.9,35),new Attack("Magical leaf", Type.Grass,1,45),new SpecialAttack("Giga Drain",Type.Grass,0.95,70,State.Paralized), new Attack("Body slam",Type.Normal,1,55))
    {
        
    }
}