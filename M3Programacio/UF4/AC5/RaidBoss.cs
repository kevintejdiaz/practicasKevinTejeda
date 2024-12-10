public class RaidBoss : Enemy
{
    private int TurnosDesdeUltimaRegeneracion { get; set; }

    public int Resistencia { get; private set; } 
    public RaidBoss() : base(15, 15, 20, 20)
    {
        Resistencia = 5; 
        TurnosDesdeUltimaRegeneracion = 0;
    }

    public override int Attack()
    {
        int firstAttack = base.Attack();
        int secondAttack = base.Attack();

        Console.WriteLine($"El RaidBoss realiza un ataque doble con {firstAttack} y {secondAttack} puntos de daño.");
        return firstAttack + secondAttack;
    }

    public void Regenerate()
    {
        TurnosDesdeUltimaRegeneracion++;
        if (TurnosDesdeUltimaRegeneracion == 3)
        {
            HP += 2; 
            TurnosDesdeUltimaRegeneracion = 0;
            Console.WriteLine("¡El RaidBoss ha regenerado 2 puntos de vida!");
        }
    }

    public override void TakeDamage(int damage)
    {
        int finalDamage = Math.Max(damage - Resistencia, 0);
        base.TakeDamage(finalDamage);
        Console.WriteLine($"El RaidBoss recibió {finalDamage} puntos de daño (resistencia: {Resistencia}).");
    }

    public void EndTurn()
    {
        Regenerate();
    }
}
