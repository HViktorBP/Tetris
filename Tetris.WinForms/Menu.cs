using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Model;
using Tetris.Presistence;

namespace Tetris.WinForms
{
    public partial class Menu : Form
    {
        private Tetris _tetris = null!;

        private ITetrisDataAccess _dataAccess = null!;

        public Menu()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (RadioButtonEasyDiff.Checked)
            {
                _tetris = new Tetris(GameDifficulty.Easy, _dataAccess);
            }
            else if (RadioButtonMediumDiff.Checked)
            {
                _tetris = new Tetris(GameDifficulty.Medium, _dataAccess);
            }
            else
            {
                _tetris = new Tetris(GameDifficulty.Hard, _dataAccess);
            }

            SettingUpTetrisWindow(_tetris.TetrisGame.Difficulty);
            _tetris.ShowDialog();
        }

        private void SettingUpTetrisWindow(GameDifficulty difficulty)
        {
            if (difficulty == GameDifficulty.Easy)
            {
                _tetris.Width = 280;
                _tetris.Height = 800;
            }
            else if (difficulty == GameDifficulty.Medium)
            {
                _tetris.Width = 400;
                _tetris.Height = 700;
            }
            else
            {
                _tetris.Width = 475;
                _tetris.Height = 624;
            }
        }

        private async void ButtonGameLoad_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _tetris = new Tetris();
                    await _tetris.TetrisGame.LoadGameAsync(openFile.FileName);
                    _tetris.LoadGame();
                    SettingUpTetrisWindow(_tetris.TetrisGame.Difficulty);
                    _tetris.ShowDialog();
                }
                catch (TetrisDataEcxeption)
                {
                    MessageBox.Show("Can not download the game!" + Environment.NewLine + "The file path is uncorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _tetris.GameTimer.Stop();
                }
            }
        }
    }
}
