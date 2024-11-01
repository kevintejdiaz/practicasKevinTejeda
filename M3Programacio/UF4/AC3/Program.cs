    class Program
    {
        static void Main(string[] args)
        {
            MadreNodriza nodriza = new MadreNodriza(" Nave Nodriza", 5000, 9000);
            nodriza.ActivarSistemasDefensa(true);
            nodriza.ModoViaje();

            Console.WriteLine();

            NaveCombate naveCombate = new NaveCombate("Nave de combate", 1000, 12000, 500);
            naveCombate.ActivarSistemasDefensa(true);
            naveCombate.ActivarMisiles();
            naveCombate.ModoViaje();

            Console.WriteLine();

            NaveCargaCombate naveCargaCombate = new NaveCargaCombate("Carga de comabate", 8000, 8000, 300, 10);
            naveCargaCombate.ActivarSistemasDefensa(true);
            naveCargaCombate.ActivarMisiles();
            naveCargaCombate.ModoViaje();
        }
    }
