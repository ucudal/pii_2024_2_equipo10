namespace Library;

public class Revive : IItem
{
    public string Name { get; }
    public string Use(Pokemon pokemon)
    {
        pokemon.CurrentLife = (pokemon.BaseLife / 2);
        return $"{pokemon} ha revivido.";
    }
}