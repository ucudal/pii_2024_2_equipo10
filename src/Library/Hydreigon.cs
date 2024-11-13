namespace Library;

public class Hydreigon : Pokemon
{
    public Hydreigon() : base("Hydreigon",life: 388,type: Type.Dragon, new Attack("Surf", Type.Water,1,80), new Attack("Draco meteor", Type.Dragon,0.80,110), new Attack("Focus Blast", Type.Fighting,0.75,120), new SpecialAttack("Fire Blast",Type.Fire,0.85,100,State.Burned))
    {
    }

    public override Pokemon Instance()
    {
        return new Hydreigon();
    }
}