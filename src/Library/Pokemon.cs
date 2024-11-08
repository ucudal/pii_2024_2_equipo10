using System.Collections.ObjectModel;

namespace Library;

/// <summary>
/// Esta clase representa un Pokemon.
/// </summary>
public abstract class Pokemon
{
    /// <summary>
    /// Nombre del Pokemon.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Lista de ataques de un Pokemon.
    /// </summary>
    private List<IAttack> Attacks { get; set; }
    
    /// <summary>
    /// Lista de tipos de un Pokemon
    /// </summary>
    private List<Type> Type { get; set; }
    
    /// <summary>
    /// Estado actual de un pokemon.
    /// </summary>
    public State? CurrentState { get; set; }
    
    /// <summary>
    /// Cantidad de turnos que el Pokemon está dormido.
    /// </summary>
    public int AsleepTurns { get; set; }
    
    /// <summary>
    /// Vida base del Pokemon.
    /// </summary>
    public double BaseLife { get; private set; }
    
    /// <summary>
    /// Vida actual del Pokemon.
    /// </summary>
    public double CurrentLife { get; set; }
    
    /// <summary>
    /// Asigna el nombre, la vida base, el tipo y los ataques del Pokemon a la lista de ataques del Pokemon a crear.
    /// Inicializa el estado actual en null y los turnos dormido en 0. 
    /// 
    /// </summary>
    /// <param name="name">Nombre del pokemon a crear.</param>
    /// <param name="life">Vida base del Pokemon a crear.</param>
    /// <param name="type">Tipo del pokemon a crear.</param>
    /// <param name="attack1">Ataque 1.</param>
    /// <param name="attack2">Ataque 2.</param>
    /// <param name="attack3">Ataque 3.</param>
    /// <param name="attack4">Ataque 4.</param>
    protected Pokemon(string name, double life, Type type, IAttack attack1, IAttack attack2, IAttack attack3, IAttack attack4)
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
        // La lista de IMoves aplica LSP, ya que el Pokemon puede tener movimientos de daño (DamageMove) o
        // movimientos de buffeo (StatChangerMove)
        // y el funcionamiento de la lista es el mismo.
        this.AddAttack(attack1);
        this.AddAttack(attack2);
        this.AddAttack(attack3);
        this.AddAttack(attack4);

    }

    /// <summary>
    /// Suma puntos de vida a la vida actual, considerando que la vida actual no
    /// puede ser mayor a la vida base del Pokemon.
    /// </summary>
    /// <param name="hp">Puntos de vida a recuperar.</param>
    public void GainLife(double hp)
    {
        this.CurrentLife += hp;
        if (this.CurrentLife > this.BaseLife)
        {
            this.CurrentLife = BaseLife;
        }
        
    }

    /// <summary>
    /// Resta puntos de vida a la vida actual. Convierte double a int para poder hacer la resta.
    /// Si la resta es menor a 0, le asigna 0 a la vida actual.
    /// </summary>
    /// <param name="damage">Puntos de vida a quitar.</param>
    public void TakeDamage(double damage)
    {
        this.CurrentLife -= (int)Math.Round(damage);
        if (this.CurrentLife < 0)
        {
            this.CurrentLife = 0;
        }
    }

    /// <summary>
    /// Devuele la vida del Pokemon en el formato vidaActual/vidaBase
    /// </summary>
    /// <returns></returns>
    public string GetLife()
    {
        return $"{this.CurrentLife}/{this.BaseLife}";
    }

    /// <summary>
    /// Devuelve la lista de ataques del Pokemon
    /// </summary>
    /// <returns></returns>
    public List<IAttack> GetAttacks()
    {
        return this.Attacks;
    }
    
    /// <summary>
    /// Devuelve la lista de tipos del Pokemon.
    /// </summary>
    /// <returns></returns>
    public  List<Type> GetTypes()
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
        if (attackString != null)
        {
            foreach (IAttack attack in Attacks)
            {
                if (attack is Attack attack2 && attack.Name == attackString)
                {
                    return attack2;
                }

            }
        }
        return null;
    }
    
}