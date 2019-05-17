using System.Drawing;

namespace WonderGame
{
    public class WonderBall
    {
        private Point position;
        private int size;
        private double jumpForce;

        public WonderBall(Point position, int size, double jumpForce)
        {
            this.position = position;
            this.size = size;
            this.jumpForce = jumpForce;
        }

        public int Size => size;
        public double JumpForce => jumpForce;

        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public int Y
        {
            get
            {
                return position.Y;
            }

            set
            {
                position.Y = value;
            }
        }

        public int X
        {
            get
            {
                return position.X;
            }

            set
            {
                position.X = value;
            }
        }

    }

}
