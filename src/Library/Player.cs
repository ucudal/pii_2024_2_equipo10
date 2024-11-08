namespace Library;

/// <summary>
/// Esta clase representa un jugador.
/// </summary>
public class Player
{
    /// <summary>
    /// Nombre del jugador.
    /// </summary>
    public string  Name { get; }
    
    /// <summary>
    /// Lista de Pokemon del jugador
    /// </summary>
    private List<Pokemon> PokemonTeam { get; set;}
    
    /// <summary>
    /// Lista de items del jugador.
    /// </summary>
    private List<IItem> Items { get; set;}
    
    /// <summary>
    /// Pokemon activo del jugador.
    /// </summary>
    public Pokemon ActivePokemon { get; private set; }

    /// <summary>
    /// Le asigna un nombre al jugador, crea las listas de pokemons e items
    /// agregando items iniciales.
    /// </summary>
    /// <param name="name">Nombre del jugador a crear.</param>
    public Player(string name)
    {
        this.Name = name;
        this.PokemonTeam = new List<Pokemon>();
        this.Items = new List<IItem>();
        this.Items.Add(new Revive());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new SuperPotion());
        this.Items.Add(new FullHealth());
        this.Items.Add(new FullHealth());
    }
    
    /// <summary>
    /// Agrega un pokemon a la lista de pokemons del jugador.
    /// </summary>
    /// <param name="pokemon">Pokemon a agregar</param>
    public void AddToTeam(Pokemon pokemon)
    {
        if (this.PokemonTeam.Count < 6)
        {
            this.PokemonTeam.Add(pokemon);
        }
    }

    /// <summary>
    /// Cambia el pokemon activo si está vivo.
    /// </summary>
    /// <param name="pokemon">Nuevo pokemon activo.</param>
    /// <returns>
    ///<c>true</c> si se cambió el pokemon activo. <c>false</c> si el pokemon elegido no tiene vida.
    /// </returns>
    public bool SetActivePokemon(Pokemon pokemon)
    {
        if (pokemon != null)
        {
            if (pokemon.CurrentLife > 0)
            {
                this.ActivePokemon = pokemon;
                return true;
            }
            return false;
        }
        return false;
    }
    
    /// <summary>
    /// Devuelve un pokemon de la lista del jugador buscandolo por el nombre.
    /// </summary>
    /// <param name="strPokemon">Nombre del pokemon a buscar.</param>
    /// <returns>
    /// <c>null</c> si el pokemon no está en la lista de pokemons.
    /// </returns>
    public Pokemon ChoosePokemon(string strPokemon)
    {
        foreach (Pokemon pokemon in this.PokemonTeam)
        {
            if (pokemon.Name == strPokemon)
            {
                return pokemon;
            }
        }
        return null;
    }
    
    /// <summary>
    /// Devuelve un item de la lista de items buscandolo por su nombre.
    /// </summary>
    /// <param name="strItem">Nombre del item a buscar.</param>
    /// <returns>
    ///<c>null</c> si el item no está en la lista items. 
    /// </returns>
    public IItem ChooseItem(string strItem)
    {
        foreach (IItem item in this.Items)
        {
            if (item.Name == strItem)
            {
                return item;
            }
        }

        return null;
    }

    /// <summary>
    /// Devuelve un ataque de la lista de ataques del pokemon activo.
    /// </summary>
    /// <param name="strAttack">Nombre del ataque a buscar.</param>
    /// <returns>
    /// <c>null</c> si el ataque no se encuentra en la lista de ataques. 
    /// </returns>
    public Attack ChooseAttack(string strAttack)
    {
        foreach (IAttack attack in this.ActivePokemon.GetAttacks())
        {
            if (attack.Name == strAttack && attack is Attack attack2)
            {
                return attack2;
            }
        }
        return null;
    }

    /// <summary>
    /// Devuelve la lista de pokemons del jugador.
    /// </summary>
    /// <returns></returns>
    public List<Pokemon> GetPokemonTeam()
    {
        return this.PokemonTeam;
    }
    
    /// <summary>
    /// Devuelve la lista de items del jugador.
    /// </summary>
    /// <returns></returns>
    public List<IItem> GetItemList()
    {
        return this.Items;
    }
    
}
