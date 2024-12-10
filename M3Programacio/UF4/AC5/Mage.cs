public class Mage : Player
{
    public int TurnosHeal {get; set;}
    public Mage(string name) : base(name)
    {
        HP = 8;  
        AP = 0;
        Lvl = 10;
        TurnosHeal = 0;
    }
    public override int Attack()
    {
        int attackRoll = base.Attack();
        Console.WriteLine($"{Name} añade +4 a su ataque por ser un Mago.");
        return attackRoll + 4;
    }

    public void HealIfNecessary()
    {
        TurnosHeal++;
        if (TurnosHeal == 3)
        {
            HP += 2;
            TurnosHeal = 0;
            Console.WriteLine("Te curas 2 de vida gracias al Heal del mago");
        }
    }



}