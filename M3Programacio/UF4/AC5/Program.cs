class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido invocador");
        Console.WriteLine("Elige tu clase de personaje: ");
        Console.WriteLine("1. Guerrero");
        Console.WriteLine("2. Mago");
        Console.WriteLine("3. Arquero");

        Player player = null;
        bool validChoice = false;

        while (!validChoice)
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Has elegido Guerrero.");
                    player = new Warrior("Jugador");
                    validChoice = true;
                    break;
                case "2":
                    Console.WriteLine("Has elegido Mago.");
                    player = new Mage("Jugador");
                    validChoice = true;
                    break;
                case "3":
                    Console.WriteLine("Has elegido Ranger.");
                    player = new Ranger("Jugador");
                    validChoice = true;
                    break;
                default:
                    Console.WriteLine("Opcion no válida. Por favor, escoge uno de los personages disponibles");
                    break;
            }
        }

        Random random = new Random();
        bool keepPlaying = true;
        string currentEnemy = "Mob";
        while (keepPlaying && player.IsAlive())
        {
            Console.WriteLine("\n--- Generando enemigo ---");
            Enemy enemy;

            switch (currentEnemy)
            {
                case "Mob":
                    enemy = new Mob();
                    Console.WriteLine("¡Un Mob ha aparecido!");
                    break;
                case "Boss":
                    enemy = new Boss();
                    Console.WriteLine("¡Un Boss ha aparecido!");
                    break;
                case "RaidBoss":
                    enemy = new RaidBoss();
                    Console.WriteLine("¡Un RaidBoss ha aparecido!");
                    break;
                default:
                    enemy = new Mob();
                    break;
            }

            Console.WriteLine($"Enemigo: Nivel {enemy.Lvl}, HP: {enemy.HP}");
            Console.WriteLine($"Jugador: Nivel {player.Lvl}, HP: {player.HP}");

            if (player.Lvl > enemy.Lvl)
            {
                Console.WriteLine("Tu nivel es mayor que el del enemigo , ¡Victoria automática!");
                player.LevelUp();
                currentEnemy = GetNextEnemy(currentEnemy);
                continue;
            }

            while (player.IsAlive() && enemy.IsAlive())
            {
                HandleRandomEvent(player);

                Console.WriteLine("\nEs tu turno. ¿Quieres atacar o pasar? (Enter para atacar, cualquier otra tecla para continuar)");
                string playerAction = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(playerAction))  
                {
                    int playerAttack = player.Attack();
                    Console.WriteLine($"¡{player.Name} ataca! Ha hecho {playerAttack} puntos de daño.");
                    enemy.TakeDamage(playerAttack);
                    Console.WriteLine($"El {enemy.GetType().Name} ha recibido {playerAttack} puntos de daño.");
                }
                else
                {
                    Console.WriteLine("Decidiste pasar este turno. El enemigo atacará.");
                }

                if (!enemy.IsAlive())
                {
                    Console.WriteLine("¡Has derrotado al enemigo!");
                    player.LevelUp();
                    currentEnemy = GetNextEnemy(currentEnemy);
                    break;
                }

                int enemyAttack = enemy.Attack();
                Console.WriteLine($"El {enemy.GetType().Name} ataca y hace {enemyAttack} puntos de daño.");
                player.TakeDamage(enemyAttack);

                if (player is Mage mage)
                {
                    mage.HealIfNecessary();
                }
                else if (player is Ranger ranger)
                {
                    ranger.DoubleAttack();
                }

                if (!player.IsAlive())
                {
                    Console.WriteLine("¡Has sido derrotado, C'est fini!");
                }
            }

            if (player.IsAlive())
            {
                Console.WriteLine("¿Quieres continuar jugando? (s/n)");
                string response = Console.ReadLine()?.ToLower();
                if (response != "s")
                {
                    keepPlaying = false;
                    Console.WriteLine("Fin del juego");
                }
            }
        }

        if (!player.IsAlive())
        {
            Console.WriteLine("Fin del juego");
        }
        else
        {
            Console.WriteLine("Has ganado el juego, condragulaciones");
        }
    }

    static string GetNextEnemy(string currentEnemy)
    {
        switch (currentEnemy)
        {
            case "Mob":
                return "Boss";
            case "Boss":
                return "RaidBoss";
            case "RaidBoss":
                return null;
            default:
                return "Mob"; 
        }
    }

    static void HandleRandomEvent(Player player)
    {
        Random random = new Random();
        int eventChance = random.Next(1, 101);

        if (eventChance <= 20)
        {
            int eventType = random.Next(1, 3);
            if (eventType == 1)
            {
                Console.WriteLine("Has pisado una trampa, p+ierdes 2 puntos de vida.");
                player.TakeDamage(2);
            }
            else if (eventType == 2)
            {
                Console.WriteLine("¡Has encontrado un cofre!");
                int lootType = random.Next(1, 4);
                switch (lootType)
                {
                    case 1:
                        Console.WriteLine("Recibes +3 puntos de vida.");
                        player.Heal(3);
                        break;
                    case 2:
                        Console.WriteLine("Recibes +2 puntos de AP.");
                        player.AP += 2;
                        break;
                    case 3:
                        Console.WriteLine("Recibes +1 nivel.");
                        player.LevelUp();
                        break;
                }
            }

        }
    }
}
