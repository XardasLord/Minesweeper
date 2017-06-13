using Minesweeper.Interfaces;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Minesweeper.Classes
{
    public class Tile : Button, ITile
    {
        private static readonly Size _size = new Size(23, 23);
        public static readonly Point _startPos = new Point(13, 24);

        public int Row { get; }
        public int Column { get; }
        public GameEngine Engine { get; }
        public TileStatus Status { get; set; }

        public Tile(int row, int column, GameEngine engine)
        {
            Row = row;
            Column = column;
            Engine = engine;
            Status = TileStatus.Unflipped;

            MouseClick += Engine.Tile_MouseClick;
            
            Size = _size;
            Location = new Point(_startPos.X + _size.Width * Column, _startPos.Y + _size.Height * Row);

            Engine.AddTile(this);
        }

        public void SetStatus(TileStatus tileStatus, int warning = 0)
        {
            switch(tileStatus)
            {
                case TileStatus.Unflipped:
                    Text = String.Empty;
                    Status = TileStatus.Unflipped;
                    break;
                case TileStatus.Clear:
                    Text = String.Empty;
                    BackColor = Color.LightGray;
                    Status = TileStatus.Clear;
                    break;
                case TileStatus.Flag:
                    Text = "F";
                    Status = TileStatus.Flag;
                    break;
                case TileStatus.QuestionFlag:
                    Text = "?";
                    Status = TileStatus.QuestionFlag;
                    break;
                case TileStatus.Warning:
                    Text = warning.ToString();
                    Status = TileStatus.Warning;
                    break;
                case TileStatus.Mine:
                    Text = "*";
                    Status = TileStatus.Mine;
                    break;
                case TileStatus.ClickedMine:
                    Text = "X";
                    BackColor = Color.Red;
                    Status = TileStatus.ClickedMine;
                    break;
            }
        }
    }
}
