using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Inventory
    {
        public static char[,] InventoryStorage = 
            { 
            {'H',' ',' ',' '},
            {' ',' ',' ',' '},
            {' ',' ',' ',' '},
            {' ',' ',' ',' '}
            };//пустые ячейки заполнять пробелом размер 4x4 

        public static int rows = InventoryStorage.GetUpperBound(0) + 1;
        public static int columns = InventoryStorage.Length / rows;

        public bool FindItem(char _item)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (_item == InventoryStorage[i,j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool FindAndDestroyItem(char _item)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (_item == InventoryStorage[i, j])
                    {
                        InventoryStorage[i, j] = ' ';
                        return true;
                    }
                }
            }

            return false;
        }
        public void AddItem(char _item)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (InventoryStorage[i, j] == ' ')
                    {
                        InventoryStorage[i, j] = _item;
                        Console.SetCursorPosition(20, 0);
                        Console.WriteLine($"Item Added {_item}");
                        return;
                    }
                }
            }
        }
        public void DrawInventory()
        {
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("╔════╗");
            for (int i = 0; i < InventoryStorage.GetUpperBound(0) + 1;i++)
            {
                Console.SetCursorPosition(40, 6 + i);
                Console.WriteLine("║" + InventoryStorage[i,0] + InventoryStorage[i, 1] + InventoryStorage[i, 2] + InventoryStorage[i, 3] + "║");
                
            }
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("╚════╝");
        }
    }
}
