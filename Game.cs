using System;
using System.Drawing;
using System.Windows.Forms;

namespace WonderGame
{
    class Game
    {
        static void Main(string[] args)
        {
            Application.Run(new MenuForm());
        }

        public const double gravity = 9.8;

        public static Tuple<WonderBall, Level, double, int> GetNextStep(
            WonderBall wonderBall, 
            Level level, 
            double speed, 
            int indexOfLevel, 
            int sizeOfBlock,
            GameForm form)
        {
            speed = speed + (gravity - 0.01 * speed) * 0.1;
            wonderBall.Y = wonderBall.Y + (int)(speed * 0.1 + gravity * 0.01);
            wonderBall.X -= Math.Sign(wonderBall.X - form.PointToClient(Cursor.Position).X) * 2;

            if (wonderBall.Y > 600)
            {
                wonderBall.Y = 0;
                indexOfLevel++;
                level = Level.GetRandomLevel(form.Width / sizeOfBlock, indexOfLevel / 5);
            }
            else if (wonderBall.Y <= 0 && speed < 0)
            {
                speed = -speed * wonderBall.JumpForce;
            }

            if (wonderBall.X >= form.Width)
            {
                wonderBall.X = 1;
            }
            else if (wonderBall.X <= 0)
            {
                wonderBall.X = form.Width - 1;
            }


            if (level.CheckUnderTheBall(wonderBall, sizeOfBlock, form.Height) || level.CheckUpperTheBall(wonderBall, sizeOfBlock, form.Height))
            {
                if (level.FirstFloor[wonderBall.X / sizeOfBlock].IsDeath  || level.SecondFloor[wonderBall.X / sizeOfBlock].IsDeath)
                {
                    wonderBall.X = int.MaxValue;
                }
                else if (level.CheckUnderTheBall(wonderBall, sizeOfBlock, form.Height) && speed > 0)
                {
                    speed = -speed * wonderBall.JumpForce;
                }
                else if (level.CheckUpperTheBall(wonderBall, sizeOfBlock, form.Height) && speed < 0)
                {
                    speed = -speed * wonderBall.JumpForce;
                }
            }

            return new Tuple<WonderBall, Level, double, int>(wonderBall, level, speed, indexOfLevel);
        }
    }
}
