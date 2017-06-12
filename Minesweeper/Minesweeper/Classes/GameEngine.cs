using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Forms;

namespace Minesweeper.Classes
{
    public class GameEngine
    {
        private bool _gameStarted; 

        public int Rows { get; }
        public int Columns { get; }
        public int NumberOfMines { get; }
        public DifficultyLevel Level { get; }

        private Tile[,] _tiles;
        private Game _gameBoard;

        public enum DifficultyLevel
        {
            Begginer = 0,
            Intermediate = 1,
            Expert = 2
        }

        public GameEngine(DifficultyLevel level, Game gameBoard)
        {
            Level = level;
            _gameBoard = gameBoard;

            switch (Level)
            {
                case DifficultyLevel.Begginer:
                    Rows = 8;
                    Columns = 8;
                    NumberOfMines = 10;
                    break;
                case DifficultyLevel.Intermediate:
                    Rows = 16;
                    Columns = 16;
                    NumberOfMines = 40;
                    break;
                case DifficultyLevel.Expert:
                    Rows = 30;
                    Columns = 16;
                    NumberOfMines = 99;
                    break;
                default:
                    Rows = 8;
                    Columns = 8;
                    NumberOfMines = 10;
                    break;
            }
        }

        public GameEngine(int rows, int columns, int numbersOfMines, Game gameBoard)
        {
            Rows = rows;
            Columns = columns;
            NumberOfMines = numbersOfMines;
            _gameBoard = gameBoard;
        }

        public void Initialize()
        {
            _tiles = new Tile[Rows, Columns];
            GenerateTiles();
            ResizeGameBoard();
        }

        public void AddTile(Tile tile)
        {
            _tiles[tile.Row, tile.Column] = tile;
        }

        private void GenerateTiles()
        {
            for(var i = 0; i < Rows; i++)
            {
                for(var j = 0; j < Columns; j++)
                {
                    var tile = new Tile(i, j, this);

                    _gameBoard.Controls.Add(tile);
                }
            }
        }

        private void ResizeGameBoard()
        {
            //TODO: Resize game board
            var lastTile = _tiles[Rows - 1, Columns - 1];
        }
    }
}
