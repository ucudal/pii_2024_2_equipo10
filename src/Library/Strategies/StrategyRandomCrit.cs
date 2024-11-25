namespace Library.Strategies;

public class StrategyRandomCrit : IStrategyCritCheck
{
    public double CriticalCheck()
    {
        Random random = new Random();
        int chance = random.Next(1,11);
        if (chance == 1)
        {
            return 1.20;
        }
        return 1.0;
    }
}