namespace Library;

public static class StateLogic
{
    public static bool AsleepEffect(Pokemon pokemon)
    {
        if (pokemon.CurrentState == State.Asleep)
        {
            if (pokemon.AsleepTurns > 0)
            {
                pokemon.AsleepTurns -= 1;
                return true;
            }

            if (pokemon.AsleepTurns == 0)
            {
                pokemon.CurrentState = null;
            }
        }

        return false;
    }   
    
    public static bool ParalizedEffect(Pokemon pokemon)
    {
        if (pokemon.CurrentState == State.Paralized)
        {
            Random random = new Random();
            int randomNum = random.Next(1, 5);
            if (randomNum == 1)
            {
                return true;
            }
        }
        
        return false;
        
    }

    public static void PoisonedEffect(Pokemon pokemon)
    {
        if (pokemon.CurrentState == State.Poisoned)
        {
            pokemon.CurrentLife -= (int)(pokemon.BaseLife * 0.05);
        }
    }

    public static void BurnedEffect(Pokemon pokemon)
    {
        if (pokemon.CurrentState == State.Burned)
        {
            pokemon.CurrentLife -= (int)(pokemon.BaseLife * 0.10);
        }
    }
}