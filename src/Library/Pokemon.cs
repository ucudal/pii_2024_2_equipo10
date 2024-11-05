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
    
    
    protected Pokemon(string name, int life, Type type, IMove move)
    {
        //Aplicamos Creator
        this.Name = name;
        this.BaseLife = life;
        this.CurrentLife = BaseLife;
        this.Types = new List<Type>();
        this.Moves = new List<IMove>();
        this.Types.Add(type);
        // La lista de IMoves aplica LSP, ya que el pokemon puede tener movimientos de daño (DamageMove) o movimientos de buffeo (StatChangerMove)
        // y el funcionamiento de la lista es el mismo.
        this.Moves.Add(move);
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