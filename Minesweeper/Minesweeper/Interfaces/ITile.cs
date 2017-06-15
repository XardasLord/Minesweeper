using Minesweeper.Classes;

namespace Minesweeper.Interfaces
{
    public interface ITile
    {
        int Row { get; }
        int Column { get; }
        TileStatus Status { get; set; }
        void SetStatus(TileStatus tileStatus, int warning = 0);
    }
}
