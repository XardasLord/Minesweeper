using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper.Classes
{
    public class Tile : Button
    {
        private static readonly Size _size = new Size(23, 23);
        public static readonly Point _startPos = new Point(13, 24);

        public int Row { get; }
        public int Column { get; }
        public GameEngine Engine { get; }

        public Tile(int row, int column, GameEngine engine)
        {
            Row = row;
            Column = column;
            Engine = engine;
            
            Size = _size;
            Location = new Point(_startPos.X + _size.Width * Column, _startPos.Y + _size.Height * Row);

            Engine.AddTile(this);
        }
    }
}
