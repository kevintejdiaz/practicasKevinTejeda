public class Enemy
{
    public int HP { get; set; }
    public int Lvl { get; set; }
    private static Random random = new Random();

    public Enemy(int minHP, int maxHP, int minLevel, int maxLevel)
    {
        HP = random.Next(minHP, maxHP + 1);
        Lvl = random.Next(minLevel, maxLevel + 1);
    }

    public virtual int Attack()
    {
        return random.Next(1, 7) + random.Next(1, 7);
    }

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
    }

    public bool IsAlive()
    {
        return HP > 0; 
    }
}
