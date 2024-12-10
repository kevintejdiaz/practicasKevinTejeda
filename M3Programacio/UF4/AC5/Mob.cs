public class Mob : Enemy
{
    public Mob() : base(5, 12, 0, 15) { }

    public override int Attack()
    {
        int baseAttack = base.Attack();
        Console.WriteLine($"El Mob ataca con {baseAttack} puntos de daño.");
        return baseAttack;
    }
}
