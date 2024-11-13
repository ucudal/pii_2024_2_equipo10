namespace Library.Pruebas;

public class AttackVisitor
{
    public string Visit(IAttack? possibleAttack)
    {
        if (possibleAttack == null)
        {
            return "no hay ningún ataque";
        }
        
        if (possibleAttack is SpecialAttack specialAttack)
        {
            return $"{specialAttack.Name}: tipo {specialAttack.Type}, precisión {specialAttack.Accuracy*100}, potencia {specialAttack.Power}, efecto especial {specialAttack.SpecialEffect}, cooldown de uso {specialAttack.Cooldown}\n";
        }
        
        if (possibleAttack is Attack attack)
        {
            return $"{attack.Name}: tipo {attack.Type}, precisión {attack.Accuracy*100}, potencia {attack.Power}\n";
        }
        
        return $"{possibleAttack.Name}: tipo {possibleAttack.Type}, precisión {possibleAttack.Accuracy*100}\n";
    }
}