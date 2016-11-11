
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsInABoard
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

            string[] BS = ["X..X".ToCharArray(), "...X".ToCharArray(), "...X".ToCharArray()];
            char[,] bs = BS.ToArray();
            Solution solution = new Solution();
            int count = solution.CountBattleships(bs);
            Console.WriteLine(count);
            Console.ReadLine();
        }
  
    }

    public class Solution
    {
        public int CountBattleships(char[,] board)
        {
            BattleBoard battleShip = new BattleBoard(board);
            int i = 0;                                              //- Runner horizontally
            int j = 0;                                              //-Runner vertitally
            int maxI = board.GetLength(0);                          //width
            int maxJ = board.GetLength(1);                          //height
            while (j < maxJ)
            {
                while (i < maxI)
                {
                    if (char.ToLower(battleShip.Board[i, j]) == 'x')
                    {
                        if (battleShip.Ships.Count != 0)             //if it's not empty, check for 
                        {
                            Ship ship = CheckNeighbour(battleShip, i, j);
                            Point point = new Point(i, j);
                            if (ship == null)
                            {

                                ship = new Ship(point);
                                battleShip.Ships.Add(ship);
                            }
                            else
                            {
                                ship.positions.Add(point);
                            }
                        }
                        else

                        {                                               //it is empty, so here's the first ship
                            Point point = new Point(i, j);
                            Ship ship = new Ship(point);
                            battleShip.Ships.Add(ship);
                        }
                    }
                    i++;

                }
                i = 0;
                j++;
            }
            return battleShip.Ships.Count();
        }
        private Ship CheckNeighbour(BattleBoard board, int i, int j)
        {
            if (i != 0)    //make sure you don't go out of bounds
            {
                if (board.Board[i - 1, j] == 'x')
                {
                    Ship ship = board.Ships.Single(x => x.positions.Where(y => y.i == i - 1 && y.j == j).Any());

                    return ship;
                }
            }
            if (j != 0)
            {
                if (board.Board[i, j - 1] == 'x')
                {
                    Ship ship = board.Ships.Single(x => x.positions.Where(y => y.i == i && y.j == j - 1).Any());

                    return ship;
                }
            }


            return null;
        }
    }
    public class BattleBoard
    {
        public char[,] Board;
        public List<Ship> Ships;

        public BattleBoard() { }
        public BattleBoard(char[,] board)
        {
            Board = board;
            Ships = new List<Ship>();
        }

    }
    public class Ship
    {
        public List<Point> positions;
        public Ship() { positions = new List<Point>(); }
        public Ship(Point startPosition)
        {
            positions = new List<Point>();
            positions.Add(startPosition);
        }

    }

    public class Point
    {
        public int i;
        public int j;

        public Point() { }
        public Point(int x, int y)
        {
            i = x;
            j = y;
        }
    }
}
