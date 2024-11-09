namespace Library;

public class Haxorus: Pokemon
{
    public Haxorus():base(name: "Haxorus", life: 356, type: Type.Dragon, new Attack("Outrage",Type.Dragon,0.75,120),new Attack("Assurance", Type.Normal,0.95,80), new Attack("Close Combat", Type.Fighting, 0.75,120) ,new Attack("Dragon claw", Type.Dragon, 1,55)) { 
    }
}