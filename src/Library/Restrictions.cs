namespace Library;

/// <summary>
/// Luego de haber terminado de implementar la clase Restrictions de esta manera, pienso que podría hacerse mucho más genérica para poder agregar otro tipo de elementos a restringir.
/// De la forma en que está hecha ahora, obliga a repetir mucho código en caso de que, por ejemplo, también quiera agregar restricciones de ataques u otros.
///
/// Por otro lado, agrego que no administré bien el tiempo como para llegar a testear. Me encotnré con varios problemas en el camino que prioricé arreglar por sobre el testeo.
/// Algunos casos importantes a testear serían:
/// -Solo puede hacer restricciones el jugador que comenzará la partida
/// -Solo puede aceptar o rechazar restricciones el jugador que no comenzará la partida
/// -Las restricciones de los diferentes tipos se agregan correctamente a la lista de restricciones de la partida
/// -Las restricciones de difetentes tipos se aplican correctamente (no puede elegirse un pokemon restringido, los items restringidos se eliminan de las listas de items, etc.)
/// -Manejo de casos en inputs inexistentes (por ejemplo: items que no existen, input nulo, etc.)
///
/// Por último, algunos aspectos a mejorar para que esta funcionalidad resulte en una experiencia de usuario más deseable:
/// -Definir una fase obligatoria de elección de restricciones (que pueden igualmente ser nulas) antes de que cualquier jugador comience a elegir su equipo
/// -Establecer un máximo de restricciones (no tiene sentido que queden menos de 6 pokemons disponibles para elegir, por ejemplo)
/// 
///
/// </summary>
public class Restrictions
{
    public List<string> RestrictedTypes { get; }
    
    public List<Pokemon> RestrictedPokemons { get; }
    
    public List<IItem> RestrictedItems { get; }

    public Restrictions()
    {
        this.RestrictedTypes = new List<string>();
        this.RestrictedPokemons = new List<Pokemon>();
        this.RestrictedItems = new List<IItem>();
    }

    public void AddRestriction(string type)
    {
        this.RestrictedTypes.Add(type);
    }

    public void AddRestriction(Pokemon pokemon)
    {
        this.RestrictedPokemons.Add(pokemon);
    }

    public void AddRestriction(IItem item)
    {
        this.RestrictedItems.Add(item);
    }

    public void ClearRestrictions()
    {
        foreach (string type in RestrictedTypes)
        {
            RestrictedTypes.Remove(type);
        }
        foreach (Pokemon poke in RestrictedPokemons)
        {
            RestrictedPokemons.Remove(poke);
        }
        foreach (IItem item in RestrictedItems)
        {
            RestrictedItems.Remove(item);
        }
    }
    
}