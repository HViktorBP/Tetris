namespace Tetris.WinForms
{
    partial class Tetris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Menu = new MenuStrip();
            gameSettings = new ToolStripMenuItem();
            newGame = new ToolStripMenuItem();
            saveGame = new ToolStripMenuItem();
            loadGame = new ToolStripMenuItem();
            gameExit = new ToolStripMenuItem();
            gameControls = new ToolStripMenuItem();
            fourXsixteen = new ToolStripMenuItem();
            eightXsixteen = new ToolStripMenuItem();
            twelveXsixteen = new ToolStripMenuItem();
            pauseButton = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            stripStatusLabel1 = new ToolStripStatusLabel();
            stripStatusLabel = new ToolStripStatusLabel();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            Menu.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.Items.AddRange(new ToolStripItem[] { gameSettings, gameControls, pauseButton });
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(482, 24);
            Menu.TabIndex = 0;
            Menu.Text = "File";
            // 
            // gameSettings
            // 
            gameSettings.DropDownItems.AddRange(new ToolStripItem[] { newGame, saveGame, loadGame, gameExit });
            gameSettings.Name = "gameSettings";
            gameSettings.Size = new Size(61, 20);
            gameSettings.Text = "Settings";
            // 
            // newGame
            // 
            newGame.Name = "newGame";
            newGame.Size = new Size(139, 22);
            newGame.Text = "New game";
            newGame.Click += newGame_Click;
            newGame.Paint += newGame_Paint;
            // 
            // saveGame
            // 
            saveGame.Name = "saveGame";
            saveGame.Size = new Size(139, 22);
            saveGame.Text = "Save game..";
            saveGame.Click += saveGame_Click;
            // 
            // loadGame
            // 
            loadGame.Name = "loadGame";
            loadGame.Size = new Size(139, 22);
            loadGame.Text = "Load game..";
            loadGame.Click += loadGame_Click;
            loadGame.Paint += loadGame_Paint;
            // 
            // gameExit
            // 
            gameExit.Name = "gameExit";
            gameExit.Size = new Size(139, 22);
            gameExit.Text = "Exit";
            gameExit.Click += gameExit_Click;
            // 
            // gameControls
            // 
            gameControls.DropDownItems.AddRange(new ToolStripItem[] { fourXsixteen, eightXsixteen, twelveXsixteen });
            gameControls.Name = "gameControls";
            gameControls.Size = new Size(50, 20);
            gameControls.Text = "Game";
            // 
            // fourXsixteen
            // 
            fourXsixteen.Name = "fourXsixteen";
            fourXsixteen.Size = new Size(110, 22);
            fourXsixteen.Text = "4 x 16";
            fourXsixteen.Click += fourXsixteen_Click;
            // 
            // eightXsixteen
            // 
            eightXsixteen.Name = "eightXsixteen";
            eightXsixteen.Size = new Size(110, 22);
            eightXsixteen.Text = "8 x 16";
            eightXsixteen.Click += eightXsixteen_Click;
            // 
            // twelveXsixteen
            // 
            twelveXsixteen.Name = "twelveXsixteen";
            twelveXsixteen.Size = new Size(110, 22);
            twelveXsixteen.Text = "12 x 16";
            twelveXsixteen.Click += twelveXsixteen_Click;
            // 
            // pauseButton
            // 
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(50, 20);
            pauseButton.Text = "Pause";
            pauseButton.Click += pauseButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { stripStatusLabel1, stripStatusLabel });
            statusStrip.Location = new Point(0, 739);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(482, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip";
            // 
            // stripStatusLabel1
            // 
            stripStatusLabel1.Name = "stripStatusLabel1";
            stripStatusLabel1.Size = new Size(36, 17);
            stripStatusLabel1.Text = "Time:";
            // 
            // stripStatusLabel
            // 
            stripStatusLabel.Name = "stripStatusLabel";
            stripStatusLabel.Size = new Size(13, 17);
            stripStatusLabel.Text = "0";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Tetris tábla (*.save)|*.save";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "Tetris tábla (*.save)|*.save";
            // 
            // Tetris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 761);
            Controls.Add(statusStrip);
            Controls.Add(Menu);
            DoubleBuffered = true;
            MainMenuStrip = Menu;
            Name = "Tetris";
            Text = "Tetris";
            Paint += OnPaint;
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip Menu;
        private ToolStripMenuItem gameSettings;
        private ToolStripMenuItem newGame;
        private ToolStripMenuItem saveGame;
        private ToolStripMenuItem loadGame;
        private ToolStripMenuItem gameExit;
        private ToolStripMenuItem gameControls;
        private ToolStripMenuItem fourXsixteen;
        private ToolStripMenuItem eightXsixteen;
        private ToolStripMenuItem twelveXsixteen;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel stripStatusLabel1;
        private ToolStripMenuItem pauseButton;
        private ToolStripStatusLabel stripStatusLabel;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}