namespace Library;

public class Revive : IItem
{
    public string Name { get; }
    public void Use(Pokemon pokemon)
    {
        pokemon.CurrentLife = (pokemon.BaseLife / 2);
    }
}