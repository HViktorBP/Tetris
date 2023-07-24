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

            _tetris.ShowDialog();
        }

        private async void ButtonGameLoad_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _tetris.TetrisGame.LoadGameAsync(openFile.FileName);
                    _tetris.LoadGame();
                }
                catch (TetrisDataEcxeption)
                {
                    MessageBox.Show("Can not download the game!" + Environment.NewLine + "The file path is uncorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
