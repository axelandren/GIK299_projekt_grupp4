using System;

namespace GIK299_projekt_grupp4
{
    class Game : World
    {
        public Hero currentHero;
        public Enemy enemy;
        private ConsoleKey key;
        public void Menu()
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine("Start new game by typing (start) or exit by typing (exit)");
                string startOrExit = Console.ReadLine();
                string answerInLowerCase = startOrExit.ToLower();
                switch (answerInLowerCase)
                {
                    case "start":
                        GameStartInfo();
                        Start();
                        break;
                    case "exit":
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        public void Start()
        {
            Console.CursorVisible = false;

            currentHero = new Hero(1, 49);
            enemy = new Enemy();
            RunGameLoop();
        }
        private void RunGameLoop()
        {
            while (true)
            {
                DrawGame();
                PlayerInput();

                //Kolla om heron har nått exit / hittat nyckel / dött
                string stringAtPlayerPos = GetStringAt(currentHero.Col, currentHero.Row);
                if (stringAtPlayerPos == "F" && currentHero.NumberOfKeys == 10)
                {
                    GameFinishInfo();
                    break;
                }
                else if (stringAtPlayerPos == "K")
                {
                    Console.WriteLine(" You found one of the keys!");
                    System.Threading.Thread.Sleep(1500);
                    currentHero.NumberOfKeys += 1;
                    ChangeStringToEmpty(currentHero.Col, currentHero.Row);
                }
                else if (currentHero.Health < 0)
                {
                    GameLostInfo();
                    break;
                }
            }
        }
        private void DrawGame()
        {
            Console.Clear();
            DrawWorld();
            Console.WriteLine("\nYour hero: {0}", currentHero.GetName());
            if (currentHero.NumberOfKeys < 10)
            {
                Console.WriteLine("\nAmount of keys: {0}", currentHero.NumberOfKeys);
            }
            else
            {
                Console.WriteLine("\nYou have collected all the keys, now find the exit 'F'");
            }
            Console.WriteLine("Health: {0}", currentHero.Health);
            enemy.DrawEnemies();
            currentHero.DrawHero();

            string stringAtPlayerPos = GetStringAt(currentHero.Col, currentHero.Row);
            if (stringAtPlayerPos == "F" && currentHero.NumberOfKeys < 10)
            {
                Console.WriteLine("\n You don't have all the keys! Come back when you've collected them all");
            }
        }
        private void GameStartInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(@"
             ___       __   _______   ___       ________  ________  _____ ______   _______      
            |\  \     |\  \|\  ___ \ |\  \     |\   ____\|\   __  \|\   _ \  _   \|\  ___ \     
            \ \  \    \ \  \ \   __/|\ \  \    \ \  \___|\ \  \|\  \ \  \\\__\ \  \ \   __/|    
             \ \  \  __\ \  \ \  \_|/_\ \  \    \ \  \    \ \  \\\  \ \  \\|__| \  \ \  \_|/__  
              \ \  \|\__\_\  \ \  \_|\ \ \  \____\ \  \____\ \  \\\  \ \  \    \ \  \ \  \_|\ \ 
               \ \____________\ \_______\ \_______\ \_______\ \_______\ \__\    \ \__\ \_______\
                \|____________|\|_______|\|_______|\|_______|\|_______|\|__|     \|__|\|_______|
  _________  ________          _________  ___  ___  _______           ________  ________  _____ ______   _______      
 |\___   ___\\   __  \        |\___   ___\\  \|\  \|\  ___ \         |\   ____\|\   __  \|\   _ \  _   \|\  ___ \     
 \|___ \  \_\ \  \|\  \       \|___ \  \_\ \  \\\  \ \   __/|        \ \  \___|\ \  \|\  \ \  \\\__\ \  \ \   __/|    
      \ \  \ \ \  \\\  \           \ \  \ \ \   __  \ \  \_|/__       \ \  \  __\ \   __  \ \  \\|__| \  \ \  \_|/__  
       \ \  \ \ \  \\\  \           \ \  \ \ \  \ \  \ \  \_|\ \       \ \  \|\  \ \  \ \  \ \  \    \ \  \ \  \_|\ \ 
        \ \__\ \ \_______\           \ \__\ \ \__\ \__\ \_______\       \ \_______\ \__\ \__\ \__\    \ \__\ \_______\
         \|__|  \|_______|            \|__|  \|__|\|__|\|_______|        \|_______|\|__|\|__|\|__|     \|__|\|_______|");

            Console.ResetColor();
            Console.WriteLine("\n\n\t\t>Use the arrow keys to move: (up = ↑)(↓ = down) (left = ←)(right = →)");
            Console.Write("\t\t>Press 'a' to perform an action when you are in a room with enemies '");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("E");
            Console.ResetColor();
            Console.Write("'");
            Console.WriteLine("\n\t\t>The main goal is to find and grab all the keys 'K' and then find the exit 'F'");
            Console.WriteLine("\t\t>The keys are placed randomly around the map.");
            Console.Write("\n\t\t>This is your hero: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.ResetColor();
            Hero.SetHeroName();
            Console.WriteLine("\n\t\t>Press any key to start...");
            Console.ReadKey(true);
            Console.ResetColor();
            Console.Clear();
        }
        private void GameFinishInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(@"
  ________  ________  ________   ________  ________  ________  _________  ___  ___  ___       ________  _________  ___  ________  ________   ________      
 |\   ____\|\   __  \|\   ___  \|\   ____\|\   __  \|\   __  \|\___   ___\\  \|\  \|\  \     |\   __  \|\___   ___\\  \|\   __  \|\   ___  \|\   ____\     
 \ \  \___|\ \  \|\  \ \  \\ \  \ \  \___|\ \  \|\  \ \  \|\  \|___ \  \_\ \  \\\  \ \  \    \ \  \|\  \|___ \  \_\ \  \ \  \|\  \ \  \\ \  \ \  \___|_    
  \ \  \    \ \  \\\  \ \  \\ \  \ \  \  __\ \   _  _\ \   __  \   \ \  \ \ \  \\\  \ \  \    \ \   __  \   \ \  \ \ \  \ \  \\\  \ \  \\ \  \ \_____  \   
   \ \  \____\ \  \\\  \ \  \\ \  \ \  \|\  \ \  \\  \\ \  \ \  \   \ \  \ \ \  \\\  \ \  \____\ \  \ \  \   \ \  \ \ \  \ \  \\\  \ \  \\ \  \|____|\  \  
    \ \_______\ \_______\ \__\\ \__\ \_______\ \__\\ _\\ \__\ \__\   \ \__\ \ \_______\ \_______\ \__\ \__\   \ \__\ \ \__\ \_______\ \__\\ \__\____\_\  \ 
     \|_______|\|_______|\|__| \|__|\|_______|\|__|\|__|\|__|\|__|    \|__|  \|_______|\|_______|\|__|\|__|    \|__|  \|__|\|_______|\|__| \|__|\_________\
                                                                                                                                               \|_________/
  ___    ___ ________  ___  ___          ___       __   ________  ________           _________  ___  ___  _______           ________  ________  _____ ______   _______      
 |\  \  /  /|\   __  \|\  \|\  \        |\  \     |\  \|\   __  \|\   ___  \        |\___   ___\\  \|\  \|\  ___ \         |\   ____\|\   __  \|\   _ \  _   \|\  ___ \     
 \ \  \/  / | \  \|\  \ \  \\\  \       \ \  \    \ \  \ \  \|\  \ \  \\ \  \       \|___ \  \_\ \  \\\  \ \   __/|        \ \  \___|\ \  \|\  \ \  \\\__\ \  \ \   __/|    
  \ \    / / \ \  \\\  \ \  \\\  \       \ \  \  __\ \  \ \  \\\  \ \  \\ \  \           \ \  \ \ \   __  \ \  \_|/__       \ \  \  __\ \   __  \ \  \\|__| \  \ \  \_|/__  
   \/  /  /   \ \  \\\  \ \  \\\  \       \ \  \|\__\_\  \ \  \\\  \ \  \\ \  \           \ \  \ \ \  \ \  \ \  \_|\ \       \ \  \|\  \ \  \ \  \ \  \    \ \  \ \  \_|\ \ 
 __/  / /      \ \_______\ \_______\       \ \____________\ \_______\ \__\\ \__\           \ \__\ \ \__\ \__\ \_______\       \ \_______\ \__\ \__\ \__\    \ \__\ \_______\
|\___/ /        \|_______|\|_______|        \|____________|\|_______|\|__| \|__|            \|__|  \|__|\|__|\|_______|        \|_______|\|__|\|__|\|__|     \|__|\|_______|
\|___|/                                                                                                                                                                     ");
            Console.WriteLine("\n\n\t\tPress any key to continue...");
            Console.ReadKey(true);
            Console.ResetColor();
        }
        private void GameLostInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("\n\n\t\tYou lost the game.");
            Console.WriteLine("\n\t\tPress any key to continue...");
            Console.ReadKey(true);
            Console.ResetColor();
        }
        private void PlayerInput()
        {
            // Get last key input
            // Gör så att inte knapptrycken buffrar upp, heron stannar när man släpper knappen
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            } while (System.Console.KeyAvailable);

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (IsWalkable(currentHero.Col, currentHero.Row - 1))
                    {
                        currentHero.Row -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (IsWalkable(currentHero.Col, currentHero.Row + 1))
                    {
                        currentHero.Row += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (IsWalkable(currentHero.Col - 1, currentHero.Row))
                    {
                        currentHero.Col -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (IsWalkable(currentHero.Col + 1, currentHero.Row))
                    {
                        currentHero.Col += 1;
                    }
                    break;
                case ConsoleKey.A:
                    Action();
                    break;
                default:
                    break;
            }
        }
        private void Action()
        {
            ColAndRow(45, 63, 40, 45, 0);
            ColAndRow(18, 36, 35, 40, 1);
            ColAndRow(9, 27, 30, 35, 2);
            ColAndRow(54, 72, 30, 35, 3);
            ColAndRow(63, 90, 25, 30, 4);
            ColAndRow(27, 54, 20, 25, 5);
            ColAndRow(54, 72, 15, 20, 6);
            ColAndRow(45, 62, 10, 15, 7);
            ColAndRow(36, 53, 5, 10, 8);
            ColAndRow(72, 89, 0, 5, 9);
        }
        private void ColAndRow(int colStart, int colFinish, int rowStart, int rowFinish, int roomIndex)
        {
            if (currentHero.Col > colStart && currentHero.Col < colFinish && currentHero.Row > rowStart && currentHero.Row < rowFinish)
            {
                AttackOrRun(roomIndex);
            }
        }
        public void AttackOrRun(int roomIndex)
        {
            Random rand = new Random();
            bool actionMenuActive = true;
            while (actionMenuActive)
            {
                Console.SetCursorPosition(95, currentHero.Row);
                Console.Write(" Do you want to attack or run? ");
                string answer = Console.ReadLine();
                string answerInLowerCase = answer.ToLower();
                switch (answerInLowerCase)
                {
                    case "attack":
                        Console.Beep(125, 225);
                        Console.SetCursorPosition(95, currentHero.Row + 1);
                        Console.WriteLine("\t\tDieeeee motherfuckeeeeeeer");
                        System.Threading.Thread.Sleep(3000);
                        int riskToLoseHealth = rand.Next(1, 6);
                        if (riskToLoseHealth == 5)
                        {
                            currentHero.Health -= 10;
                            Console.SetCursorPosition(95, currentHero.Row + 2);
                            Console.WriteLine("\t\tDamage taken.. -10 Health");
                            System.Threading.Thread.Sleep(2000);
                        }
                        int enemyDropHealth = rand.Next(1, 11);
                        if (enemyDropHealth == 10)
                        {
                            currentHero.Health += 10;
                            Console.SetCursorPosition(95, currentHero.Row + 3);
                            Console.WriteLine("\t\tLifesteal! +10 Health");
                            System.Threading.Thread.Sleep(2000);
                            if (currentHero.Health > 100)
                            {
                                currentHero.Health = 100;
                            }
                        }
                        CheckIfEnemyDead(roomIndex);
                        actionMenuActive = false;
                        break;
                    case "run":
                        Console.Beep();
                        Console.WriteLine("\t\tDude I'm so fucking scared.. lets run");
                        System.Threading.Thread.Sleep(3000);
                        actionMenuActive = false;
                        break;
                    default:
                        Console.WriteLine("\t\tAttack or run.. There is no other option");
                        break;
                }
            }
        }
        private void CheckIfEnemyDead(int rowIndex)
        {
            for (int i = 0; i < enemy.AliveOrDead[rowIndex].Length; i++)
            {
                if (enemy.AliveOrDead[rowIndex][i] == true)
                {
                    enemy.AliveOrDead[rowIndex][i] = false;
                    break;
                }
            }
        }
    }
}