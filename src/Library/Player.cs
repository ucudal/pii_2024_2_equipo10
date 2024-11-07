namespace Library;
using Library;

public class Player
{
    public string  Name { get; }
    public List<Pokemon> PokemonTeam { get; private set;}
    public List<IItem> Items { get; private set;}
    public Pokemon ActivePokemon { get; private set; }

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
    
    public void AddToTeam(Pokemon pokemon)
    {
        if (this.PokemonTeam.Count < 6)
        {
            this.PokemonTeam.Add(pokemon);
        }
    }

    public void SetActivePokemon(Pokemon pokemon)
    {
        this.ActivePokemon = pokemon;
    }
    
    public Pokemon? ChoosePokemon(string strPokemon)
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

    public IItem? ChooseItem(string strItem)
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

    public IAttack? ChooseAttack(string strAttack)
    {
        foreach (IAttack attack in this.ActivePokemon.Attacks)
        {
            if (attack.Name == strAttack)
            {
                return attack;
            }
        }

        return null;
    }
    
}
