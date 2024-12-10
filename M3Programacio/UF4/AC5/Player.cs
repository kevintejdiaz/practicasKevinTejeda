public class Player
{
    public int HP { get; set; }
    public int Lvl { get; set; }
    public int AP { get; set; }
    public string Name { get; set; }

    private static Random random = new Random();

    public Player(string name)
    {
        Name = name;
    }

    public virtual int Attack()
    {
        int attackRoll = random.Next(1, 7) + random.Next(1, 7); // Tirada de dos dados de 6 caras
        double enhancedAttack = attackRoll + (AP * 0.10);
        Console.WriteLine($"{Name} ataca con una tirada base de {attackRoll} y un ataque mejorado de {enhancedAttack:F1}.");
        return (int)Math.Floor(enhancedAttack);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Console.WriteLine($"{Name} recibió {damage} puntos de daño. Vida restante: {HP}.");
    }

    public void LevelUp()
    {
        Lvl++;
        Console.WriteLine($"{Name} ha subido de nivel. Nivel actual: {Lvl}.");
    }

    public void GainAP()
    {
        AP++;
        Console.WriteLine($"{Name} ha ganado un punto de habilidad. Puntos actuales: {AP}.");
    }

    public bool IsAlive()
    {
        return HP > 0;
    }

        public void Heal(int amount)
    {
        HP += amount;
        Console.WriteLine($"{Name} ha curado {amount} puntos de vida. Vida actual: {HP}");
    }
}
