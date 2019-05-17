using System.Drawing;
using System.Collections.Generic;
using System;

namespace WonderGame
{
    public class Level
    {
        private List<Cell> firstFloor;
        private List<Cell> secondFloor;
        public List<Cell> FirstFloor => firstFloor;
        public List<Cell> SecondFloor => secondFloor;

        public Level()
        {
            this.firstFloor = new List<Cell>();
            this.secondFloor = new List<Cell>();
        }

        public Level(List<Cell> firstFloor, List<Cell> secondFloor)
        {
            this.firstFloor = firstFloor;
            this.secondFloor = secondFloor;
        }

        public static Level GetRandomLevel(int size, double complexity)
        {
            var level = new Level();
            var rnd = new Random();
            var firstFreeCell = rnd.Next(size);
            var secondFreeCell = rnd.Next(size);

            for (var i = 0; i < size; i++)
            {
                if (i == firstFreeCell)
                {
                    level.FirstFloor.Add(new Cell(false, false, Brushes.Gray));
                }
                else if (rnd.NextDouble() * complexity > 0.9)
                {
                    level.FirstFloor.Add(new Cell(true, true, Brushes.Red));
                }
                else
                {
                    level.FirstFloor.Add(new Cell(true, false, Brushes.Brown));
                }

                if (i == secondFreeCell || rnd.NextDouble() < 0.2)
                {
                    level.SecondFloor.Add(new Cell(false, false, Brushes.Gray));
                }
                else if (rnd.NextDouble() * complexity > 0.9)
                {
                    level.SecondFloor.Add(new Cell(true, true, Brushes.Red));
                }
                else
                {
                    level.SecondFloor.Add(new Cell(true, false, Brushes.Brown));
                }
            }

            return level;
        }

        public bool CheckUnderTheBall(WonderBall wonderBall, int sizeOfBlock, int height)
        {
            return Math.Abs(height - 100 - wonderBall.Y - sizeOfBlock / 2) < 10
                   && this.FirstFloor[wonderBall.X / sizeOfBlock].IsBlock
                   || Math.Abs(height - 350 - wonderBall.Y - sizeOfBlock / 2) < 10
                   && this.SecondFloor[wonderBall.X / sizeOfBlock].IsBlock;
        }

        public bool CheckUpperTheBall(WonderBall wonderBall, int sizeOfBlock, int height)
        {
            return Math.Abs(height - 320 - wonderBall.Y - sizeOfBlock / 2) < 10
                   && this.SecondFloor[wonderBall.X / sizeOfBlock].IsBlock;
        }

    }
}
