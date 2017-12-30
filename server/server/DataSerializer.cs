using System.Collections.Generic;
using System;

namespace Customly_Edited_Pacman
{
    class DataSerializer
    {
        public static Dictionary<string,int> MapConverterDictionary = new Dictionary<string, int>();

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

        public static string Convert_Game_Data_to_string()
        {
            string temp = "";
            temp += Map.map.GetLength(0) + ",";
            temp += Map.map.GetLength(1) + ",";

            foreach (var c in Map.map)
            {
                try
                {
                    temp += MapConverterDictionary[c];
                }
                catch
                {
                    Console.WriteLine(c);
                }
                temp += ",";
                }
            
            return temp;
        }
    }
}
