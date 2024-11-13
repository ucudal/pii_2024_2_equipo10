namespace Library;

public class Gastrodon : Pokemon
{
    public Gastrodon():base(name: "Gastrodon",life: 426, type: Type.Water, new SpecialAttack("Scald",Type.Water,0.95,90,State.Burned), new Attack("Earthquake", type: Type.Ground,0.80,120), new Attack("Ice beam", Type.Ice, 1,70), new SpecialAttack("Sludge Bomb", Type.Poison,0.95,70,State.Poisoned))
    {
    }
    
    public override Pokemon Instance()
    {
        return new Gastrodon();
    }
    
}