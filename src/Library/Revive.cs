namespace Library;

public class Revive : IItem
{
    public string Name { get; }
    public void Use(Pokemon pokemon)
    {
        if (pokemon.CurrentLife == 0)
        {
            
        }
    }
}