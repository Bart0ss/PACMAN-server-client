using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class TCPIP_data_manipulation
    {

        public static Dictionary<string, int> MapConverterDictionary = new Dictionary<string, int>();

        public static void FillDictionary()
        {
            MapConverterDictionary.Add(Game.sign_player, 0);
            MapConverterDictionary.Add(Game.sign_point, 1);
            MapConverterDictionary.Add(Game.sign_wall_top_n_bottom, 2);
            MapConverterDictionary.Add(Game.sign_wall_left_n_right, 3);
            MapConverterDictionary.Add(Game.sign_wall_corner_top_left, 4);
            MapConverterDictionary.Add(Game.sign_wall_corner_top_right, 5);
            MapConverterDictionary.Add(Game.sign_wall_corner_bottom_left, 6);
            MapConverterDictionary.Add(Game.sign_wall_corner_bottom_right, 7);
            MapConverterDictionary.Add(Game.sign_blocked_way, 8);
            MapConverterDictionary.Add(Game.empty_place, 9);
        }

        public static T[,] Make2DArray<T>(T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }
        public static void ConvertByte_TCPIP_Stream_to_GameData_and_apply_it(byte[] bb)
        {
            string[] arr = Encoding.UTF8.GetString(bb).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int height = Convert.ToInt32(arr[0]);
            int width = Convert.ToInt32(arr[0]);
            arr = arr.Where((item, index) => index != 0 && index != 1 && index != arr.Length-1).ToArray();

            Map.map = Make2DArray(arr, height, width);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Map.map[i, j] = MapConverterDictionary.FirstOrDefault(x => x.Value.ToString() == Map.map[i,j]).Key;
                }
            }
        }

        public static string KeyToString(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return "w";

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return "s";

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return "a";

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return "d";

                case ConsoleKey.Home:
                case ConsoleKey.Q:
                    return "q";

                case ConsoleKey.PageUp:
                case ConsoleKey.E:
                    return "e";

                case ConsoleKey.End:
                case ConsoleKey.Z:
                    return "z";

                case ConsoleKey.PageDown:
                case ConsoleKey.C:
                    return "c";
                case ConsoleKey.Escape:
                    return "escape";
                default:
                    return key.ToString();
            }
        }
    }
}
