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
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Stencil", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.ForeColor = SystemColors.HotTrack;
            startButton.Location = new Point(89, 381);
            startButton.Name = "startButton";
            startButton.Size = new Size(153, 52);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // GameLabel
            // 
            GameLabel.AutoSize = true;
            GameLabel.Font = new Font("Stencil", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            GameLabel.ForeColor = SystemColors.HotTrack;
            GameLabel.Location = new Point(89, 58);
            GameLabel.Name = "GameLabel";
            GameLabel.Size = new Size(153, 44);
            GameLabel.TabIndex = 1;
            GameLabel.Text = "Tetris";
            // 
            // RadioButtonEasyDiff
            // 
            RadioButtonEasyDiff.AutoSize = true;
            RadioButtonEasyDiff.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RadioButtonEasyDiff.ForeColor = SystemColors.HotTrack;
            RadioButtonEasyDiff.Location = new Point(130, 173);
            RadioButtonEasyDiff.Name = "RadioButtonEasyDiff";
            RadioButtonEasyDiff.Size = new Size(65, 23);
            RadioButtonEasyDiff.TabIndex = 2;
            RadioButtonEasyDiff.Text = "Easy";
            RadioButtonEasyDiff.UseVisualStyleBackColor = true;
            // 
            // RadioButtonMediumDiff
            // 
            RadioButtonMediumDiff.AutoSize = true;
            RadioButtonMediumDiff.Checked = true;
            RadioButtonMediumDiff.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RadioButtonMediumDiff.ForeColor = SystemColors.HotTrack;
            RadioButtonMediumDiff.Location = new Point(130, 202);
            RadioButtonMediumDiff.Name = "RadioButtonMediumDiff";
            RadioButtonMediumDiff.Size = new Size(89, 23);
            RadioButtonMediumDiff.TabIndex = 3;
            RadioButtonMediumDiff.TabStop = true;
            RadioButtonMediumDiff.Text = "Medium";
            RadioButtonMediumDiff.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHardDiff
            // 
            RadioButtonHardDiff.AutoSize = true;
            RadioButtonHardDiff.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RadioButtonHardDiff.ForeColor = SystemColors.HotTrack;
            RadioButtonHardDiff.Location = new Point(130, 231);
            RadioButtonHardDiff.Name = "RadioButtonHardDiff";
            RadioButtonHardDiff.Size = new Size(70, 23);
            RadioButtonHardDiff.TabIndex = 4;
            RadioButtonHardDiff.Text = "Hard";
            RadioButtonHardDiff.UseVisualStyleBackColor = true;
            // 
            // LabelDifficulties
            // 
            LabelDifficulties.AutoSize = true;
            LabelDifficulties.Font = new Font("Stencil", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            LabelDifficulties.ForeColor = SystemColors.HotTrack;
            LabelDifficulties.Location = new Point(37, 122);
            LabelDifficulties.Name = "LabelDifficulties";
            LabelDifficulties.Size = new Size(267, 32);
            LabelDifficulties.TabIndex = 5;
            LabelDifficulties.Text = "Game difficulty:";
            // 
            // ButtonGameLoad
            // 
            ButtonGameLoad.FlatStyle = FlatStyle.Flat;
            ButtonGameLoad.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            ButtonGameLoad.ForeColor = SystemColors.HotTrack;
            ButtonGameLoad.Location = new Point(89, 307);
            ButtonGameLoad.Name = "ButtonGameLoad";
            ButtonGameLoad.Size = new Size(153, 48);
            ButtonGameLoad.TabIndex = 6;
            ButtonGameLoad.Text = "Load game";
            ButtonGameLoad.UseVisualStyleBackColor = true;
            ButtonGameLoad.Click += ButtonGameLoad_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 445);
            Controls.Add(ButtonGameLoad);
            Controls.Add(LabelDifficulties);
            Controls.Add(RadioButtonHardDiff);
            Controls.Add(RadioButtonMediumDiff);
            Controls.Add(RadioButtonEasyDiff);
            Controls.Add(GameLabel);
            Controls.Add(startButton);
            Name = "Menu";
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