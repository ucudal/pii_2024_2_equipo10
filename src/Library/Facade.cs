namespace Library;

public static class Facade
{
    public static string ChooseTeam(string player, String cPokemon)
    {
        foreach (Game game in )
        {
            if (game.play)
            {
                
            }
            PokemonCatalogue.SetCatalogue();
            foreach (Pokemon pokemon in PokemonCatalogue.PokemonList)
            {
                if (pokemon.Name == cPokemon)
                {
                    player.AddToTeam(pokemon);
                    return $"El pokemon {cPokemon}fue añadido al equipo";
                }
            }

            return $"El pokemon {cPokemon} no fue encontrado";
        }
    }
    
    
}