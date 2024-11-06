namespace Library;

public interface IItem
{
    string Name { get; }
    void Use(Pokemon pokemon);
}