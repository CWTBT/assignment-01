using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTLog
{
    class TTT
    {
        public int[,] grid;
        public int turn;
        public bool playing;
        public int winner;
        public int playnum;

        public TTT()
        {
            turn = 0;
            grid = new int[3,3];
            playing = true;
            winner = -1;
            for (int i=0;i<grid.GetLength(0);i++)
            {
                for (int j=0;j<grid.GetLength(1);j++)
                {
                    grid[i, j] = -1;
                }
            }
        }

        public void Place(int h, int w)
        {
            if (w < 0 || w > 2 || h < 0 || h > 2) return;

            if (playing == false || playnum == 9)
            {
                playing = true;
                winner = -1;
                playnum = 0;
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        grid[i, j] = -1;
                    }
                }
            }

            if (grid[h, w] == -1)
            {

                grid[h, w] = turn;
                turn = 1 - turn;
                playnum += 1;
            }



            WinCheck(h, w);
        }

        public void WinCheck(int h, int w)
        {
            if (grid[h,0] == grid[h,1] && grid[h,1] == grid[h,2]) //checks row
            {
                playing = false;
                winner = grid[h, 0];
            }

            if (grid[0, w] == grid[1, w] && grid[1, w] == grid[2, w]) //checks column
            {
                playing = false;
                winner = grid[0, w];

            }

            if (w == h || Math.Abs(w-h) == 2) //All spots that could count for a diagonal win have coordinates of (n,n), (0,2), or (2,0)
            {
                if (grid[0,0] == grid[1,1] && grid[1,1] == grid[2,2] && grid[0,0] != -1)
                {
                    playing = false;
                    winner = grid[0, 0];
                    
                }

                if (grid [2,0] == grid [1,1] && grid[1,1] == grid[0,2] && grid[2,0] != -1)
                {
                    playing = false;
                    winner = grid[2, 0];
                    
                }
            }
        }

        public override string ToString()
        {
            string output = "";
            int h = grid.GetLength(0);
            int w = grid.GetLength(1);
            for (int i=0;i<h;i++)
            {
                for (int j=0;j<w;j++)
                {
                    output += grid[i,j]+" ";

                }
                output += "\n";
            }
            return output;
        }
    }

}
