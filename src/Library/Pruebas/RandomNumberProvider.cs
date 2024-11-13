namespace Library.Pruebas;

public class RandomNumberProvider
{
    private Random random = new Random();

    public int GetRandomNumber(int min, int max)
    {
        return random.Next(min, max);
    }
}