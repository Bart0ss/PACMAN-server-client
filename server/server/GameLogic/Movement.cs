using System;
using static Customly_Edited_Pacman.Core;
using static Customly_Edited_Pacman.Game;
using System.Linq;

namespace Customly_Edited_Pacman
{
    class Movement
    {
        public static Player WhoUsedKey(ConsoleKey key)
        {
            if (Game.player1Keys.Contains(key))
            {
                return Core.player;
            }
            else if (Game.player2Keys.Contains(key))
            {
                return Core.player2;
            }
              return Core.player;
        }

        public static Direction DetermineDirection(string key)
        {
            switch (key.ToLower())
            {
                case "uparrow":
                case "w":
                    return Direction.North;

                case "downarrow":
                case "s":
                    return Direction.South;

                case "leftarrow":
                case "a":
                    return Direction.West;

                case "rightarrow":
                case "d":
                    return Direction.East;

                case "home":
                case "q":
                    return Direction.NorthWest;

                case "pageup":
                case "e":
                    return Direction.NorthEast;

                case "end":
                case "z":
                    return Direction.SouthWest;

                case "pagedown":
                case "c":
                    return Direction.SouthEast;

                default:
                    return Direction.None;
            }
        }
        public static bool PlayerMovement(Player thisPlayer, Direction direction)
        {
            int new_x = 0;
            int new_y = 0;
            int currentX = thisPlayer.getCoorsX();
            int currentY = thisPlayer.getCoorsY();
            switch (direction)
            {
                case Direction.North:
                    new_x = currentX -1;
                    new_y = currentY;
                    break;
                case Direction.South:
                    new_x = currentX + 1;
                    new_y = currentY;
                    break;
                case Direction.East:
                    new_x = currentX;
                    new_y = currentY + 1;
                    break;
                case Direction.West:
                    new_x = currentX;
                    new_y = currentY - 1;
                    break;
                case Direction.NorthWest:
                    new_x = currentX - 1;
                    new_y = currentY - 1;
                    break;
                case Direction.NorthEast:
                    new_x = currentX -1;
                    new_y = currentY +1;
                    break;
                case Direction.SouthWest:
                    new_x = currentX +1;
                    new_y = currentY - 1;
                    break;
                case Direction.SouthEast:
                    new_x = currentX +1;
                    new_y = currentY + 1;
                    break;
                default:
                    bool contains = false;
                    foreach (var c in warnings)
                    {
                        if (c.Contains($@"Use < ^ > \/ arrows"))
                        {
                            contains = true;
                        }
                    }
                    if (!contains)
                    {
                        warnings.Add(@"Use < ^ > \/ arrows");
                    }
                    break;
            }
            if (Map.map[new_x, new_y]==sign_point)
            {
                max_points_on_current_maze--;
                Console.WriteLine(max_points_on_current_maze);
                thisPlayer.increaseScore();
                if (max_points_on_current_maze==0)
                {
                    Core.gameIsOver = true;
                }
            }
            if (!unable_to_walk_thru_signs.Contains(Map.map[new_x, new_y]))
            {
                Map.map[currentX, currentY] = Game.empty_place;
                Map.map[new_x, new_y] = Game.sign_player;
                thisPlayer.setCoords(new_x, new_y);
            }
            return true;
        }
    }
}
