namespace Library;

public class Revive : IItem
{
    public string Name { get; }
    public string Use(Pokemon pokemon)
    {
        if (pokemon.CurrentLife > 0)
        {
            return "El pokemon no está debilitado";
        }
        pokemon.CurrentLife = (pokemon.BaseLife / 2);
        return $"{pokemon} ha revivido.";
    }
}