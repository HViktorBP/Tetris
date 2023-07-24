namespace Tetris.WinForms
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            startButton = new Button();
            GameLabel = new Label();
            RadioButtonEasyDiff = new RadioButton();
            RadioButtonMediumDiff = new RadioButton();
            RadioButtonHardDiff = new RadioButton();
            LabelDifficulties = new Label();
            ButtonGameLoad = new Button();
            openFile = new OpenFileDialog();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.DarkViolet;
            startButton.Font = new Font("Stencil", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.ForeColor = Color.GhostWhite;
            startButton.Location = new Point(66, 367);
            startButton.Name = "startButton";
            startButton.Size = new Size(153, 52);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // GameLabel
            // 
            GameLabel.AutoSize = true;
            GameLabel.BackColor = Color.Transparent;
            GameLabel.FlatStyle = FlatStyle.Flat;
            GameLabel.Font = new Font("Stencil", 48F, FontStyle.Bold, GraphicsUnit.Point);
            GameLabel.ForeColor = Color.GhostWhite;
            GameLabel.Location = new Point(12, 9);
            GameLabel.Name = "GameLabel";
            GameLabel.Size = new Size(258, 76);
            GameLabel.TabIndex = 1;
            GameLabel.Text = "Tetris";
            GameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RadioButtonEasyDiff
            // 
            RadioButtonEasyDiff.AutoSize = true;
            RadioButtonEasyDiff.BackColor = Color.Transparent;
            RadioButtonEasyDiff.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RadioButtonEasyDiff.ForeColor = Color.GhostWhite;
            RadioButtonEasyDiff.Location = new Point(102, 177);
            RadioButtonEasyDiff.Name = "RadioButtonEasyDiff";
            RadioButtonEasyDiff.Size = new Size(65, 23);
            RadioButtonEasyDiff.TabIndex = 2;
            RadioButtonEasyDiff.Text = "Easy";
            RadioButtonEasyDiff.UseVisualStyleBackColor = false;
            // 
            // RadioButtonMediumDiff
            // 
            RadioButtonMediumDiff.AutoSize = true;
            RadioButtonMediumDiff.BackColor = Color.Transparent;
            RadioButtonMediumDiff.Checked = true;
            RadioButtonMediumDiff.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RadioButtonMediumDiff.ForeColor = Color.GhostWhite;
            RadioButtonMediumDiff.Location = new Point(102, 206);
            RadioButtonMediumDiff.Name = "RadioButtonMediumDiff";
            RadioButtonMediumDiff.Size = new Size(88, 25);
            RadioButtonMediumDiff.TabIndex = 3;
            RadioButtonMediumDiff.TabStop = true;
            RadioButtonMediumDiff.Text = "Medium";
            RadioButtonMediumDiff.UseCompatibleTextRendering = true;
            RadioButtonMediumDiff.UseVisualStyleBackColor = false;
            // 
            // RadioButtonHardDiff
            // 
            RadioButtonHardDiff.AutoSize = true;
            RadioButtonHardDiff.BackColor = Color.Transparent;
            RadioButtonHardDiff.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RadioButtonHardDiff.ForeColor = Color.GhostWhite;
            RadioButtonHardDiff.Location = new Point(102, 237);
            RadioButtonHardDiff.Name = "RadioButtonHardDiff";
            RadioButtonHardDiff.Size = new Size(70, 23);
            RadioButtonHardDiff.TabIndex = 4;
            RadioButtonHardDiff.Text = "Hard";
            RadioButtonHardDiff.UseVisualStyleBackColor = false;
            // 
            // LabelDifficulties
            // 
            LabelDifficulties.AutoSize = true;
            LabelDifficulties.BackColor = Color.Transparent;
            LabelDifficulties.Font = new Font("Stencil", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            LabelDifficulties.ForeColor = Color.GhostWhite;
            LabelDifficulties.Location = new Point(51, 142);
            LabelDifficulties.Name = "LabelDifficulties";
            LabelDifficulties.Size = new Size(184, 32);
            LabelDifficulties.TabIndex = 5;
            LabelDifficulties.Text = "Difficulty:";
            LabelDifficulties.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonGameLoad
            // 
            ButtonGameLoad.BackColor = Color.DarkViolet;
            ButtonGameLoad.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            ButtonGameLoad.ForeColor = Color.GhostWhite;
            ButtonGameLoad.Location = new Point(66, 295);
            ButtonGameLoad.Name = "ButtonGameLoad";
            ButtonGameLoad.Size = new Size(153, 48);
            ButtonGameLoad.TabIndex = 6;
            ButtonGameLoad.Text = "Load game";
            ButtonGameLoad.UseVisualStyleBackColor = false;
            ButtonGameLoad.Click += ButtonGameLoad_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(284, 461);
            Controls.Add(ButtonGameLoad);
            Controls.Add(LabelDifficulties);
            Controls.Add(RadioButtonHardDiff);
            Controls.Add(RadioButtonMediumDiff);
            Controls.Add(RadioButtonEasyDiff);
            Controls.Add(GameLabel);
            Controls.Add(startButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Menu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Label GameLabel;
        private RadioButton RadioButtonEasyDiff;
        private RadioButton RadioButtonMediumDiff;
        private RadioButton RadioButtonHardDiff;
        private Label LabelDifficulties;
        private Button ButtonGameLoad;
        private OpenFileDialog openFile;
    }
}