    public class NaveCargaCombate : NaveCombate
    {
        public int CapacidadMisilesEspeciales { get; set; }

        public NaveCargaCombate(string nombre, int capacidadCarga, double velocidadMaxima, int potenciaAtaque, int capacidadMisilesEspeciales)
            : base(nombre, capacidadCarga, velocidadMaxima, potenciaAtaque)
        {
            CapacidadMisilesEspeciales = capacidadMisilesEspeciales;
        }

        public override void ActivarMisiles()
        {
            base.ActivarMisiles();
            Console.WriteLine($"{Nombre}: Misiles especiales activados con capacidad de {CapacidadMisilesEspeciales} unidades.");
        }

        public override void ModoViaje()
        {
            Console.WriteLine($"{Nombre}: Nave de carga en modo viaje, velocidad ajustada por carga.");
        }
    }
