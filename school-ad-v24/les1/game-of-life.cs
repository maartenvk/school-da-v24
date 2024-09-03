using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_ad_v24.les1
{
    internal class Game_of_life(int width, int height)
    {
        bool[,] board = new bool[height, width];
        bool[,] buffer = new bool[height, width];
        protected readonly int width = width;
        protected readonly int height = height;

        public delegate bool Rule(bool alive, int neighborCount);
        protected Rule applyRule = defaultRule;

        public static readonly Rule defaultRule = (bool on, int nc) =>
        {
            if (on && (nc < 2 || nc > 3))
            {
                return false;
            }
            else if (!on && nc == 3)
            {
                return true;
            }

            return on;
        };

        public void SetRule(Rule rule)
        {
            applyRule = rule;
        }

        public void Step()
        {
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    bool on = board[row, col];
                    int nc = NeighborCount(row, col);
                    buffer[row, col] = applyRule(on, nc);
                }
            }

            (buffer, board) = (board, buffer);
        }

        protected bool IsValidCoordinate(int row, int col)
        {
            return row >= 0 && col >= 0 && row < height && col < width;
        }

        protected int NeighborCount(int row, int col)
        {
            int[] row_positions = [-1, -1, -1, 0, 1, 1, 1, 0];
            int[] col_positions = [-1, 0, 1, 1, 1, 0, -1, -1];

            int neighborCount = 0;
            foreach ((int rowp, int colp) in row_positions.Zip(col_positions))
            {
                int newRow = row + rowp;
                int newCol = col + colp;

                if (IsValidCoordinate(newRow, newCol) && board[newRow, newCol])
                {
                    neighborCount++;
                }
            }
            return neighborCount;
        }

        public void PrintState()
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    bool on = board[row, col];
                    Console.Write(on ? '█' : ' ');
                }

                Console.WriteLine();
            }
        }

        public void PutGlider(int offset = 2)
        {
            int[] rows = [0, 1, 1, 2, 2];
            int[] cols = [2, 0, 2, 1, 2];

            foreach ((int row, int col) in rows.Zip(cols))
            {
                board[offset + row, offset + col] = true;
            }
        }

        public void Play()
        {
            while (true)
            {
                PrintState();
                Step();
                Thread.Sleep(41);
            }
        }
    }
}
