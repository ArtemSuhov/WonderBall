using System.Drawing;

namespace WonderGame
{
    public class Cell
    {
        private bool isBlock;
        private bool isDeath;
        private Brush brush;

        public bool IsBlock => isBlock;
        public bool IsDeath => isDeath;
        public Brush Brush => brush;

        public Cell(bool isBlock, bool isDeath, Brush brush)
        {
            this.isBlock = isBlock;
            this.isDeath = isDeath;
            this.brush = brush;
        }
    }
}
