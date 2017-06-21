namespace Minesweeper.Forms
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.mspMenu = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBegginer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIntermediate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExpert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mspMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMenu
            // 
            this.mspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.mspMenu.Location = new System.Drawing.Point(0, 0);
            this.mspMenu.Name = "mspMenu";
            this.mspMenu.Size = new System.Drawing.Size(284, 24);
            this.mspMenu.TabIndex = 0;
            this.mspMenu.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBegginer,
            this.btnIntermediate,
            this.btnExpert,
            this.btnCustom,
            this.toolStripSeparator1,
            this.btnExit});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // btnBegginer
            // 
            this.btnBegginer.Name = "btnBegginer";
            this.btnBegginer.Size = new System.Drawing.Size(141, 22);
            this.btnBegginer.Text = "Begginer";
            this.btnBegginer.Click += new System.EventHandler(this.btnBegginer_Click);
            // 
            // btnIntermediate
            // 
            this.btnIntermediate.Name = "btnIntermediate";
            this.btnIntermediate.Size = new System.Drawing.Size(141, 22);
            this.btnIntermediate.Text = "Intermediate";
            this.btnIntermediate.Click += new System.EventHandler(this.btnIntermediate_Click);
            // 
            // btnExpert
            // 
            this.btnExpert.Name = "btnExpert";
            this.btnExpert.Size = new System.Drawing.Size(141, 22);
            this.btnExpert.Text = "Expert";
            this.btnExpert.Click += new System.EventHandler(this.btnExpert_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(141, 22);
            this.btnCustom.Text = "Custom";
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(141, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.mspMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mspMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.mspMenu.ResumeLayout(false);
            this.mspMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMenu;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnBegginer;
        private System.Windows.Forms.ToolStripMenuItem btnIntermediate;
        private System.Windows.Forms.ToolStripMenuItem btnExpert;
        private System.Windows.Forms.ToolStripMenuItem btnCustom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}

