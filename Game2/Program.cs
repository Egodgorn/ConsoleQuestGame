using System;
using System.Drawing;


namespace Game2
{
    class Program
    {
        static MapLoader _maploader = new MapLoader();
        static string[,] map = _maploader.LoadMap(@"Map\Level_1.txt");
        
        
        //info player
        public static int Health = 100;
        public static int Food = 100;
        public static int HealthPotion = 0;
        public static int FoodRation = 0;
        //

        static void UpInfo(){
            Console.SetCursorPosition(40,0);
            Console.WriteLine(Health+ "Health");
            Console.SetCursorPosition(40, 1);
            Console.WriteLine(Food+ "Food");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine(HealthPotion+ "HealthPotion");
            Console.SetCursorPosition(40, 3);
            Console.WriteLine(FoodRation+"FoodRation");
            Console.SetCursorPosition(40, 4);
            Console.WriteLine(Console.WindowHeight);
            Console.SetCursorPosition(40, 5);
            Console.WriteLine(Console.WindowWidth);

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

        static  (int, int) FindHero() {
            int rows = map.GetUpperBound(0) + 1;    //перебирает массив и ищет символ H
            int columns = map.Length / rows;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++)
                    if (map[i, j] == "H")
                        return (i, j);
            }
            throw new ArgumentException("ГГ не нашелся");
        }

        

        static void Swap(ref string a, ref string b) => (a, b) = (b, a);//меняет местами значение

        static void Main(string[] args)
        {

            Draw();

            UpInfo();

            do
            {
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow: MoveDir(0,-1); break;
                    case ConsoleKey.RightArrow: MoveDir(0,1); break;
                    case ConsoleKey.UpArrow: MoveDir(-1,0); break;
                    case ConsoleKey.DownArrow: MoveDir(1,0); break;
                }
                
                Console.SetCursorPosition(0, 0);
                
                Draw();
                UpInfo();

            } while(true);
            
        }
        private static void MoveDir(int x,int y)
        {
            var (r, c) = FindHero();
            switch (map[r + x, c + y])
            {
                case " ":
                    Swap(ref map[r, c], ref map[r + x, c + y]);
                    break;
                case "F":
                    FoodRation++; Swap(ref map[r, c], ref map[r + x, c + y]);
                    map[r - x, c - y] = " ";
                    break;
            }
        }
    }

}
