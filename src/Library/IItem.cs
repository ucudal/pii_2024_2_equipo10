namespace Library;

public interface IItem
{
    string Name { get; }
    string Use(Pokemon pokemon);
}