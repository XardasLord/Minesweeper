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
        public static readonly int _margin = 2;
        private static readonly Color _default = Color.Gray;

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

            MouseUp += Engine.CheckTile;
            
            Size = _size;
            Location = new Point(_startPos.X + _size.Width * Column, _startPos.Y + _size.Height * Row);
            BackColor = Color.Gray;
            FlatStyle = FlatStyle.Flat;

            Engine.AddTile(this);
        }

        public void SetStatus(TileStatus tileStatus, int warning = 0)
        {
            switch(tileStatus)
            {
                case TileStatus.Unflipped:
                    Text = String.Empty;
                    BackColor = _default;
                    Status = TileStatus.Unflipped;
                    break;
                case TileStatus.Clear:
                    Text = String.Empty;
                    BackColor = Color.White;
                    Status = TileStatus.Clear;
                    break;
                case TileStatus.Flag:
                    Text = "F";
                    BackColor = Color.Green;
                    Status = TileStatus.Flag;
                    break;
                case TileStatus.QuestionFlag:
                    Text = "?";
                    Status = TileStatus.QuestionFlag;
                    break;
                case TileStatus.Warning:
                    Text = warning.ToString();
                    BackColor = Color.White;
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
