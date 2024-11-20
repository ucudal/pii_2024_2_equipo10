namespace Library;
/// <summary>
/// Esta clase representa la lógia de los estados del Pokemon.
/// </summary>
public static class StateLogic
{
    /// <summary>
    /// Devuelve si el Pokemon está dormido o no.
    /// Si está dormido le resta uno a la cantidad de turnos que
    /// debe estar dormido.
    /// </summary>
    /// <param name="pokemon">Pokemon a checkear si está dormido.</param>
    /// <returns>
    /// <c>true</c> si el Pokemon está dormido. <c>false</c> si no.
    /// </returns>
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
                pokemon.EditState(null);
            }
        }

        return false;
    }   
    
    /// <summary>
    /// Devuelve si el Pokemon está paralizado o no.
    /// Si lo está tiene 25% de chance de dejar de estar paralizado
    /// </summary>
    /// <param name="pokemon">Pokemon a checkear si está paralizado.</param>
    /// <returns>
    /// <c>true</c> si el Pokemon está paralizado. <c>false</c> si no.
    /// </returns>
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

    /// <summary>
    /// Devuelve si el Pokemon está envenenado o no.
    /// Si está envenenado le resta uno a la cantidad de turnos que
    /// debe estar paralizado.
    /// </summary>
    /// <param name="pokemon">Pokemon a checkear si está paralizado.</param>
    /// <returns>
    /// <c>true</c> si el Pokemon está paralizado. <c>false</c> si no.
    /// </returns>
    public static void PoisonedEffect(Pokemon pokemon)
    {
        pokemon.CurrentLife -= (int)(pokemon.BaseLife * 0.05);
    }
    
    /// <summary>
    /// Si el Pokemon está quemandose recibirá daño.
    /// </summary>
    /// <param name="pokemon">Nombre del Pokemon</param>
    public static void BurnedEffect(Pokemon pokemon)
    {
        pokemon.CurrentLife -= (int)(pokemon.BaseLife * 0.10);
    }
}