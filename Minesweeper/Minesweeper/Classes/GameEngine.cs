using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Forms;
using Minesweeper.Interfaces;
using System.Windows.Forms;

namespace Minesweeper.Classes
{
    public class GameEngine
    {
        private bool _gameStarted; 

        public int Rows { get; }
        public int Columns { get; }
        public int NumberOfMines { get; }
        public DifficultyLevel Level { get; }

        private ITile[,] _tiles;
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
                    Rows = 16;
                    Columns = 30;
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

            ClearGameBoard();
            ResizeGameBoard();
            GenerateTiles();
            GenerateMines();
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

        private void GenerateMines()
        {
            var random = new Random();
            for(var i = 0; i < NumberOfMines; i++)
            {
                _tiles[random.Next(0, Rows - 1), random.Next(0, Columns - 1)].SetStatus(TileStatus.Mine);
            }
        }

        private void ClearGameBoard()
        {
            _gameBoard.Controls.Clear();
        }

        private void ResizeGameBoard()
        {
            _gameBoard.Size = new System.Drawing.Size(23 * Columns + 45, 23 * Rows + 80);
        }

        public void CheckTile(object sender, MouseEventArgs e)
        {
            if (_gameStarted == false)
                _gameStarted = true;

            ITile tile = (ITile)sender;

            if (tile.Status == TileStatus.Mine)
            {
                tile.SetStatus(TileStatus.ClickedMine);
                GameOver();
            }

            if (tile.Status != TileStatus.Unflipped)
                return;

            //TODO: Check current tile and set specific status.
            var mines = CountMinesOnNeighbourTiles(tile);

            if (mines == 0)
            {
                tile.SetStatus(TileStatus.Clear);
                //TODO: Discover tiles which have 0 mines on neighbour tiles.
            }
            else
            {
                tile.SetStatus(TileStatus.Warning, mines);
            }
        }

        private int CountMinesOnNeighbourTiles(ITile tile)
        {
            var mines = 0;

            var nextTile = GetNextTile(tile);
            if (nextTile != null && nextTile.Status == TileStatus.Mine)
                mines++;

            var prevTile = GetPrevTile(tile);
            if (prevTile != null && prevTile.Status == TileStatus.Mine)
                mines++;

            var upperTile = GetUpperTile(tile);
            if (upperTile != null)
            {
                if (upperTile.Status == TileStatus.Mine)
                    mines++;

                var nextUpperTile = GetNextTile(upperTile);
                if (nextUpperTile != null && nextUpperTile.Status == TileStatus.Mine)
                    mines++;

                var prevUpperTile = GetPrevTile(upperTile);
                if (prevUpperTile != null && prevUpperTile.Status == TileStatus.Mine)
                    mines++;
            }

            var lowerTile = GetLowerTile(tile);
            if (lowerTile != null)
            {
                if (lowerTile.Status == TileStatus.Mine)
                    mines++;

                var nextLowerTile = GetNextTile(lowerTile);
                if (nextLowerTile != null && nextLowerTile.Status == TileStatus.Mine)
                    mines++;
                var prevLowerTile = GetPrevTile(lowerTile);
                if (prevLowerTile != null && prevLowerTile.Status == TileStatus.Mine)
                    mines++;
            }

            return mines;
        }

        private ITile GetNextTile(ITile tile)
        {
            ITile nextTile = null;

            if (tile.Column < Columns - 1)
            {
                nextTile = _tiles[tile.Row, tile.Column + 1];
            }

            return nextTile;
        }

        private ITile GetPrevTile(ITile tile)
        {
            ITile prevTile = null;

            if (tile.Column > 0)
            {
                prevTile = _tiles[tile.Row, tile.Column - 1];
            }

            return prevTile;
        }

        private ITile GetUpperTile(ITile tile)
        {
            ITile upperTile = null;

            if (tile.Row > 0)
            {
                upperTile = _tiles[tile.Row - 1, tile.Column];
            }

            return upperTile;
        }

        private ITile GetLowerTile(ITile tile)
        {
            ITile lowerTile = null;

            if (tile.Row < Rows - 1)
            {
                lowerTile = _tiles[tile.Row + 1, tile.Column];
            }

            return lowerTile;
        }

        private void GameOver()
        {
            _gameStarted = false;
            //TODO: Stop timer etc.
        }
    }
}
