namespace Library;

public abstract class Pokemon
{
    public string Name { get; set; }
    public List<IAttack> Attacks { get; private set; }
    public List<Type> Type { get; private set; }
    public int BaseLife { get; private set; }
    public int CurrentLife { get; private set; }
    
    
    protected Pokemon(string name, int life, Type type)
    {
        //Aplicamos Creator
        this.Name = name;
        this.BaseLife = life;
        this.CurrentLife = BaseLife;
        this.Type = new List<Type>();
        this.Attacks = new List<IAttack>();
        this.Type.Add(type);
        // La lista de IMoves aplica LSP, ya que el pokemon puede tener movimientos de daño (DamageMove) o movimientos de buffeo (StatChangerMove)
        // y el funcionamiento de la lista es el mismo.
        // this.Attacks.Add(attack1);
        // this.Attacks.Add(attack2);
        // this.Attacks.Add(attack3);
        // this.Attacks.Add(attack4);

    }

    public void RestoreBaseLife(int hp)
    {
        if (this.CurrentLife > BaseLife)
        {
            
        }
        else if (this.CurrentLife < BaseLife)
        {
            
        }
        {
            this.CurrentLife += hp;
        }
    }

    public void TakeDamage(int damage)
    {
        this.CurrentLife -= damage;
    }

    public string GetLife()
    {
        return $"{this.CurrentLife}/{this.BaseLife}";
    }
    
}