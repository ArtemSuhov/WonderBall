using System;
using System.Drawing;
using System.Windows.Forms;

namespace WonderGame
{
    class GameForm : Form
    {
        public const int height = 600;
        public const int width = 600;
        public const int sizeOfBlock = 30;

        public GameForm()
        {
            DoubleBuffered = true;
            Cursor.Hide();
            ClientSize = new Size(height, width);

            var speed = 0.0;
            var indexOfLevel = 0;
                
            var wonderBall = new WonderBall(new Point(200, 200), sizeOfBlock - 10, 0.9);
            wonderBall.Position = this.PointToClient(new Point(Cursor.Position.X, this.PointToScreen(wonderBall.Position).Y));

            var level = Level.GetRandomLevel(width / sizeOfBlock, 0);

            var time = 0;
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender, args) =>
            {
                time++;
                Invalidate();
            };
            timer.Start();
            
            Paint += (sender, args) =>
            {
                var indexOfBlock = 0;
                foreach (var cell in level.FirstFloor)
                {
                    args.Graphics.FillRectangle(cell.Brush, indexOfBlock * sizeOfBlock, height - 60, sizeOfBlock,
                        sizeOfBlock);
                    indexOfBlock++;
                    //args.Graphics.DrawImage(new Bitmap(Minecraft.block, sizeOfBlock, sizeOfBlock),
                    //    indexOfBlock * sizeOfBlock, height - 60);
                }

                indexOfBlock = 0;
                foreach (var cell in level.SecondFloor)
                {
                    args.Graphics.FillRectangle(cell.Brush, indexOfBlock * sizeOfBlock, height - 310, sizeOfBlock,
                        sizeOfBlock);
                    indexOfBlock++;
                }

                args.Graphics.FillEllipse(Brushes.Yellow,
                    this.PointToClient(Cursor.Position).X - wonderBall.Size / 2,
                    wonderBall.Y,
                    wonderBall.Size + 5,
                    wonderBall.Size + 5);

                args.Graphics.DrawImage(new Bitmap(Minecraft.ball, wonderBall.Size + 5, wonderBall.Size + 5),
                    wonderBall.X - wonderBall.Size / 2,
                    wonderBall.Y);

                args.Graphics.DrawString("Scores: " + ((double)(1 + indexOfLevel) / 2 * indexOfLevel).ToString(), new Font("Arial", 20), Brushes.Black, 0, 0);

                var game = Game.GetNextStep(wonderBall, level, speed, indexOfLevel, sizeOfBlock, this);

                wonderBall = game.Item1;
                level = game.Item2;
                speed = game.Item3;
                indexOfLevel = game.Item4;

                if (wonderBall.X == int.MaxValue)
                { 
                    timer.Stop();
                    args.Graphics.DrawString("GAME OVER", new Font("Calibri", 52), Brushes.Red, width / 3, height / 2); 
                }
            };
        }

        public static void DrawLevel(Level level, Graphics graphics)
        {
            var indexOfBlock = 0;
            foreach (var cell in level.FirstFloor)
            {
                graphics.DrawImage(new Bitmap(Minecraft.block, sizeOfBlock, sizeOfBlock),
                    indexOfBlock * sizeOfBlock, height - 60);
                indexOfBlock++;
            }
        }
    }
}
