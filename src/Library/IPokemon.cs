namespace Library;

public interface IPokemon
{
    public string Name
    { get; set;}

    public List<IMove> Moves { get; set;}

    public List<IType> Types { get; set;}

    public int BaseLife
    { get; set;}
    public int CurrentLife
    { get; set;}
    public int BaseAttack
    { get; set;}
    public int BaseDefense
    { get; set;}


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