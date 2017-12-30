using System;
using System.Collections.Generic;
using System.Linq;
namespace Customly_Edited_Pacman
{
    class Map
    {
        public static string[,] map;
        public static Int32 amount_of_points_on_map(string[,] arr)
        {
            int height = arr.GetLength(0);
            int width = arr.GetLength(1);
            int count = 0;
            for (int i=0; i<height; i++)
            {
                for (int j=0; j<width; j++)
                {
                    if (arr[i,j] == Game.sign_point)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static string[,] create_2D_array(int height, int width)
        {
            string[,] arr = new string[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr[i, j] = Game.sign_point;
                }
            }
            return arr;
        }

        public static bool blockAintBlocked(int x, int y)
        {
            List<int> x_coords = new List<int>(8);
            List<int> y_coords = new List<int>(8);
            #region hardcoding
            x_coords.Add(-1);
            y_coords.Add(0);

            x_coords.Add(-1);
            y_coords.Add(1);

            x_coords.Add(0);
            y_coords.Add(1);

            x_coords.Add(1);
            y_coords.Add(1);

            x_coords.Add(1);
            y_coords.Add(0);

            x_coords.Add(1);
            y_coords.Add(-1);

            x_coords.Add(0);
            y_coords.Add(-1);

            x_coords.Add(-1);
            y_coords.Add(-1);
            #endregion
            int height = map.GetLength(0);
            int width = map.GetLength(1);

            int amountOfOccurrences = 0;
            for (int i = 0; i < x_coords.Count; i++)
            {
                try
                {
                    if (x + x_coords[i] > 0 && x + x_coords[i] < height && y + y_coords[i] >0 && y + y_coords[i] < width)
                    {
                        if (map[x + x_coords[i], y + y_coords[i]] == Game.sign_point)
                        {
                            amountOfOccurrences++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("_______________");
                    Console.WriteLine($"Ex: {ex.Message}");
                    Console.WriteLine(i);
                    Console.WriteLine(x_coords[i]);
                    Console.WriteLine(y_coords[i]);
                    Console.WriteLine("_______________");
                }
            }
            return amountOfOccurrences >= 2;
        }
        public static string[,] createMaze(string[,] arr)
        {
            Random rnd = new Random();
            int height = arr.GetLength(0);
            int width = arr.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i != 0 && i != height - 1 && j != 0 && j != width - 1)
                    {
                        if (blockAintBlocked(i, j))
                        {
                            int temp = rnd.Next(3);
                            if (temp == 2)
                            {
                                arr[i, j] = Game.sign_blocked_way;
                            }
                            else
                            {
                                arr[i, j] = Game.sign_point;
                            }
                        }
                        else
                        {
                            arr[i, j] = Game.sign_point;
                        }
                    }
                }
            }
            return arr;
        }

        public static void showMap(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (Game.unable_to_walk_thru_signs.Contains(arr[i, j]) && arr[i,j] != Game.sign_player)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(arr[i, j] + " ");
                    }
                    else if (arr[i,j]==Game.sign_player)
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
        public static string[,] createBorder(string[,] arr)
        {
            int height = arr.GetLength(0);
            int width = arr.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            arr[i, j] = Game.sign_wall_corner_top_left;
                        }
                        else if (j == width - 1)
                        {
                            arr[i, j] = Game.sign_wall_corner_top_right;
                        }
                        else
                        {
                            arr[i, j] = Game.sign_wall_top_n_bottom;
                        }
                    }
                    else if (i == height - 1)
                    {
                        if (j == 0)
                        {
                            arr[i, j] = Game.sign_wall_corner_bottom_left;
                        }
                        else if (j == width - 1)
                        {
                            arr[i, j] = Game.sign_wall_corner_bottom_right;
                        }
                        else
                        {
                            arr[i, j] = Game.sign_wall_top_n_bottom;
                        }
                    }
                    else
                    {
                        if (j == 0 || j == width - 1)
                        {
                            arr[i, j] = Game.sign_wall_left_n_right;
                        }
                    }
                }
            }
            return arr;
        }
    }
}
