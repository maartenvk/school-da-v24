using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_ad_v24.les1
{
    internal class Aoc_game_of_life(int width, int height)
    {
        public enum State
        {
            Floor,
            EmptyChair,
            OccupiedChair
        };

        protected State[,] board = new State[height, width];
        protected State[,] buffer = new State[height, width];

        protected readonly int width = width;
        protected readonly int height = height;

        public delegate State Rule(State state, int neighborCount);
        protected Rule applyRule = defaultRule;

        protected bool lastTickWasEqual = false;

        public static readonly Rule defaultRule = (State state, int nc) =>
        {
            if (state == State.Floor)
            {
                return state;
            }

            if (state == State.EmptyChair && nc == 0)
            {
                return State.OccupiedChair;
            }

            if (state == State.OccupiedChair && nc >= 4)
            {
                return State.EmptyChair;
            }

            return state;
        };

        public void SetRule(Rule rule)
        {
            applyRule = rule;
        }

        public void Step()
        {
            lastTickWasEqual = true;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    State state = board[row, col];
                    int nc = NeighborCount(row, col);
                    State newState = applyRule(state, nc);
                    buffer[row, col] = newState;

                    if (state != newState)
                    {
                        lastTickWasEqual = false;
                    }
                }
            }

            (buffer, board) = (board, buffer); // double-buffering
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

                if (!IsValidCoordinate(newRow, newCol))
                {
                    continue;
                }

                State state = board[newRow, newCol];
                if (state != State.OccupiedChair)
                {
                    continue;
                }

                neighborCount++;
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
                    State state = board[row, col];
                    char displayed = state switch
                    {
                        State.Floor => '.',
                        State.EmptyChair => 'L',
                        State.OccupiedChair => '#',
                        _ => throw new NotImplementedException()
                    };

                    Console.Write(displayed);
                }

                Console.WriteLine();
            }
        }

        public void PutRandom()
        {
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    board[row, col] = Random.Shared.Next(2) == 0 ? State.Floor : State.OccupiedChair; 
                }
            }
        }

        public static Aoc_game_of_life CreateFromString(string s)
        {
            int width = -1;
            int height = 0;

            while (s[++width] != '\n');

            height = s.Length / width;
            width -= 1; // remove newline

            Aoc_game_of_life obj = new(width, height);
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    char c = s[row * (width + 2) + col]; // this might be (width + 1) on Unix based platforms
                    State state = c switch
                    {
                        '.' => State.Floor,
                        'L' => State.OccupiedChair,
                        _ => throw new NotImplementedException()
                    };

                    obj.board[row, col] = state;
                }
            }

            return obj;
        }

        public void Play(bool benchmark = false)
        {
            int i = 0;
            while (true)
            {
                if (!benchmark)
                {
                    PrintState();
                }

                Step();

                if (!benchmark)
                {
                    Thread.Sleep(200); // 5 FPS
                }

                i++;
                if (lastTickWasEqual)
                {
                    int occupiedCount = 0;
                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            if (board[row, col] == State.OccupiedChair)
                            {
                                occupiedCount++;
                            }
                        }
                    }

                    if (!benchmark)
                    {
                        Console.WriteLine($"{occupiedCount} chairs are occupied.");
                    }

                    break;
                }
            }
        }
    }
}
