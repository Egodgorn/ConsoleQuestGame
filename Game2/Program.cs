using System;
using System.Drawing;


namespace Game2
{
    class Program
    {
        static MapLoader _maploader = new MapLoader();
        static string[,] map = _maploader.LoadMap(@"C:\Users\Ego\source\repos\Quest Game\Game2\Map\Level_1.txt");

        //info player
        public static int Health = 100;
        public static int Food = 100;
        public static int FoodRation = 0;
        //

        static void UpInfo(){
            Console.SetCursorPosition(40,0);
            Console.WriteLine(Health+ "Health");
            Console.SetCursorPosition(40, 1);
            Console.WriteLine(Food+ "Food");
        }

        static void Draw(){
            
            int rows = map.GetUpperBound(0) + 1;
            int columns = map.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{map[i,j]}");

                }
                Console.WriteLine();
            }
            
        }

        static void Main(string[] args)
        {
            InitItems init = new InitItems();//инициализация предметов инвентаря
            Movement Move = new Movement();//инициализация системы движения
            Inventory inventory = new Inventory();//инициализация инвенторя
            

            Draw();
            UpInfo();
            inventory.DrawInventory();
            do
            {
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow: Move.MoveDir(0,-1,ref map,ref inventory); break;
                    case ConsoleKey.RightArrow: Move.MoveDir(0,1, ref map, ref inventory); break;
                    case ConsoleKey.UpArrow: Move.MoveDir(-1,0, ref map, ref inventory); break;
                    case ConsoleKey.DownArrow: Move.MoveDir(1,0, ref map, ref inventory); break;
                    case ConsoleKey.Z: if (inventory.FindAndDestroyItem('H') == true) { Health += init.HealthPotion.Buff(); } break;


                }
                
                Console.SetCursorPosition(0, 0);
                
                Draw();
                UpInfo();
                inventory.DrawInventory();

            } while(true);
            
        }
    }

}
