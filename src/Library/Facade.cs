namespace Library;

public static class Facade
{
    public static string ChooseTeam(string player, string cPokemon)
    {
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