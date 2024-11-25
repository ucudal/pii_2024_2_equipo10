namespace Library.Strategies;

public class StrategyNonCrit : IStrategyCritCheck
{
    
    public double CriticalCheck()
    {
        return 1.0;
    }
}