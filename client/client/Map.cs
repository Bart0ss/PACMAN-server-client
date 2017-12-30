using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Map
    {
        public static string[,] map = new string[1,1];
        public static void showMap(string[,] arr)
        {
            Console.Clear();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (Game.unable_to_walk_thru_signs.Contains(arr[i, j]) && arr[i, j] != Game.sign_player)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(arr[i, j] + " ");
                    }
                    else if (arr[i, j] == Game.sign_player)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(arr[i, j] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(arr[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
