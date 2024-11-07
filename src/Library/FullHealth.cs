namespace Library;

public class FullHealth : IItem
{
    public string Name { get; }
    public string Use(Pokemon pokemon)
    {
        pokemon.CurrentState = null;
        return $"{pokemon} ya no tiene ningún estado negativo.";
    }
}