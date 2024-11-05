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
    private static Dictionary<Tuple<Type, Type>, double> EffectivnessDataBase 
    {
        // Izquierda tipo del ataque, derecha tipo del pokemon atacado
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
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, grass),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, grass),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, grass),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, grass),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, psychic), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, psychic), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ghost, psychic), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, rock), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, rock), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, rock), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, rock), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fire, rock),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(normal, rock),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, rock),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(flying, rock),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(water, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ice, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(rock, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, ground), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, ground),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(psychic, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, poison), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, poison),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(poison, poison),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(electric, flying), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ice, flying), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(rock, flying), 2.0);
            effectivnessDataBase.Add(new Tuple<Type, Type>(bug, flying),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(fighting, flying),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(grass, flying),0.5);
            effectivnessDataBase.Add(new Tuple<Type, Type>(ground, flying),0.5);

            return effectivnessDataBase;
        }
    }
    
    
    
    public static int CalculateDamage(Pokemon attackerPokemon, Pokemon attackedPokemon, DamageMove move)
    {
        // En un futuro va a tener en cuenta las efectividades de tipos
        return (attackerPokemon.CurrentAttack*move.Power)/2 ; 
    }
}