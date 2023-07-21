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
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.FlatStyle = FlatStyle.Popup;
            startButton.Font = new Font("Stencil", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.ForeColor = SystemColors.HotTrack;
            startButton.Location = new Point(89, 398);
            startButton.Name = "startButton";
            startButton.Size = new Size(153, 52);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
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
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 505);
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
    }
}