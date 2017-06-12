using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper.Classes;

namespace Minesweeper.Forms
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();

            var engine = new GameEngine(GameEngine.DifficultyLevel.Begginer, this);
            engine.Initialize();
        }
    }
}
