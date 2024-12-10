public class Warrior : Player
{
    public Warrior(string name) : base(name)
    {
        HP = 12; 
        AP = 0;  
        Lvl = 10; 
    }
    public override int Attack()
    {
        int baseAttack = base.Attack();
        int enhancedAttack = baseAttack + 2;
        Console.WriteLine($"¡El Guerrero gana un bono de +2 en su ataque y ha hecho un totoal de {enhancedAttack} ");
        return enhancedAttack;
    }
}