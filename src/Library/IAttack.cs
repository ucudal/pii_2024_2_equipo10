namespace Library;
// Interfaz creada para subir la cohesión y bajar el acoplamiento.
public interface IAttack: IAction
{ 
    protected string Name { get; }
    protected Type Type {get;}
}