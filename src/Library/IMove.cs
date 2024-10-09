namespace Library;

public interface IMove: IAction
{ 
    string Name { get; }
    bool Special { get;  }
    int LastTurnPlayed { get; }
}