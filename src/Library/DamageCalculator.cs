namespace Library;

// Es una clase a la cual le delegamos la función de calcular el daño para aplicar SRP así game tiene una única responsabilidad
// Es la clase Experta al momento de calcular daño
// Es una clase abstracta la cual nos permite evitar que el programa tenga interdependencias innecesarias (Aplicando DIP).
public class DamageCalculator
{
    public static int CalculateDamage(IPokemon attackerPokemon, IPokemon attackedPokemon, DamageMove move)
    {
        // En un futuro va a tener en cuenta las efectividades de tipos
        return (attackerPokemon.CurrentAttack*move.Power)/2 ; 
    }
}