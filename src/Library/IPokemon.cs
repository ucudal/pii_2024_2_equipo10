namespace Library;

public interface IPokemon
{
    public string Name
    { get; }

    public List<IMove> Moves { get; }
    
    public int BaseLife
    { get; }
    public int CurrentLife
    { get; }
    public int BaseAttack
    { get; }
    public int CurrentAttack { get;}
    public int BaseDefense
    { get; }
    public int CurrentDefense { get;}

    public void RestoreBaseLife();


    public void TakeDamage(int damage);

    public void BuffAttack(int buff);

    public void BuffDefense(int buff);
    
    
}