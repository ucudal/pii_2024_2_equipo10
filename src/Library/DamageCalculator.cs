using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Xml;

namespace Library;

// Es una clase a la cual le delegamos la función de calcular el daño para aplicar SRP así game tiene una única responsabilidad
// Es la clase Experta al momento de calcular daño
// Es una clase abstracta la cual nos permite evitar que el programa tenga interdependencias innecesarias (Aplicando DIP).
public static class DamageCalculator
{
    /// <summary>
    /// Proporciona el valor de efectividad de los ataques entre diferentes tipos de Pokémon.
    /// </summary>
    /// <returns>
    /// <c>Dictionary</c> Diccionario donde la clave es una tupla que representa el tipo del ataque y el tipo del Pokemon objetivo, 
    /// y el valor es un factor de efectividad (2.0 para súperefectivo, 0.5 para poco efectivo, 0.0 para sin efecto).
    /// </returns>
    private static Dictionary<Tuple<Type, Type>, double> EffectivnessDataBase
    {
        get
        {
            Type fire = Type.Fire;
            Type water = Type.Water;
            Type grass = Type.Grass;
            Type electric = Type.Electric;
            Type ground = Type.Ground;
            Type bug = Type.Bug;
            Type dragon = Type.Dragon;
            Type fighting = Type.Fighting;
            Type flying = Type.Flying;
            Type ghost = Type.Ghost;
            Type ice = Type.Ice;
            Type normal = Type.Normal;
            Type poison = Type.Poison;
            Type psychic = Type.Psychic;
            Type rock = Type.Rock;
            Dictionary<Tuple<Type, Type>, double> effectivnessDataBase =
                new Dictionary<Tuple<Type, Type>, double>();
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, water), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, water), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, water), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fire, water), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ice, water), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fire, bug), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(rock, bug), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(flying, bug), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, bug), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, bug), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, bug), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, bug), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(dragon, dragon), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ice, dragon), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, dragon), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fire, dragon), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, dragon), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, dragon), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, electric), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(flying, electric), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, electric), 0.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ghost, ghost), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, ghost), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, ghost), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(normal, ghost), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, fire), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(rock, fire), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, fire), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, fire), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fire, fire), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, fire), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fire, ice), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, ice), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(rock, ice), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ice, ice), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(psychic, fighting), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(flying, fighting), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, fighting), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(rock, fighting), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, normal), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ghost, normal), 0.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, grass), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fire, grass), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ice, grass), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, grass), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(flying, grass), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, grass), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, grass), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, grass), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, grass), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, psychic), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, psychic), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ghost, psychic), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, rock), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, rock), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, rock), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, rock), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fire, rock), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(normal, rock), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, rock), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(flying, rock), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ice, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(rock, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, ground), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(psychic, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, poison), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, poison), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, flying), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ice, flying), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(rock, flying), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, flying), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, flying), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, flying), 0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, flying), 0.5);

            return effectivnessDataBase;
        }
    }
    
    /// <summary>
    /// Obtiene la efectividad de un ataque de un tipo específico contra el o los tipos de un Pokemon.
    /// </summary>
    /// <param name="type">El tipo del ataque.</param>
    /// <param name="types">Una lista de los tipos del Pokemon objetivo.</param>
    /// <returns>
    /// Valor <c>double</c> indicando el factor de efectividad del ataque.
    /// <c>2.0</c> para súperefectivo, <c>0.5</c> para poco efectivo, <c>0.0</c> si no tiene efecto, y <c>1.0</c> si no hay una relación específica.
    /// </returns>
    public static double GetEffectivness(Type type, List<Type> types)
    {
        foreach (Type type1 in types)
        {
            Tuple<Type, Type> tuple = new Tuple<Type, Type>(type, type1);
            if (EffectivnessDataBase.ContainsKey(tuple))
            {
                double effectivness = EffectivnessDataBase[tuple];
                return effectivness;
            }
            else
            {
                return 1.0;
            }
        }

        return 1.0;
    }

    /// <summary>
    /// Determina si un ataque resulta en un golpe crítico basado en una probabilidad aleatoria.
    /// </summary>
    /// <returns>
    /// Un valor <c>double</c>: <c>1.20</c> si el ataque es crítico (10% de probabilidad), 
    /// o <c>1.0</c> si no es crítico.
    /// </returns>    
    public static double CriticalCheck()
    {
        Random random = new Random();
        int chance = random.Next(1,11);
        if (chance == 1)
        {
            return 1.20;
        }
        return 1.0;
    }
    /// <summary>
    /// Aplica un efecto especial al Pokemon objetivo, siempre y cuando el ataque recibido sea especial y el Pokemon no tenga ya otro efecto.
    /// </summary>
    /// <param name="attackedPokemon">El Pokemon que recibe el ataque.</param>
    /// <param name="attack">El ataque ejecutado.</param>
    /// <remarks>
    /// Si el ataque es un <see cref="SpecialAttack"/> y el Pokemon objetivo no tiene un estado actual, 
    /// se aplica el efecto especial del ataque y se setea su cooldown.
    /// </remarks>
    public static void SpecialCheck(Pokemon attackedPokemon, Attack attack)
    {
        if (attack is SpecialAttack specialAttack && attackedPokemon.CurrentState == null)
        {
            attackedPokemon.EditState(specialAttack.SpecialEffect);
            specialAttack.SetCooldown();
        }
    }

    /// <summary>
    /// Calcula el daño infligido a un Pokemon objetivo. Para esto tiene en cuenta el valor de ataque, la efectividad de tipos y
    /// la probabilidad de golpe crítico, además de revisar si se trata de un ataque especial.
    /// </summary>
    /// <param name="attackedPokemon">El Pokemon que recibe el ataque.</param>
    /// <param name="attack">El ataque que se está ejecutando.</param>
    /// <returns>
    /// El daño calculado como un <c>double</c>. 
    /// Devuelve <c>0.0</c> si el ataque falla.
    /// </returns>
public static double CalculateDamage(Pokemon attackedPokemon, Attack attack)
    {
        Random random = new Random();
        int randomInt = random.Next(1, 101);
        double randomDouble = randomInt / 100.0;
        if (randomDouble <= attack.Accuracy)
        {
            double power = attack.Power;
            double effectivness = GetEffectivness(attack.Type, attackedPokemon.GetTypes());
            double critical = CriticalCheck();
            SpecialCheck(attackedPokemon, attack);
            return power * effectivness * critical;
        }
        return 0.0;
    }
}