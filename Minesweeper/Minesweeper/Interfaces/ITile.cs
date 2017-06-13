using Minesweeper.Classes;

namespace Minesweeper.Interfaces
{
    public interface ITile
    {
        TileStatus Status { get; set; }
        void SetStatus(TileStatus tileStatus, int warning = 0);
    }
}
