using System;

namespace GIK299_projekt_grupp4
{
    class Game
    {
        public World theWorld;
        public Hero currentHero;
        public Enemy enemy;
        public void Menu()
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine("Start new game by typing (start) or exit by typing (exit)");
                switch (Console.ReadLine().ToLower())
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
            theWorld = new World();
            currentHero = new Hero(1, 39);
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
                string stringAtPlayerPos = theWorld.GetStringAt(currentHero.Col, currentHero.Row);
                if (stringAtPlayerPos == "F" && currentHero.NumberOfKeys == 10)
                {
                    GameFinishInfo();
                    break;
                }
                else if (stringAtPlayerPos == "K")
                {
                    Console.WriteLine("\tYou found one of the keys!");
                    System.Threading.Thread.Sleep(1500);
                    currentHero.NumberOfKeys += 1;
                    World.ChangeStringToEmpty(currentHero.Col, currentHero.Row);
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
            World.ChangeStringToHero(currentHero.Col, currentHero.Row);
            enemy.DrawEnemies();
            theWorld.DrawWorld();
            Console.WriteLine("\nYour hero: {0}", currentHero.GetName());
            if (currentHero.NumberOfKeys < 10)
            {
                Console.WriteLine("Amount of keys: {0}", currentHero.NumberOfKeys);
            }
            else
            {
                Console.WriteLine("You have collected all the keys, now find the exit 'F'");
            }
            Console.WriteLine("Health: {0}", currentHero.Health);

            string stringAtPlayerPos = theWorld.GetStringAt(currentHero.Col, currentHero.Row);
            if (stringAtPlayerPos == "F" && currentHero.NumberOfKeys < 10)
            {
                Console.WriteLine("\n\tYou don't have all the keys! Come back when you've collected them all");
            }
        }
        private void GameStartInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
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
            Console.WriteLine("\t\t>The main goal is to find and grab all 10 keys 'K' and then find the exit 'F'");
            Console.WriteLine("\t\t>To reach the finishline, you must go through all 10 rooms filled with enemies 'E'");
            Console.WriteLine("\t\t>The keys are placed randomly around the map.");
            Console.Write("\t\t>This is your hero: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.ResetColor();
            Hero.SetHeroName();
            Console.WriteLine("\n\t\t>Press any key to start...");
            Console.ReadKey(true);
        }
        private void GameFinishInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
  ________  ________  ________   ________  ________  ________  _________  ________      
 |\   ____\|\   __  \|\   ___  \|\   ____\|\   __  \|\   __  \|\___   ___\\   ____\     
 \ \  \___|\ \  \|\  \ \  \\ \  \ \  \___|\ \  \|\  \ \  \|\  \|___ \  \_\ \  \___|_    
  \ \  \    \ \  \\\  \ \  \\ \  \ \  \  __\ \   _  _\ \   __  \   \ \  \ \ \_____  \   
   \ \  \____\ \  \\\  \ \  \\ \  \ \  \|\  \ \  \\  \\ \  \ \  \   \ \  \ \|____|\  \  
    \ \_______\ \_______\ \__\\ \__\ \_______\ \__\\ _\\ \__\ \__\   \ \__\  ____\_\  \ 
     \|_______|\|_______|\|__| \|__|\|_______|\|__|\|__|\|__|\|__|    \|__| |\_________\
                                                                            \|_________|
        ___    ___ ________  ___  ___          ___       __   ________  ________      
       |\  \  /  /|\   __  \|\  \|\  \        |\  \     |\  \|\   __  \|\   ___  \    
       \ \  \/  / | \  \|\  \ \  \\\  \       \ \  \    \ \  \ \  \|\  \ \  \\ \  \   
        \ \    / / \ \  \\\  \ \  \\\  \       \ \  \  __\ \  \ \  \\\  \ \  \\ \  \  
         \/  /  /   \ \  \\\  \ \  \\\  \       \ \  \|\__\_\  \ \  \\\  \ \  \\ \  \ 
       __/  / /      \ \_______\ \_______\       \ \____________\ \_______\ \__\\ \__\
      |\___/ /        \|_______|\|_______|        \|____________|\|_______|\|__| \|__|
      \|___|/                                                                         ");
            Console.WriteLine("\n\n\t\tPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        private void GameLostInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t\tYou lost the game.");
            Console.WriteLine("\n\t\tPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        private void PlayerInput()
        {
            ConsoleKey key;
            // Gör så att inte knapptrycken buffrar upp, heron stannar när man släpper knappen
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            } while (Console.KeyAvailable);

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    WalkUpOrDown(-1);
                    break;
                case ConsoleKey.DownArrow:
                    WalkUpOrDown(1);
                    break;
                case ConsoleKey.LeftArrow:
                    WalkLeftOrRight(-1);
                    break;
                case ConsoleKey.RightArrow:
                    WalkLeftOrRight(1);
                    break;
                default:
                    break;
            }
        }
        private void WalkUpOrDown(int direction)
        {
            if (theWorld.IsWalkable(currentHero.Col, currentHero.Row + direction))
            {
                World.ChangeStringToEmpty(currentHero.Col, currentHero.Row);
                currentHero.Row += direction;
            }
            Action();
        }
        private void WalkLeftOrRight(int direction)
        {
            if (theWorld.IsWalkable(currentHero.Col + direction, currentHero.Row))
            {
                World.ChangeStringToEmpty(currentHero.Col, currentHero.Row);
                currentHero.Col += direction;
            }
            Action();
        }
        private void Action()
        {
            for (int i = 0; i < 10; i++)
            {
                CheckIfInsideRoom(enemy.RoomCol[i, 0], enemy.RoomCol[i, 1], enemy.RoomRow[i, 0], enemy.RoomRow[i, 1], i);
            }
        }
        private void CheckIfInsideRoom(int colStart, int colFinish, int rowStart, int rowFinish, int roomIndex)
        {
            if (currentHero.Col >= colStart && currentHero.Col <= colFinish && currentHero.Row >= rowStart && currentHero.Row <= rowFinish && enemy.AliveOrDead[roomIndex] == true)
            {
                AttackOrRun(roomIndex);
            }
        }
        public void AttackOrRun(int roomIndex)
        {
            if (enemy.AliveOrDead[roomIndex] == true)
            {
                bool actionMenuActive = true;
                while (actionMenuActive)
                {
                    Console.Write("Do you want to attack or run? ");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "attack":
                            Attack(roomIndex);
                            CheckIfEnemyDead(roomIndex);
                            actionMenuActive = false;
                            break;
                        case "run":
                            Console.Write("\tDude I'm so fucking scared.. lets run");
                            System.Threading.Thread.Sleep(2000);
                            currentHero.Row += 4;
                            actionMenuActive = false;
                            break;
                        default:
                            Console.Write("\tAttack or run.. There is no other option ");
                            break;
                    }
                }
            }
        }
        private void Attack(int roomIndex)
        {
            Console.Write("Diee motherfuckeeer");
            System.Threading.Thread.Sleep(1500);
            Random rand = new Random();
            for (int i = 0; i < enemy.ColPosition[roomIndex].Length; i++)
            {
                int riskToLoseHealth = rand.Next(1, 6);
                if (riskToLoseHealth == 5)
                {
                    currentHero.Health -= 10;
                    Console.Write(", Damage taken.. -10 Health");
                    System.Threading.Thread.Sleep(1500);
                }
                int enemyDropHealth = rand.Next(1, 11);
                if (enemyDropHealth == 10)
                {
                    currentHero.Health += 10;
                    Console.Write(", Lifesteal! +10 Health");
                    System.Threading.Thread.Sleep(1500);
                    if (currentHero.Health > 100)
                    {
                        currentHero.Health = 100;
                    }
                }
            }
        }
        private void CheckIfEnemyDead(int rowIndex)
        {
            if (enemy.AliveOrDead[rowIndex] == true)
            {
                for (int j = 0; j < enemy.ColPosition[rowIndex].Length; j++)
                {
                    enemy.AliveOrDead[rowIndex] = false;
                    World.ChangeStringToEmpty(enemy.ColPosition[rowIndex][j], enemy.RowPosition[rowIndex][j]);
                }
            }
        }
    }
}