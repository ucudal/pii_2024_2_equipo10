namespace Library;

public class Charizard : Pokemon
{
    public Charizard():base(name: "Charizard", life: 360, type: Type.Fire, new Attack("Dragon claw",Type.Dragon,1,55),new SpecialAttack("Flamethrower",Type.Fire,0.95,75, State.Burned), new Attack("Wing Attack",Type.Flying,0.9,40), new Attack("Fire punch",Type.Fire,1,50))
    {
        
    }
    
}