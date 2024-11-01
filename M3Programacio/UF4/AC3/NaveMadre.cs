    public class MadreNodriza
    {
        public string Nombre { get; set; }
        public int CapacidadCarga { get; set; }
        public double VelocidadMaxima { get; set; }

        public MadreNodriza(string nombre, int capacidadCarga, double velocidadMaxima)
        {
            Nombre = nombre;
            CapacidadCarga = capacidadCarga;
            VelocidadMaxima = velocidadMaxima;
        }

        public virtual void ActivarSistemasDefensa(bool activar)
        {
            string estado;
            if (activar)
            {
                estado = "activados";
            }
            else
            {
                estado = "desactivados";
            }
            Console.WriteLine($"{Nombre}: Sistemas de defensa {estado}.");
        }


        public virtual void ModoViaje()
        {
            Console.WriteLine($"{Nombre}: Nave en modo viaje a velocidad máxima de {VelocidadMaxima}.");
        }
    }