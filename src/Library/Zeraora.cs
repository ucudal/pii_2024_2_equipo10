namespace Library;

public class Zeraora: Pokemon
{
    public Zeraora() : base(name: "Zeraora", life: 380, type: Type.Electric,
        new Attack("Plasma Fist", Type.Electric, 1, 65),
        new SpecialAttack("Thunderbolt", Type.Electric, 1, 75, State.Paralized),
        new Attack("Close Combat", Type.Fighting, 0.75, 120), new Attack("Wild Charge", Type.Electric, 0.6, 160))
    {

    }
}