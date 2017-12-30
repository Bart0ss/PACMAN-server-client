using System;
namespace Customly_Edited_Pacman
{
    class Player
    {
        private int _score;
        private int _coord_x;
        private int _coord_y;

        private Player()
        {
                
        }

        public Player(int x, int y)
        {
            _coord_x = x;

            _coord_y = y;
        }

        public int getScore()
        {
            return _score;
        }

        public void increaseScore()
        {
            _score++;
        }

        public void setScore(int x)
        {
            if (x>= 0)
            {
                _score = x;
            }
        }

        public int getCoorsX()
        {
            return _coord_x;
        }

        public int getCoorsY()
        {
            return _coord_y;
        }

        public void setCoords(int x, int y)
        {
            if (x >= 0 && y>=0)
            {
                _coord_x = x;
                _coord_y = y;
                
            }
            else
            {
                throw new ArgumentOutOfRangeException("coords should be >= 0");
            }
        }
    }
}
