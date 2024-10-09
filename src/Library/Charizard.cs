namespace Library;

public class Charizard : IPokemon
{
    public string Name { get; }
    public List<IMove> Moves { get; private set; } = new List<IMove>();
    public List<IType> Types { get; } = new List<IType>();
    public int BaseLife { get; }
    public int BaseAttack { get; }
    public int BaseDefense { get; }
    public int CurrentLife { get; }

    public void RestoreBaseLife()
    {
        
    }

    public void Attack(IMove move)
    {
        
    }

    public void TakeDamage(int damage)
    {
        
    }

}