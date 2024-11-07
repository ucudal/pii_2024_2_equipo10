namespace Library;
// Interfaz creada para subir la cohesión y bajar el acoplamiento.
public interface IAttack: IAction
{ 
    public string Name { get; }
    public Type Type {get;}
    public double Accuracy {get;}
    public int Power {get; }


}