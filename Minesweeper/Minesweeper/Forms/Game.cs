using System.Windows.Forms;
using Minesweeper.Classes;

namespace Minesweeper.Forms
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();

            StartGame(DifficultyLevel.Begginer);
        }

        private void btnBegginer_Click(object sender, System.EventArgs e)
        {
            StartGame(DifficultyLevel.Begginer);
        }

        private void btnIntermediate_Click(object sender, System.EventArgs e)
        {
            StartGame(DifficultyLevel.Intermediate);
        }

        private void btnExpert_Click(object sender, System.EventArgs e)
        {
            StartGame(DifficultyLevel.Expert);
        }

        private void btnCustom_Click(object sender, System.EventArgs e)
        {
            var custom = new Custom();
            custom.ShowDialog();

            if (custom.DialogResult == DialogResult.OK)
            {
                var engine = new GameEngine(custom.Rows, custom.Columns, custom.Mines, this);
                engine.Initialize();
            }
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void StartGame(DifficultyLevel level)
        {
            var engine = new GameEngine(level, this);
            engine.Initialize();
        }

        private void StartGame(int rows, int columns, int mines)
        {
            var engine = new GameEngine(rows, columns, mines, this);
            engine.Initialize();
        }
    }
}
