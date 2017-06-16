using Minesweeper.Classes;

namespace Minesweeper.Interfaces
{
    public interface ITile
    {
        int Row { get; }
        int Column { get; }
        bool HadMine { get; }
        TileStatus Status { get; }
        void SetStatus(TileStatus tileStatus, int warning = 0);
    }
}
