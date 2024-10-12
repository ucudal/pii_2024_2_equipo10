namespace Library;

public class Charizard : IPokemon
{
    public string Name { get; set; }
    public List<IMove> Moves { get; private set; }
    public List<IType> Types { get; private set; }
    public int BaseLife { get; private set; }
    public int BaseAttack { get; private set; }
    public int BaseDefense { get; private set; }
    public int CurrentLife { get; private set; }
    public int CurrentAttack { get; private set; }
    public int CurrentDefense { get; private set; }


    public Charizard()
    {
        //Aplicamos Creator
        this.Name = "Charizard";
        this.BaseLife = 80;
        this.BaseAttack = 109;
        this.BaseDefense = 85;
        this.CurrentLife = BaseLife;
        this.CurrentAttack = BaseAttack;
        this.CurrentDefense = BaseDefense;
        this.Types = new List<IType>();
        Fire fire = new Fire();
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

    public void BuffAttack(int buff)
    {
        this.CurrentAttack *= buff;
    }

    public void BuffDefense(int buff)
    {
        this.CurrentDefense *= buff;
    }
}