namespace Library;

public class Pokeball: IAction
{
    public void ChangePokemon(Player player)
    {
        //pide pokemon al jugador
        player.ChangeActivePokemon(pokemon);
    }
}