namespace Library;

// Es una clase a la cual le delegamos la funcion de calcular el daño para aplicar SRP así game tiene una única responsabilidad
// Es la clase Experta al momento de cambiar el pokemón activo.
// Es una clase abstracta la cual nos permite evitar que el programa tenga interdependencias innecesarias (Aplicando DIP). 
public class Pokeball: IAction
{
    public void ChangePokemon(Player player)
    {
        //Muestra pokemones en pantalla//
        Charizard charizard = new Charizard();
        player.ChangeActivePokemon(charizard);
    }
}