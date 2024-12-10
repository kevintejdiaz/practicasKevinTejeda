public class Boss : Enemy
{
    private static Random random = new Random();
    private int TurnosDesdeUltimaRegeneracion { get; set; }

    public int Resistencia { get; private set; } // Resistencia aleatoria entre 0 y 5

    public Boss() : base(15, 15, 20, 20) // Vida fija: 15, Nivel fijo: 20
    {
        Resistencia = random.Next(0, 6); // Genera resistencia aleatoria entre 0 y 5
        TurnosDesdeUltimaRegeneracion = 0;
    }

    public override int Attack()
    {
        int firstAttack = base.Attack();
        int secondAttack = base.Attack();
        Console.WriteLine($"El Boss realiza un doble ataque con {firstAttack} y {secondAttack} puntos de daño.");
        return firstAttack + secondAttack;
    }

    public void Regenerate()
    {
        TurnosDesdeUltimaRegeneracion++;
        if (TurnosDesdeUltimaRegeneracion == 3)
        {
            HP += 2; // Regenera 2 puntos de vida
            TurnosDesdeUltimaRegeneracion = 0; // Resetea el contador
            Console.WriteLine("¡El Boss ha regenerado 2 puntos de vida!");
        }
    }
    public void ReduceResistance()
    {
        if (Resistencia > 0)
        {
            Resistencia--;
            Console.WriteLine($"La resistencia del Boss disminuyó a {Resistencia}.");
        }
    }

    public override void TakeDamage(int damage)
    {
        int finalDamage = Math.Max(damage - Resistencia, 0);
        base.TakeDamage(finalDamage);
        Console.WriteLine($"El Boss recibió {finalDamage} puntos de daño (resistencia: {Resistencia}).");
    }
}

