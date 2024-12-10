public class Ranger : Player
{
    private int TurnosDoubleAttack { get; set; }

    public Ranger(string name) : base(name)
    {
        HP = 10;
        AP = 0;
        Lvl = 10;
        TurnosDoubleAttack = 0;
    }
  public override int Attack()
    {
        int attackRoll = base.Attack(); // Obtiene el daño básico de la clase base Player
        Console.WriteLine($"{Name} añade +3 a su ataque por ser un Arquero.");
        return attackRoll + 3; // Daño con el bono específico del Ranger
    }

    public void DoubleAttack()
    {
        TurnosDoubleAttack++;
        if (TurnosDoubleAttack == 3)
        {
            Console.WriteLine($"{Name} usa su habilidad de ataque doble.");
            int firstAttack = Attack();
            int secondAttack = Attack();
            TurnosDoubleAttack = 0; 
            Console.WriteLine($"Ataque doble total: {firstAttack + secondAttack}");
        }
    }
}
