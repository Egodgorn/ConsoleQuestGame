using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Movement
    {
        static void Swap(ref string a, ref string b) => (a, b) = (b, a);//меняет местами значение

        public void MoveDir(int x, int y, ref string[,] map, ref Inventory _inventory)
        {
            var (r, c) = FindHero(map);
            switch (map[r + x, c + y])
            {
                case " ":
                    Swap(ref map[r, c], ref map[r + x, c + y]);
                    break;
                case "H":
                    Swap(ref map[r, c], ref map[r + x, c + y]);
                    _inventory.AddItem('H');
                    break;
            }
        }
        public (int, int) FindHero(string[,] map)
        {
            int rows = map.GetUpperBound(0) + 1;    //перебирает массив и ищет символ H
            int columns = map.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    if (map[i, j] == "P")
                        return (i, j);
            }
            throw new ArgumentException("ГГ не нашелся");
        }
    }
}
