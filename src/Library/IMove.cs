namespace Library;
// Interfaz creada para subir la cohesión y bajar el acoplamiento.
public interface IMove: IAction
{ 
    string Name { get; }
    bool Special { get;  }
    int LastTurnPlayed { get; }
}