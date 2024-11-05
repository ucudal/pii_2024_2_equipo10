namespace Library;

public class FullHealth : IItem
{
    public string Name { get; }
    public void Use(Pokemon pokemon)
    {
        pokemon.CurrentState = null;
    }
}