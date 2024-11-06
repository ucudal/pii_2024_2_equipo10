namespace Library;

public class Backpack : IAction
{
    public void UseItem(Player player, IItem item)
    {
        item.Use(pokemon);
    }
}