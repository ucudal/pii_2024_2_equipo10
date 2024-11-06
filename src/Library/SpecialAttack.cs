namespace Library;

public class SpecialAttack : Attack
{
    string SpecialEffect;
    int LastTurnPlayed;

    public SpecialAttack(string name, Type type, int accuracy, int power, string specialEffect): base(name, type, accuracy, power)
    {
        this.LastTurnPlayed = 0;
        
        
    }
}