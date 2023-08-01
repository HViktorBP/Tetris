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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tetris));
            Menu = new MenuStrip();
            gameSettings = new ToolStripMenuItem();
            newGame = new ToolStripMenuItem();
            saveGame = new ToolStripMenuItem();
            loadGame = new ToolStripMenuItem();
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
            tetrisLabel = new Label();
            Menu.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.Items.AddRange(new ToolStripItem[] { gameSettings, gameControls, pauseButton });
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(484, 24);
            Menu.TabIndex = 0;
            Menu.Text = "File";
            // 
            // gameSettings
            // 
            gameSettings.DropDownItems.AddRange(new ToolStripItem[] { newGame, saveGame, loadGame });
            gameSettings.Name = "gameSettings";
            gameSettings.Size = new Size(61, 20);
            gameSettings.Text = "Settings";
            // 
            // newGame
            // 
            newGame.Name = "newGame";
            newGame.Size = new Size(142, 22);
            newGame.Text = "New game";
            newGame.Click += newGame_Click;
            newGame.Paint += newGame_Paint;
            // 
            // saveGame
            // 
            saveGame.Name = "saveGame";
            saveGame.Size = new Size(142, 22);
            saveGame.Text = "Save game...";
            saveGame.Click += saveGame_Click;
            // 
            // loadGame
            // 
            loadGame.Name = "loadGame";
            loadGame.Size = new Size(142, 22);
            loadGame.Text = "Load game...";
            loadGame.Click += loadGame_Click;
            loadGame.Paint += loadGame_Paint;
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
            easyDiff.Size = new Size(110, 22);
            easyDiff.Text = "4 x 16";
            easyDiff.Click += easyDiff_Click;
            // 
            // mediumDiff
            // 
            mediumDiff.Name = "mediumDiff";
            mediumDiff.Size = new Size(110, 22);
            mediumDiff.Text = "8 x 16";
            mediumDiff.Click += mediumDiff_Click;
            // 
            // hardDiff
            // 
            hardDiff.Name = "hardDiff";
            hardDiff.Size = new Size(110, 22);
            hardDiff.Text = "12 x 16";
            hardDiff.Click += hardDiff_Click;
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
            statusStrip.Location = new Point(0, 839);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(484, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip";
            // 
            // TimerTextBox
            // 
            TimerTextBox.BackColor = SystemColors.Control;
            TimerTextBox.Name = "TimerTextBox";
            TimerTextBox.Size = new Size(36, 17);
            TimerTextBox.Text = "Time:";
            // 
            // Timer
            // 
            Timer.BackColor = SystemColors.Control;
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
            // tetrisLabel
            // 
            tetrisLabel.AutoSize = true;
            tetrisLabel.BackColor = Color.Transparent;
            tetrisLabel.FlatStyle = FlatStyle.Flat;
            tetrisLabel.Font = new Font("Stencil", 48F, FontStyle.Bold, GraphicsUnit.Point);
            tetrisLabel.ForeColor = Color.GhostWhite;
            tetrisLabel.Location = new Point(110, 43);
            tetrisLabel.Name = "tetrisLabel";
            tetrisLabel.Size = new Size(258, 76);
            tetrisLabel.TabIndex = 2;
            tetrisLabel.Text = "Tetris";
            tetrisLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Tetris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.MediumPurple;
            ClientSize = new Size(484, 861);
            Controls.Add(tetrisLabel);
            Controls.Add(statusStrip);
            Controls.Add(Menu);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = Menu;
            Name = "Tetris";
            Text = "Tetris";
            FormClosed += Tetris_FormClosed;
            SizeChanged += Tetris_SizeChanged;
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
        private Label tetrisLabel;
    }
}