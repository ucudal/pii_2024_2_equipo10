namespace Library;

public abstract class Pokemon
{
    public string Name { get; set; }
    public List<IMove> Moves { get; private set; }
    public List<Type> Types { get; private set; }
    public int BaseLife { get; private set; }
    public int BaseAttack { get; private set; }
    public int BaseDefense { get; private set; }
    public int CurrentLife { get; private set; }
    public int CurrentAttack { get; private set; }
    public int CurrentDefense { get; private set; }
    
    
    protected Pokemon(int life, int atk, int def)
    {
        //Aplicamos Creator
        this.BaseLife = life;
        this.BaseAttack = atk;
        this.BaseDefense = def;
        this.CurrentLife = BaseLife;
        this.CurrentAttack = BaseAttack;
        this.CurrentDefense = BaseDefense;
        this.Types = new List<Type>();
        Type fire = Type.Fire;
        this.Types.Add(fire);
        // La lista de IMoves aplica LSP, ya que el pokemon puede tener movimientos de daño (DamageMove) o movimientos de buffeo (StatChangerMove)
        // y el funcionamiento de la lista es el mismo.
        this.Moves = new List<IMove>();
        IMove flamethrower = new DamageMove("Flamethrower",false,100,90,fire);
        this.Moves.Add(flamethrower);
    }

    public void RestoreBaseLife()
    {
        this.CurrentLife = BaseLife;
    }

    public void TakeDamage(int damage)
    {
        this.CurrentLife -= damage;
    }
    
}