namespace Library;

public class SpecialAttack : Attack
{
    public State SpecialEffect { get; private set; }
    public int Cooldown { get; private set; }

    public SpecialAttack(string name, Type type, int accuracy, int power, State specialEffect): base(name, type, accuracy, power)
    {
        this.Cooldown = 0;
        this.SpecialEffect = specialEffect;
    }

    public void LowerCooldown()
    {
        if (Cooldown > 0)
        {
            Cooldown -= 1;
        }
    }
}