using System.Security.AccessControl;
using Library;
using Library.Strategies;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using Type = System.Type;

namespace LibraryTests;

/// <summary>
/// Tests de la clase <see cref="Facade"/>
/// </summary>
[TestFixture]
[TestOf(typeof(Facade))]
public class FacadeTest
{
    [SetUp]
    public void SetUp()
    {
        Facade.Instance.Reset();
    }
    
    /// <summary>
    /// Verifica que un jugador puede añadir un Pokemon a su equipo.
    /// </summary>
    [Test]
    public void TestUserStory1Add1Pokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        string result = "El pokemon Caterpie fue añadido al equipo de mateo.\nElegiste 1/6";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Caterpie"), Is.EqualTo(result));
    }
    
    /// <summary>
    /// Comprueba que no se puede añadir un Pokemon ya presente en el equipo del jugador.
    /// </summary>
    [Test]
    public void TestUserStory1RepeatedPokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("mateo", "Caterpie");
        string result = "El pokemon Caterpie ya está en el equipo de mateo, no puedes volver a añadirlo";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Caterpie"), Is.EqualTo(result));
    }
    
    /// <summary>
    /// Verifica que cuando el jugador completa su equipo con 6 Pokemon,
    /// se muestra un mensaje indicando que el equipo está completo.
    /// </summary>
    [Test]
    public void TestUserStory1LastPokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("mateo", "Caterpie");
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");

        string result = $"El pokemon Pikachu fue añadido al equipo de mateo\nTu equipo está completo.";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }
    
    /// <summary>
    ///Comprueba que no se pueden agregar más de 6 Pokemon a un equipo. 
    /// </summary>
    [Test]
    public void TestUserStory1FullTeam()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("mateo", "Caterpie");
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");

        string result = "mateo, ya tienes 6 pokemones en el equipo, no puedes elegir más";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }
    
    /// <summary>
    /// Verifica que se muestre un mensaje de error cuando un jugador intenta elegir un Pokemon sin estar en una partida.
    /// </summary>
    [Test]
    public void TestUserStory1PlayerNotInGame()
    {
        string result = "mateo, para poder elegir un equipo, primero debes estar en una batalla";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Pikachu"), Is.EqualTo(result));
    }

    /// <summary>
    /// Verifica que si un jugador intenta elegir un Pokemon inexistente, se muestra un mensaje de error.
    /// </summary>
    [Test]
    public void TestUserStory1UnknownPokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyRandomStartingPlayer());
        string result = "mateo, el pokemon Chocolate no fue encontrado";
        Assert.That(Facade.Instance.ChooseTeam("mateo", "Chocolate"), Is.EqualTo(result));
    }
    

    /// <summary>
    /// Verifica que un jugador puede ver los ataques de su Pokemon activo.
    /// Si el jugador no tiene Pokemon, se muestra un mensaje que se lo informa.
    /// </summary>
    [Test]
    public void TestUserStory2()
    {
        Assert.That(Facade.Instance.ShowAtacks("mateo"), Is.EqualTo("mateo, no estás en ninguna partida."));
        
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines",  new StrategyRandomStartingPlayer());
        
        Assert.That(Facade.Instance.ShowAtacks("mateo"), Is.EqualTo("mateo, no tienes ningun Pokemon."));
        
        Facade.Instance.ChooseTeam("mateo", "Caterpie");
        string result =
            "mateo, estos son los ataques de tu Pokemon activo:\n**Bug bite**: tipo *Bug*, precisión *100*, potencia *20*\n**Tackle**: tipo *Normal*, precisión *100*, potencia *30*\n**Bug stomp**: tipo *Bug*, precisión *95*, potencia *70*, efecto especial *Paralized*, cooldown de uso actual *0*\n**String shot**: tipo *Bug*, precisión *100*, potencia *15*\n";
        string mateo = Facade.Instance.ShowAtacks("mateo");
        Assert.That(mateo, Is.EqualTo(result));
    }

    /// <summary>
    /// Verifica que si un jugador no está en ninguna partida, se muestra un mensaje de error al
    /// intentar ver el HP de los Pokemon.
    /// </summary>
    [Test]
    public void TestUserStory3NullPlayer()
    {
        string result = "El jugador facu no está en ninguna partida.";
        Assert.That(Facade.Instance.ShowPokemonsHp("facu", null), Is.EqualTo(result));
    }
    
    /// <summary>
    /// Verifica que se muestra el HP de los Pokemon del jugador y también si otro jugador no ha completado su equipo.
    /// </summary>
    [Test]
    public void TestUserStory31Pokemon()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        string result1 = $"facu esta es la vida de tus Pokemons: \n**Charizard: 360/360 (Fire)**\n";
        Assert.That(Facade.Instance.ShowPokemonsHp("facu", null), Is.EqualTo(result1));
        string result2 = "ines aún no tiene su equipo completo.";
        Assert.That(Facade.Instance.ShowPokemonsHp("facu", "ines"), Is.EqualTo(result2));
    }

    /// <summary>
    /// Verifica que cuando ambos jugadores tienen equipos completos, se puede muestrar el HP de los Pokemon de ambos
    /// jugadores.
    /// </summary>
    [Test]
    public void TestUserStory3FullTeams()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");
        Facade.Instance.EditDamageCalculatorStrategy("mateo",new StrategyNonCrit());
        
        string result1 =
            "mateo esta es la vida de tus Pokemons: \n**Charizard: 360/360 (Fire)**\nChikorita: 294/294 (Grass)\n" +
            "Gengar: 324/324 (Ghost)\nDragonite: 460/460 (Dragon)\nHaxorus: 356/356 (Dragon)\nPikachu: 295/295 (Electric)\n";
        
        string result2 =
            "Esta es la vida de los Pokemons de ines: \n**Caterpie: 115/294 (Bug)** **(Burned)**\nChikorita: 294/294 (Grass)\n" +
            "Gengar: 324/324 (Ghost)\nDragonite: 460/460 (Dragon)\nHaxorus: 356/356 (Dragon)\nPikachu: 295/295 (Electric)\n";

        Facade.Instance.ChooseAttack("mateo", "Flamethrower");
        
        Assert.That(Facade.Instance.ShowPokemonsHp("mateo", null), Is.EqualTo(result1));
        Assert.That(Facade.Instance.ShowPokemonsHp("mateo", "ines"), Is.EqualTo(result2));
    }


    /// <summary>
    /// Verifica que un jugador no puede realizar un ataque si no está en una partida.
    /// </summary>
    [Test]
    public void TestUserStory4NullPlayer()
    {
        string result = Facade.Instance.ChooseAttack("facu", "Flamethrower");
        Assert.That(result, Is.EqualTo("facu, para poder atacar necesitas estar en una batalla."));
    }
    
    /// <summary>
    /// Verifica que si alguno de los jugadores no tiene su equipo completo, no pueden realizarse ataques.
    /// </summary>
    [Test]
    public void TestUserStory4IncompleteTeams()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyRandomStartingPlayer());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseAttack("facu", "Flamethrower");
        string result = "facu, alguno de los jugadores no ha completado el equipo";
    }
    
    /// <summary>
    /// Verifica que un jugador puede realizar un ataque solo si es el jugador activo y si el ataque existe en su
    /// lista de ataques.
    /// </summary>
    [Test]
    public void TestUserStory4FullTeams()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");
        Facade.Instance.EditDamageCalculatorStrategy("mateo",new StrategyNonCrit());

        string result1 = Facade.Instance.ChooseAttack("ines", "Bug bite");
        string result2 = Facade.Instance.ChooseAttack("mateo", "aaa");
        string expectedResult2 = "El ataque aaa no pudo ser encontrado";
        
        Assert.That(Facade.Instance.ChooseAttack("mateo", "Wing Attack"), Is.EqualTo("El Caterpie de ines recibió 80 puntos de daño.\n¡Es super efectivo!\n\nPróximo turno, ahora es el turno de ines"));
        Assert.That(result1, Is.EqualTo("ines, no eres el jugador activo"));
        Assert.That(result2, Is.EqualTo(expectedResult2));
    }

    /// <summary>
    /// Verifica que se puede realizar daño en base a las efectividades
    /// </summary>
    [Test]
    public void TestUserStory4SuperEffectiveAttack()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");
        Assert.That(
            Facade.Instance.ChooseAttack("mateo", "Flamethrower")
                .Contains("¡Es super efectivo!", StringComparison.OrdinalIgnoreCase), Is.True);
    }
    
    /// <summary>
    /// Verifica que se puede realizar daño en base a las efectividades
    /// </summary>
    [Test]
    public void TestUserStory4Inmune()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Zeraora");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Charizard");
        Assert.That(Facade.Instance.ChooseAttack("mateo", "Plasma Fist").Contains("es inmune a ataques de tipo Electric", StringComparison.OrdinalIgnoreCase), Is.True);
    }
    
    /// <summary>
    /// Verifica que se puede realizar daño en base a las efectividades
    /// </summary>
    [Test]
    public void TestUserStory4NotVeryEffective()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Zeraora");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Charizard");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");
        Assert.That(Facade.Instance.ChooseAttack("mateo", "Razor leaf").Contains("No es muy efectivo...", StringComparison.OrdinalIgnoreCase), Is.True);
    }

    /// <summary>
    /// Verifica que se muestre correctamente de que jugador es el turno.
    /// </summary>
    [Test]
    public void TestUserStory5()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyPlayerOneStart());
        Assert.That(Facade.Instance.CheckTurn("facu"), Is.EqualTo("facu, es tu turno"));
        Assert.That(Facade.Instance.CheckTurn("ines"), Is.EqualTo("ines, no es tu turno"));
    }
    
    /// <summary>
    /// Verifica que se muestra un mensaje de error al verificar el turno si el jugador no está en ninguna partida.
    /// </summary>
    [Test]
    public void TestUserStory5UnknownPlayer()
    {
        Assert.That(Facade.Instance.CheckTurn("facu"), Is.EqualTo("El jugador facu no está en ninguna partida."));
    }


    /// <summary>
    /// Verifica que se muestra un mensaje de error al corroborar el estado de una partida si la misma no se encuentra.
    /// </summary>
    [Test]
    public void TestUserStory6NullGame()
    {
        Assert.That(Facade.Instance.CheckGameStatus(null), Is.EqualTo("La partida no pudo ser encontrada"));
    }
    
    /// <summary>
    /// Verifica que se muestra el estado correcto del juego, indicando de quien es el siguiente turno.
    /// </summary>
    [Test]
    public void TestUserStory6()
    {
        Player mateo = new Player("mateo");
        Player ines = new Player("ines");
        Game game = new Game(mateo, ines, new StrategyPlayerOneStart());
        Gengar gengar = new Gengar();
        Haxorus haxorus = new Haxorus();
        mateo.AddToTeam(gengar);
        ines.AddToTeam(haxorus);

        game.NextTurn();
        string expected = Facade.Instance.CheckGameStatus(game);
        
        Assert.That(expected, Is.EqualTo("Próximo turno, ahora es el turno de ines"));
    }
    
    /// <summary>
    /// Verifica que se muestre un mensaje indicando 
    /// </summary>
    [Test]
    public void TestUserStory6WinnerTest()
    {
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.EditDamageCalculatorStrategy("mateo", new StrategyNonCrit());
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");
        Facade.Instance.ChooseAttack("mateo", "Dragon claw");
        Facade.Instance.ChangePokemon("ines","Pikachu");
        Facade.Instance.ChooseAttack("mateo", "Dragon claw");
        Facade.Instance.ChangePokemon("ines","Dragonite");
        Facade.Instance.ChooseAttack("mateo", "Dragon claw");
        Facade.Instance.ChangePokemon("ines","Haxorus");
        Facade.Instance.ChooseAttack("mateo", "Dragon claw");
        Facade.Instance.ChangePokemon("ines","Gengar");
        Facade.Instance.ChooseAttack("mateo", "Dragon claw");
        Facade.Instance.ChooseAttack("ines", "Razor leaf");
        Assert.That(Facade.Instance.ChooseAttack("mateo", "Dragon claw"), Is.EqualTo("El Chikorita de ines recibió 55000 puntos de daño\nPERECIÓ :'( \n\nGanador: mateo. Perdedor: ines"));
    }

    /// <summary>
    /// Verifica que se muestra un mensaje de error si un jugador intenta cambiar su Pokemon activo sin estar en una
    /// partida.
    /// </summary>
    [Test]
    public void TestUserStory7NotInGame()
    {
        Assert.That(Facade.Instance.ChangePokemon("mateo", "Pikachu"),
            Is.EqualTo("El jugador mateo no está en ninguna partida."));
    }
    
    /// <summary>
    /// Verifica que un jugador puede cambiar su Pokémon activo solo si está en una partida y si el Pokemon
    /// pertenece a su equipo. Se valida que se muestren mensajes de error si el Pokemon no está en el equipo o si
    /// no es el jugador activo.
    /// </summary>
    [Test]
    public void TestUserStory7(){
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyPlayerTwoStart());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        Facade.Instance.ChooseTeam("facu", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Mewtwo");
        Facade.Instance.ChooseTeam("ines", "Charizard");
        Assert.That(Facade.Instance.ChangePokemon("ines", "Gengar"), 
            Is.EqualTo("Alguno de los jugadores no ha seleccionado 6 Pokemons para iniciar el combate"));
        
        Assert.That(Facade.Instance.ChangePokemon("facu", "Gengar"), 
            Is.EqualTo("facu, no eres el jugador activo, no puedes realizar acciones"));
        
        Facade.Instance.ChooseRandom("ines");
        Facade.Instance.ChooseRandom("facu");
        Assert.That(Facade.Instance.ChangePokemon("ines", "pokemon inexistente"), 
            Is.EqualTo("Ese Pokemon no está en tu equipo.\n"));
        
        Assert.That(Facade.Instance.ChangePokemon("ines", "Mewtwo"), 
            Is.EqualTo("Ese ya es tu Pokemon activo\n"));
        
        Assert.That(Facade.Instance.ChangePokemon("ines", "Charizard"), 
            Is.EqualTo("Charizard es tu nuevo Pokemon activo.\n\nPróximo turno, ahora es el turno de facu"));
    }


    /// <summary>
    /// Verifica que se muestra un mensaje de error si un jugador intenta usar un item sin estar en una partida.
    /// </summary>
    [Test]
    public void TestUserStory8NullPlayer()
    {
        string result = Facade.Instance.UseAnItem("facu", "Super Potion", "Charizard");
        Assert.That(result, Is.EqualTo("El jugador facu no está en ninguna partida."));
    }
    
    /// <summary>
    /// Verifica que un jugador no puede usar un item si el otro jugador no ha completado su equipo.
    /// </summary>
    [Test]
    public void TestUserStory8PlayersNotReady()
    {
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("facu", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("facu", "Charizard");
        string excpected = Facade.Instance.UseAnItem("facu", "Super Potion", "Charizard");
        Assert.That(excpected, Is.EqualTo("Ambos jugadores no han seleccionado 6 pokemones para iniciar el combate"));
    }
    
    /// <summary>
    /// Verifica que el jugador inactivo no pueda usar items.
    /// </summary>
    [Test]
    public void TestUserStory8InactivePlayer()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");

        string result = Facade.Instance.UseAnItem("ines", "Full Health", "Chikorita");
        Assert.That(result, Is.EqualTo("ines, no eres el jugador activo, no puedes realizar acciones"));
    }

    /// <summary>
    /// Verifica que el jugador activo pueda usar un item correctamente.
    /// </summary>
    [Test]
    public void TestUserStory8ExpectedUse()
    {
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Facade.Instance.StartGame("mateo", "ines", new StrategyPlayerOneStart());
        Facade.Instance.ChooseTeam("mateo", "Charizard");
        Facade.Instance.ChooseTeam("mateo", "Chikorita");
        Facade.Instance.ChooseTeam("mateo", "Gengar");
        Facade.Instance.ChooseTeam("mateo", "Dragonite");
        Facade.Instance.ChooseTeam("mateo", "Haxorus");
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("ines", "Caterpie");
        Facade.Instance.ChooseTeam("ines", "Chikorita");
        Facade.Instance.ChooseTeam("ines", "Gengar");
        Facade.Instance.ChooseTeam("ines", "Dragonite");
        Facade.Instance.ChooseTeam("ines", "Haxorus");
        Facade.Instance.ChooseTeam("ines", "Pikachu");

        Facade.Instance.ChooseAttack("mateo", "Fire punch");

        string result = Facade.Instance.UseAnItem("ines", "Super Potion", "Caterpie");
        string expected = $"ines, tu Caterpie ha ganado 70HP.\n¡Super Potion utilizada con éxito!\n\nPróximo turno, ahora es el turno de mateo";
        Assert.That(result, Is.EqualTo(expected));
    }


    /// <summary>
    /// Valida que un jugador pueda ser agregado correctamente a la lista de espera.
    /// </summary>
    [Test]
    public void TestUserStory9()
    {
        Assert.That(Facade.Instance.AddPlayerToWaitingList("facu"), Is.EqualTo("facu agregado a la lista de espera"));
        Assert.That(Facade.Instance.AddPlayerToWaitingList("facu"), Is.EqualTo("facu ya está en la lista de espera"));
    }

    /// <summary>
    /// Verifica que un jugador pueda ser eliminado de la lista de espera correctamente.
    /// </summary>
    [Test]
    public void TestUserStory9_1()
    {
        Assert.That(Facade.Instance.RemovePlayerFromWaitingList("facu"), Is.EqualTo("facu no está en la lista de espera"));
        Facade.Instance.AddPlayerToWaitingList("facu");
        Assert.That(Facade.Instance.RemovePlayerFromWaitingList("facu"), Is.EqualTo("facu removido de la lista de espera"));
 
    }


    /// <summary>
    /// Verifica que la lista de jugadores en espera se muestre correctamente.
    /// </summary>
    [Test]
    public void TestUserStory10()
    {
        Assert.That(Facade.Instance.GetAllPlayersWaiting(), Is.EqualTo("No hay nadie esperando"));
        Facade.Instance.AddPlayerToWaitingList("facu");
        Assert.That(Facade.Instance.GetAllPlayersWaiting(), Is.EqualTo("Esperan: facu; "));
        Facade.Instance.AddPlayerToWaitingList("ines");
        Assert.That(Facade.Instance.GetAllPlayersWaiting(), Is.EqualTo("Esperan: facu; ines; "));
    }


    /// <summary>
    /// Verifica la lógica de inicio de partida entre dos jugadores en espera.
    /// </summary>
    [Test]
    public void TestUserStory11()
    {
        Assert.That(Facade.Instance.StartGame("facu", null,  new StrategyRandomStartingPlayer()), Is.EqualTo("facu, no estás en la lista de espera"));
        Assert.That(Facade.Instance.StartGame("facu", "ines",  new StrategyRandomStartingPlayer()), Is.EqualTo("facu, no estás en la lista de espera"));
        Facade.Instance.AddPlayerToWaitingList("facu");
        Facade.Instance.AddPlayerToWaitingList("ines");
        Assert.That(Facade.Instance.StartGame("facu", "ines",  new StrategyRandomStartingPlayer()).Contains("Comienza facu Vs. ines"));
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Assert.That(Facade.Instance.StartGame("facu", null, new StrategyRandomStartingPlayer()), Is.EqualTo("facu ya está en una partida"));
        Assert.That(Facade.Instance.StartGame("mateo", "facu", new StrategyRandomStartingPlayer()), Is.EqualTo("facu no está esperando"));
        Assert.That(Facade.Instance.StartGame("mateo", null, new StrategyRandomStartingPlayer()), Is.EqualTo("No hay nadie más en la lista de espera"));
        Facade.Instance.AddPlayerToWaitingList("mati");
        Assert.That(Facade.Instance.StartGame("mateo", null, new StrategyRandomStartingPlayer()).Contains("Comienza mateo Vs. mati"));
    }

    /// <summary>
    /// Verifica que un jugador solo pueda rendirse si está en una partida activa.
    /// </summary>
    [Test]
    public void TestSurrender()
    {
        Facade.Instance.AddPlayerToWaitingList("Facu");
        string result1 = Facade.Instance.Surrender("Facu");
        Assert.That(result1, Is.EqualTo("Facu, Para rendirte primero debes estar en una batalla"));
        Facade.Instance.AddPlayerToWaitingList("Mati");
        Facade.Instance.StartGame("Facu", "Mati", new StrategyRandomStartingPlayer());
        string result2 = Facade.Instance.Surrender("Facu");
        Assert.That(result2, Is.EqualTo("El jugador Facu se ha rendido.\nGanador: Mati \nPerdedor: Facu"));
    }

    /// <summary>
    /// Verifica que los items disponibles de un jugador se muestren correctamente.
    /// </summary>
    [Test]
    public void TestShowItems()
    {
        Assert.That(Facade.Instance.ShowItems("mateo"), Is.EqualTo(("mateo, no estás en una partida.")));
        Facade.Instance.AddPlayerToWaitingList("mateo");
        Facade.Instance.AddPlayerToWaitingList("pepe");
        Facade.Instance.StartGame("mateo", "pepe", new StrategyPlayerOneStart());
        Assert.That(Facade.Instance.ShowItems("mateo"), Is.EqualTo("mateo, estos son tus items disponibles:\n1 Revive\n4 Super Potion\n2 Full Health\n"));
        Facade.Instance.ChooseTeam("mateo", "Pikachu");
        Facade.Instance.ChooseTeam("pepe", "Charizard");
        Facade.Instance.ChooseRandom("mateo");
        Facade.Instance.ChooseRandom("pepe");
        Facade.Instance.ChooseAttack("mateo", "Thunder Shock");
        Facade.Instance.UseAnItem("pepe", "Super Potion", "Charizard");
        Assert.That(Facade.Instance.ShowItems("pepe"), Is.EqualTo("pepe, estos son tus items disponibles:\n1 Revive\n3 Super Potion\n2 Full Health\n"));
    }

    
    [Test]
    public void TestEditDamageCalculatorStrategy()
    {
        Facade.Instance.AddPlayerToWaitingList("Facu");
        Facade.Instance.AddPlayerToWaitingList("Mateo");
        Assert.That(Facade.Instance.EditDamageCalculatorStrategy("Facu",new StrategyNonCrit()),Is.EqualTo("Facu, no estás en una partida."));
        Facade.Instance.StartGame("Facu", "Mateo", new StrategyRandomStartingPlayer());
        Assert.That(Facade.Instance.EditDamageCalculatorStrategy("Facu",new StrategyNonCrit()),Is.EqualTo("Estrategia de daño crítico ha sido modificada"));
    }

}