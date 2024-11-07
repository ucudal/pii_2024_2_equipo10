namespace Library;

public abstract class Pokemon
{
    public string Name { get; set; }
    public List<IAttack> Attacks { get; private set; }
    public List<Type> Type { get; private set; }
    public State? CurrentState { get; set; }
    
    public int AsleepTurns { get; set; }
    public double BaseLife { get; private set; }
    public double CurrentLife { get; set; }
    
    
    protected Pokemon(string name, double life, Type type)
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
        // La lista de IMoves aplica LSP, ya que el pokemon puede tener movimientos de daño (DamageMove) o movimientos de buffeo (StatChangerMove)
        // y el funcionamiento de la lista es el mismo.
        // this.Attacks.Add(attack1);
        // this.Attacks.Add(attack2);
        // this.Attacks.Add(attack3);
        // this.Attacks.Add(attack4);

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
    
}