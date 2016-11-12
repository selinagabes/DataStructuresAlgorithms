using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountBattleShip
{
    class Program
    {

        static void Main(string[] args)
        {

            char[,] bS = {
                           { 'x', '.', '.', 'x' },
                           { '.', '.', '.', 'x' },
                           { '.', '.', '.', 'x' }
                        };

            Solution solution = new Solution();
            int count = solution.CountBattleships(bS);
            Console.WriteLine(count);
            Console.ReadLine();
        }


    }
    public class Solution
    {
        public int CountBattleships(char[,] board)
        {
            int ships = 0;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (char.ToLower(board[i, j]) == 'x')
                    {
                        if (checkNeighbour(board, i, j))
                        {
                            ships++;
                        }
                    }
                }
            }
            return ships;
        }

        private bool checkNeighbour(char[,] board, int i, int j)
        {
            return ((i == 0 || board[i - 1, j] == '.') &&
                (j == 0 || board[i, j - 1] == '.'));
        }
    }
}
