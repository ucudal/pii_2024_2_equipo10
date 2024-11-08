namespace Library;

public abstract class Pokemon
{
    public string Name { get; set; }
    private List<IAttack> Attacks { get; set; }
    private List<Type> Type { get; set; }
    public State? CurrentState { get; private set; }

    public int AsleepTurns { get; set; }
    public double BaseLife { get; private set; }
    public double CurrentLife { get; set; }


    protected Pokemon(string name, double life, Type type, IAttack attack1, IAttack attack2, IAttack attack3,
        IAttack attack4)
    {
        //Aplicamos Creator
        this.Name = name;
        this.BaseLife = life;
        this.CurrentState = null;
        this.CurrentLife = BaseLife;
        this.Type = new List<Type>();
        this.Attacks = new List<IAttack>();
        this.Type.Add(type);
        this.AsleepTurns = 0;
        // La lista de IMoves aplica LSP, ya que el pokemon puede tener movimientos de daño (DamageMove)
        // y el funcionamiento de la lista es el mismo.
        this.AddAttack(attack1);
        this.AddAttack(attack2);
        this.AddAttack(attack3);
        this.AddAttack(attack4);

    }

    public void RestoreBaseLife(double hp)
    {

        this.CurrentLife += hp;
        if (this.CurrentLife > hp)
        {
            this.CurrentLife = BaseLife;
        }

    }

    public void TakeDamage(double damage)
    {
        this.CurrentLife -= (int)Math.Round(damage);
        if (this.CurrentLife < 0)
        {
            this.CurrentLife = 0;
        }
    }

    public string GetLife()
    {
        return $"{this.CurrentLife}/{this.BaseLife}";
    }

    public List<IAttack> GetAttacks()
    {
        return this.Attacks;
    }

    public List<Type> GetTypes()
    {
        return this.Type;
    }

    public void EditState(State? state)
    {
        this.CurrentState = state;
    }

    public void AddAttack(IAttack attack)
    {
        if (this.Attacks.Count < 4)
        {
            this.Attacks.Add(attack);
        }
    }

    public Attack FindAttackByName(string attackString)
    {
        foreach (IAttack attack in Attacks)
        {
            if (attack is Attack attack2)
            {
                return attack2;
            }

        }

        return null;
    }
}