namespace Library.Strategies;

public class StrategyAlwaysCrit : IStrategyCritCheck
{
    public double CriticalCheck()
    {
        return 1.20;
    }
}