using System.Drawing;

namespace DomainModel
{
    public class StoneTile : ITile
    {
        public static int ObjectCounter = 0;

        private readonly Brush _paintBrush;        

        //public int X { get; set; }
        //public int Y { get; set; }
        //public int Width { get; set; }
        //public int Height { get; set; }

        public StoneTile()
        {
            _paintBrush = Brushes.Blue;

            //X = x;
            //Y = y;
            //Width = width;
            //Height = height;

            ++ObjectCounter;
        }

        public void Draw(Graphics g, int x, int y, int width, int height)
        {
            g.FillRectangle(_paintBrush, x, y, width, height);
        }
    }
}
