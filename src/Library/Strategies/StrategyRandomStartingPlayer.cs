namespace Library.Strategies;

public class StrategyRandomStartingPlayer : IStrategyStartingPlayer
{
    public int StartingPlayer()
    {
        Random random = new Random();
        return random.Next(0, 2);
    }
}