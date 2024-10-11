namespace Library;

public class DamageCalculator
{
    public static int CalculateEfectivness(IPokemon pokemon)
    {
        foreach (IType type in pokemon.Types)
        {
            
        }
    }
    public static int CalculateDamage(IPokemon attackerPokemon, IPokemon attackedPokemon, DamageMove move)
    {
        Efectivness = DamageCalculator.CalculateEfectivness(attackedPokemon);
    }
}