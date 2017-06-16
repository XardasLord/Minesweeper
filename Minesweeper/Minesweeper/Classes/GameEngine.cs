using System;
using Minesweeper.Forms;
using Minesweeper.Interfaces;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Classes
{
    public class GameEngine
    {
        private bool _gameStarted;
        private bool _gameEnd;
        private int _totalTilesToUnflip;
        private int _unflippedTiles;

        public int Rows { get; }
        public int Columns { get; }
        public int NumberOfMines { get; }
        public DifficultyLevel Level { get; }

        private ITile[,] _tiles;
        private Game _gameBoard;

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
            
            _totalTilesToUnflip = Rows * Columns - NumberOfMines;
        }

        public GameEngine(int rows, int columns, int numbersOfMines, Game gameBoard)
        {
            Rows = rows;
            Columns = columns;
            NumberOfMines = numbersOfMines;
            _gameBoard = gameBoard;

            _totalTilesToUnflip = Rows * Columns - NumberOfMines;
        }

        public void Initialize()
        {
            _tiles = new Tile[Rows, Columns];
            _gameEnd = false;
            _gameStarted = false;

            ClearGameBoard();
            ResizeGameBoard();
            GenerateTiles();
            GenerateMines();
        }
        
        private void ClearGameBoard()
        {
            List<Tile> tiles = _gameBoard.Controls.OfType<Tile>().ToList();

            foreach (var tile in tiles)
            {
                _gameBoard.Controls.Remove(tile);
            }
        }

        private void ResizeGameBoard()
        {
            _gameBoard.Size = new System.Drawing.Size(23 * Columns + 45, 23 * Rows + 80);
        }

        private void GenerateTiles()
        {
            for(var i = 0; i < Rows; i++)
            {
                for(var j = 0; j < Columns; j++)
                {
                    var tile = new Tile(i, j, this);
                    AddTile(tile);

                    _gameBoard.Controls.Add(tile);
                }
            }
        }

        private void GenerateMines()
        {
            var random = new Random();
            var planted = false;

            for(var i = 0; i < NumberOfMines; i++)
            {
                planted = false;

                while (!planted)
                {
                    var row = random.Next(0, Rows - 1);
                    var colmn = random.Next(0, Columns - 1);

                    if (_tiles[row, colmn].Status == TileStatus.Mine)
                        continue;

                    _tiles[row, colmn].SetStatus(TileStatus.Mine);
                    planted = true;
                }
            }
        }

        public void AddTile(ITile tile)
        {
            _tiles[tile.Row, tile.Column] = tile;
        }

        public void CheckTile(object sender, MouseEventArgs e)
        {
            if (_gameEnd)
                return;

            if (_gameStarted == false)
                _gameStarted = true;

            ITile tile = (ITile)sender;

            if (e.Button == MouseButtons.Right)
            {
                if (tile.Status == TileStatus.Unflipped || tile.Status == TileStatus.Mine)
                {
                    tile.SetStatus(TileStatus.Flag);
                    return;
                }
                
                if (tile.Status == TileStatus.Flag)
                {
                    if (tile.HadMine)
                        tile.SetStatus(TileStatus.Mine);
                    else
                        tile.SetStatus(TileStatus.Unflipped);
                }
            }
            else
            {
                if (tile.Status == TileStatus.Mine)
                {
                    tile.SetStatus(TileStatus.ClickedMine);
                    GameOver();

                    return;
                }

                if (tile.Status != TileStatus.Unflipped)
                    return;
                
                var mines = CountMinesOnNeighbourTiles(tile);

                if (mines == 0)
                {
                    UnflipNeighbourTiles(tile);
                }
                else
                {
                    tile.SetStatus(TileStatus.Warning, mines);
                    _unflippedTiles++;
                }
            }

            if (CheckWin())
            { 
                Win();
            }
        }

        private void UnflipNeighbourTiles(ITile tile)
        {
            // Unflip all tiles which have 0 mines on neighbour tiles.
            if (tile == null)
                return;

            if (tile.Status != TileStatus.Unflipped)
                return;

            var mines = CountMinesOnNeighbourTiles(tile);
            if (mines == 0)
            {
                tile.SetStatus(TileStatus.Clear);
                _unflippedTiles++;

                var nextTile = GetNextTile(tile);
                var prevTile = GetPrevTile(tile);
                var upperTile = GetUpperTile(tile);
                var nextUpperTile = GetNextTile(upperTile);
                var prevUpperTile = GetPrevTile(upperTile);
                var lowerTile = GetLowerTile(tile);
                var nextLowerTile = GetNextTile(lowerTile);
                var prevLowerTile = GetPrevTile(lowerTile);

                UnflipNeighbourTiles(nextTile);
                UnflipNeighbourTiles(prevTile);
                UnflipNeighbourTiles(upperTile);
                UnflipNeighbourTiles(nextUpperTile);
                UnflipNeighbourTiles(prevUpperTile);
                UnflipNeighbourTiles(lowerTile);
                UnflipNeighbourTiles(nextLowerTile);
                UnflipNeighbourTiles(prevLowerTile);
            }
            else
            {
                tile.SetStatus(TileStatus.Warning, mines);
                _unflippedTiles++;
            }
        }

        private int CountMinesOnNeighbourTiles(ITile tile)
        {
            var mines = 0;

            var nextTile = GetNextTile(tile);
            if (nextTile != null && nextTile.HadMine)
                mines++;

            var prevTile = GetPrevTile(tile);
            if (prevTile != null && prevTile.HadMine)
                mines++;

            var upperTile = GetUpperTile(tile);
            if (upperTile != null)
            {
                if (upperTile.HadMine)
                    mines++;

                var nextUpperTile = GetNextTile(upperTile);
                if (nextUpperTile != null && nextUpperTile.HadMine)
                    mines++;

                var prevUpperTile = GetPrevTile(upperTile);
                if (prevUpperTile != null && prevUpperTile.HadMine)
                    mines++;
            }

            var lowerTile = GetLowerTile(tile);
            if (lowerTile != null)
            {
                if (lowerTile.HadMine)
                    mines++;

                var nextLowerTile = GetNextTile(lowerTile);
                if (nextLowerTile != null && nextLowerTile.HadMine)
                    mines++;
                var prevLowerTile = GetPrevTile(lowerTile);
                if (prevLowerTile != null && prevLowerTile.HadMine)
                    mines++;
            }

            return mines;
        }

        private ITile GetNextTile(ITile tile)
        {
            ITile nextTile = null;

            if (tile == null)
                return nextTile;

            if (tile.Column < Columns - 1)
            {
                nextTile = _tiles[tile.Row, tile.Column + 1];
            }

            return nextTile;
        }

        private ITile GetPrevTile(ITile tile)
        {
            ITile prevTile = null;

            if (tile == null)
                return prevTile;

            if (tile.Column > 0)
            {
                prevTile = _tiles[tile.Row, tile.Column - 1];
            }

            return prevTile;
        }

        private ITile GetUpperTile(ITile tile)
        {
            ITile upperTile = null;

            if (tile == null)
                return upperTile;

            if (tile.Row > 0)
            {
                upperTile = _tiles[tile.Row - 1, tile.Column];
            }

            return upperTile;
        }

        private ITile GetLowerTile(ITile tile)
        {
            ITile lowerTile = null;

            if (tile == null)
                return lowerTile;

            if (tile.Row < Rows - 1)
            {
                lowerTile = _tiles[tile.Row + 1, tile.Column];
            }

            return lowerTile;
        }

        private void GameOver()
        {
            ShowAllMines();

            _gameEnd = true;
        }

        private void ShowAllMines()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (_tiles[i, j].Status == TileStatus.Mine)
                        _tiles[i, j].SetStatus(TileStatus.ClickedMine);
                }
            }
        }

        private void ShowAllFlags()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (_tiles[i, j].Status == TileStatus.Mine)
                        _tiles[i, j].SetStatus(TileStatus.Flag);
                }
            }
        }

        private bool CheckWin()
        {
            var win = false;

            if (_totalTilesToUnflip == _unflippedTiles)
                win = true;

            return win;
        }

        private void Win()
        {
            ShowAllFlags();
            _gameEnd = true;

            MessageBox.Show("Congratulations! You've won!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
