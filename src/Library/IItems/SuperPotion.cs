namespace Library;

public class SuperPotion : IItem
{
    public string Name { get; }
    public void Use(Pokemon pokemon)
    {
        pokemon.CurrentLife += 70;
    }
}