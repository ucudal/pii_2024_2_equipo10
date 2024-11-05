namespace Library;

public class Revive : IItem
{
    public string Name { get; }
    public void Use(Pokemon pokemon)
    {
        If
        pokemon.CurrentLife = pokemon.BaseLife / 2;
    }
}