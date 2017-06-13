using System.Windows.Forms;
using Minesweeper.Classes;

namespace Minesweeper.Forms
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();

            StartGame(GameEngine.DifficultyLevel.Begginer);
        }

        private void StartGame(GameEngine.DifficultyLevel level)
        {
            var engine = new GameEngine(level, this);
            engine.Initialize();
        }
    }
}
