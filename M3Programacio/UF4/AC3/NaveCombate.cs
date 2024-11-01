   public class NaveCombate : MadreNodriza
    {
        public int PotenciaAtaque { get; set; }

        public NaveCombate(string nombre, int capacidadCarga, double velocidadMaxima, int potenciaAtaque)
            : base(nombre, capacidadCarga, velocidadMaxima)
        {
            PotenciaAtaque = potenciaAtaque;
        }

        public override void ActivarSistemasDefensa(bool activar)
        {
            base.ActivarSistemasDefensa(activar);
            if (activar)
            {
                Console.WriteLine($"{Nombre}: Sistemas de defensa preparados para combate.");
            }
        }

        public virtual void ActivarMisiles()
        {
            Console.WriteLine($"{Nombre}: Misiles activados con potencia de ataque de {PotenciaAtaque}.");
        }
    }