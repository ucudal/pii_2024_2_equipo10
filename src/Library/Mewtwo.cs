namespace Library;

public class Mewtwo: Pokemon
{
    public Mewtwo() : base(name: "Mewtwo", life: 416, type: Type.Psychic, new Attack("Shadow Ball", Type.Ghost, 1, 60),
        new Attack("Psystrike", Type.Psychic, 1, 100), new Attack("Mental Shock", Type.Psychic, 0.75, 100),
        new Attack("Drain Punch", Type.Fighting, 0.95, 80))
    {
    }
}
