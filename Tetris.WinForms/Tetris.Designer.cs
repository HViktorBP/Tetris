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
            easyDiff = new ToolStripMenuItem();
            mediumDiff = new ToolStripMenuItem();
            hardDiff = new ToolStripMenuItem();
            pauseButton = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            TimerTextBox = new ToolStripStatusLabel();
            Timer = new ToolStripStatusLabel();
            openFile = new OpenFileDialog();
            saveFile = new SaveFileDialog();
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
            newGame.Size = new Size(180, 22);
            newGame.Text = "New game";
            newGame.Click += newGame_Click;
            newGame.Paint += newGame_Paint;
            // 
            // saveGame
            // 
            saveGame.Name = "saveGame";
            saveGame.Size = new Size(180, 22);
            saveGame.Text = "Save game..";
            saveGame.Click += saveGame_Click;
            // 
            // loadGame
            // 
            loadGame.Name = "loadGame";
            loadGame.Size = new Size(180, 22);
            loadGame.Text = "Load game..";
            loadGame.Click += loadGame_Click;
            loadGame.Paint += loadGame_Paint;
            // 
            // gameExit
            // 
            gameExit.Name = "gameExit";
            gameExit.Size = new Size(180, 22);
            gameExit.Text = "Exit";
            gameExit.Click += gameExit_Click;
            // 
            // gameControls
            // 
            gameControls.DropDownItems.AddRange(new ToolStripItem[] { easyDiff, mediumDiff, hardDiff });
            gameControls.Name = "gameControls";
            gameControls.Size = new Size(50, 20);
            gameControls.Text = "Game";
            // 
            // easyDiff
            // 
            easyDiff.Name = "easyDiff";
            easyDiff.Size = new Size(180, 22);
            easyDiff.Text = "4 x 16";
            easyDiff.Click += fourXsixteen_Click;
            // 
            // mediumDiff
            // 
            mediumDiff.Name = "mediumDiff";
            mediumDiff.Size = new Size(180, 22);
            mediumDiff.Text = "8 x 16";
            mediumDiff.Click += eightXsixteen_Click;
            // 
            // hardDiff
            // 
            hardDiff.Name = "hardDiff";
            hardDiff.Size = new Size(180, 22);
            hardDiff.Text = "12 x 16";
            hardDiff.Click += twelveXsixteen_Click;
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
            statusStrip.Items.AddRange(new ToolStripItem[] { TimerTextBox, Timer });
            statusStrip.Location = new Point(0, 739);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(482, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip";
            // 
            // TimerTextBox
            // 
            TimerTextBox.Name = "TimerTextBox";
            TimerTextBox.Size = new Size(36, 17);
            TimerTextBox.Text = "Time:";
            // 
            // Timer
            // 
            Timer.Name = "Timer";
            Timer.Size = new Size(49, 17);
            Timer.Text = "00:00:00";
            // 
            // openFile
            // 
            openFile.FileName = "openFileDialog1";
            openFile.Filter = "Tetris tábla (*.save)|*.save";
            // 
            // saveFile
            // 
            saveFile.Filter = "Tetris tábla (*.save)|*.save";
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
        private ToolStripMenuItem easyDiff;
        private ToolStripMenuItem mediumDiff;
        private ToolStripMenuItem hardDiff;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel TimerTextBox;
        private ToolStripMenuItem pauseButton;
        private ToolStripStatusLabel Timer;
        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;
    }
}