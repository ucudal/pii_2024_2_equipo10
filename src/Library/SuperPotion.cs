namespace Library;

public class SuperPotion : IItem
{
    public string Name { get; }
    public string Use(Pokemon pokemon)
    { 
        pokemon.CurrentLife += 70;
        return $"{pokemon} ha ganado 70HP.";
    }
}