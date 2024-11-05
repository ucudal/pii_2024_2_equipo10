namespace Library;

public class Charizard : Pokemon
{
    public Charizard():base(name: "Charizard", life: 80, type: Type.Fire, new DamageMove("string",true,100,75,Type.Fire))
    {
        
    }
    
}