using System;
using System.Windows.Forms;

namespace Minesweeper.Forms
{
    public partial class Custom : Form
    {
        public int Rows { get { return Int32.Parse(txtRows.Text); } }
        public int Columns { get { return Int32.Parse(txtColumns.Text); } }
        public int Mines { get { return Int32.Parse(txtMines.Text); } }

        public Custom()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput(txtRows.Text) && ValidateInput(txtColumns.Text) && ValidateInput(txtMines.Text))
            {
                if (CheckMaxSize() && CheckMaxNumberOfMines())
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private bool ValidateInput(string text)
        {
            bool valid = true;

            int parsedValue;
            if (!int.TryParse(text, out parsedValue))
            {
                MessageBox.Show("You have to type numbers.", "Only numbers allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = false;
            }

            return valid;
        }

        private bool CheckMaxSize()
        {
            bool valid = true;

            if (Rows > 30 || Columns > 30)
            {
                MessageBox.Show("Maximum allowed map size is: 30x30.", "Maximum map size", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = false;
            }

            return valid;
        }

        private bool CheckMaxNumberOfMines()
        {
            bool valid = true;

            int maxNumberOfMines = (Rows - 1) * (Columns - 1);
            if (Mines > maxNumberOfMines)
            {
                MessageBox.Show("Number of mines is invalid. Max numbers on mines can be calculated: (Rows-1)x(Columns-1)",
                    "Number of mines is invalid.", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                valid = false;
            }

            return valid;
        }
    }
}
