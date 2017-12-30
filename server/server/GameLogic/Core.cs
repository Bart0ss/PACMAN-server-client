using static Customly_Edited_Pacman.Map;

namespace Customly_Edited_Pacman
{
    class Core
    {
        public static Player player = new Player(0, 0);
        public static Player player2 = new Player(0, 0);
        public static int max_points_on_current_maze;
        public static int height=10;
        public static int width=10;
        public static int initial_x = height / 2;
        public static int initial_y = width / 2;
        public static bool gameIsOver = false;

        public static void ResetGame()
        {
            map = createMaze(map);
            player.setCoords(initial_x, initial_y);
            player2.setCoords(initial_x, initial_y);
            map[initial_x, initial_y] = " ";
            max_points_on_current_maze = Map.amount_of_points_on_map(map);
        }

        public static void InitializeGame()
        {
            map = create_2D_array(height, width);
            map = createBorder(map);
            map = createMaze(map);
            player.setCoords(initial_x, initial_y);
            player2.setCoords(initial_x, initial_y);
            map[initial_x, initial_y] = " ";
            max_points_on_current_maze = Map.amount_of_points_on_map(map);
        }
    }
}

