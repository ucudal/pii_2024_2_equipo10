namespace Library;

/// <summary>
/// Esta clase es la experta en manejar las restricciones de una batalla
/// </summary>
public class RestrictionManager
{
    private bool TypeRestricted { get; set; }

    private bool PokemonRestricted { get; set; }

    private bool ItemRestricted { get; set; }
    
    private List<IItem> ItemsToRestrict { get; set; }
    
    public PokemonCatalogue Pokedex { get; set; }
    public RestrictionManager()
    {
        TypeRestricted = false;
        PokemonRestricted = false;
        ItemRestricted = false;
        ItemsToRestrict = new List<IItem>();
        Pokedex = PokemonCatalogue.Instance;
    }
    
    public string RestrictionType(Type? type)
    {
        if (!Pokedex.CheckPokemonTypes(type))
        {
            return "No hay ningún pokemon que tenga ese tipo";
        }
        for (int i = 0; i < Pokedex.PokemonCount - 1; i++)
        {
            {
                Pokemon pokemon = Pokedex.PokemonList[i];
                if (pokemon.GetTypes()[0] == type)
                {
                    Pokedex.Remove(pokemon);
                }
            }
        }

        TypeRestricted = true;
        return "La restricción ha sido aplicada";
    }
    
    public string RestrictionPokemon(Pokemon playerPokemon)
    {
        if (!Pokedex.CheckPokemonInCatalogue(playerPokemon))
        {
            return "Ese pokemon no se encuentra en el catálogo";
        }
        for (int i = 0; i < Pokedex.PokemonCount - 1; i++)
        {
            {
                Pokemon pokemon = Pokedex.PokemonList[i];
                if (pokemon.Name == playerPokemon.Name)
                {
                    Pokedex.Remove(pokemon);
                }
            }
        }
        

        PokemonRestricted = true;
        return "La restricción ha sido aplicada";
    }

    public string RestrictionItem(Game game)
    {
        if (!ItemRestricted)
        {
            return "No hay restricciones de items";
        }

        string possibleItemNames = "";
        int ItemCount = 7;
        
        
        foreach (IItem pItem in ItemsToRestrict)
        {
            possibleItemNames += pItem.Name;
        }
        foreach (Player player in game.GetPlayers())
        {
            for (int i = 0; i < player.GetItemList().Count - 1; i++)
            {
                {
                    IItem item = player.GetItemList()[i];
                    if (possibleItemNames.Contains(item.Name))
                    {
                        player.GetItemList().Remove(item);
                    }
                }
            }
        }

        ItemRestricted = true;
        return "La restricción ha sido aplicada";
    }

    public string SetRestrictedItem(IItem item)
    {
        ItemsToRestrict.Add(item);
        ItemRestricted = true;
        return "La restricción fue aplicada";
    }
    
    public string GetRestrictions()
    {
        return $"Pokemon restringido: {PokemonRestricted}\nTipo de pokemon restringido: {TypeRestricted}\n Item restringido: {ItemRestricted}\n";
    }
}
    