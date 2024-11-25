namespace Library.Strategies;

public class StategyNonCrit : IStrategyCritCheck
{
    public double CriticalCheck()
    {
        return 1.0;
    }
}