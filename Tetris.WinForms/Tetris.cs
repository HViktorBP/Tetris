using Microsoft.VisualBasic;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Tetris.Model;
using Tetris.Presistence;
using Timer = System.Windows.Forms.Timer;


namespace Tetris.WinForms
{
    public partial class Tetris : Form
    {
        #region Variables
        private ITetrisDataAccess _dataAccess = null!;

        private TetrisGameModel _tetris = null!;
        
        private Timer _timerForStatusBar = null!;
        
        private Timer _gameTimer = null!;
        
        private int _gameTime;
        #endregion

        #region Constructor
        public Tetris()
        {
            InitializeComponent();
            KeyUp += new KeyEventHandler(Keyboard);
            _dataAccess = new TetrisDataAccess();
            _tetris = new TetrisGameModel(GameDifficulty.Medium, _dataAccess);
            SetupMenus();

            _timerForStatusBar = new Timer();
            _timerForStatusBar.Interval = 1000;
            _timerForStatusBar.Tick += new EventHandler(UpdateStatusBar);

            _gameTimer = new Timer();
            _gameTimer.Interval = 500;
            _gameTimer.Tick += new EventHandler(UpdateMap);

            _gameTime = 0;
            _gameTimer.Start();
            _timerForStatusBar.Start();

            Refresh();
        }
        #endregion

        #region Private methods
        private void Keyboard(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (!_tetris.IsIntersects())
                    {
                        _tetris.ResetArea();
                        _tetris.ShapeGameModel.RotateShape();
                        _tetris.Merge();
                        Refresh();
                    }
                    break;
                case Keys.Right:
                    if (!_tetris.CollideHorizontally("right")) // jobb
                    {
                        _tetris.ResetArea(); // видалаємо все
                        _tetris.ShapeGameModel.MoveRight(); // рухаємо
                        _tetris.Merge();
                        Refresh();
                    }
                    break;
                case Keys.Left:
                    if (!_tetris.CollideHorizontally("left")) // bal
                    {
                        _tetris.ResetArea();
                        _tetris.ShapeGameModel.MoveLeft();
                        _tetris.Merge();
                        Refresh();
                    }
                    break;
            }
        }

        private void UpdateMap(object? sender, EventArgs e)
        {
            _tetris.ResetArea();
            if (!_tetris.Collide())
            {
                _tetris.ShapeGameModel.MoveDown();
            }
            else
            {
                _tetris.Merge();
                _tetris.SliceMap();

                if (_tetris.Difficulty == GameDifficulty.Easy)
                    _tetris.ShapeGameModel = new ShapeGameModel(0, 0, GameDifficulty.Easy);

                if (_tetris.Difficulty == GameDifficulty.Medium)
                    _tetris.ShapeGameModel = new ShapeGameModel(3, 0, GameDifficulty.Medium);

                if (_tetris.Difficulty == GameDifficulty.Hard)
                    _tetris.ShapeGameModel = new ShapeGameModel(5, 0, GameDifficulty.Hard);

                if (_tetris.Collide())
                {
                    _gameTimer.Stop();
                    _timerForStatusBar.Stop();

                    double time = Convert.ToDouble(stripStatusLabel.Text);
                    int minute = (int)time / 60;
                    int hour = (int)time / 3600;
                    int sec = (int)time % 60;

                    MessageBox.Show("Game over. Time spent on a game: " + hour + " hour " + minute + " minutes and " + sec + " seconds.",
                        "Tetris",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);

                    Close();
                }
            }
            _tetris.Merge();
            Refresh();
        }

        private void DrawMap(Graphics e) // за допомогою цієї фугкції ми зафарбовуємо ці шматки, які мають не 0 значення
        {
            for (int i = 0; i < _tetris.Map.Rows; i++)
            {
                for (int j = 0; j < _tetris.Map.Columns; j++)
                {
                    if (_tetris.Map.GetValue(i, j) == 1)
                    {
                        e.FillRectangle(Brushes.Red, new Rectangle(50 + j * (_tetris.Map.FieldSize) + 1, 50 + i * (_tetris.Map.FieldSize) + 1, _tetris.Map.FieldSize - 1, _tetris.Map.FieldSize - 1));
                    }
                    if (_tetris.Map.GetValue(i, j) == 2)
                    {
                        e.FillRectangle(Brushes.Yellow, new Rectangle(50 + j * (_tetris.Map.FieldSize) + 1, 50 + i * (_tetris.Map.FieldSize) + 1, _tetris.Map.FieldSize - 1, _tetris.Map.FieldSize - 1));
                    }
                    if (_tetris.Map.GetValue(i, j) == 3)
                    {
                        e.FillRectangle(Brushes.Green, new Rectangle(50 + j * (_tetris.Map.FieldSize) + 1, 50 + i * (_tetris.Map.FieldSize) + 1, _tetris.Map.FieldSize - 1, _tetris.Map.FieldSize - 1));
                    }
                    if (_tetris.Map.GetValue(i, j) == 4)
                    {
                        e.FillRectangle(Brushes.Blue, new Rectangle(50 + j * (_tetris.Map.FieldSize) + 1, 50 + i * (_tetris.Map.FieldSize) + 1, _tetris.Map.FieldSize - 1, _tetris.Map.FieldSize - 1));
                    }
                    if (_tetris.Map.GetValue(i, j) == 5)
                    {
                        e.FillRectangle(Brushes.Violet, new Rectangle(50 + j * (_tetris.Map.FieldSize) + 1, 50 + i * (_tetris.Map.FieldSize) + 1, _tetris.Map.FieldSize - 1, _tetris.Map.FieldSize - 1));
                    }
                }
            }
        }

        private void DrawGrid(Graphics g)
        {
            for (int i = 0; i <= _tetris.Map.Rows; i++)
            {
                g.DrawLine(Pens.Black, new Point(50, 50 + i * _tetris.Map.FieldSize), new Point(50 + _tetris.Map.Columns * _tetris.Map.FieldSize, 50 + i * _tetris.Map.FieldSize));
            }

            for (int i = 0; i <= _tetris.Map.Columns; i++)
            {
                g.DrawLine(Pens.Black, new Point(50 + i * _tetris.Map.FieldSize, 50), new Point(50 + i * _tetris.Map.FieldSize, 50 + _tetris.Map.Rows * _tetris.Map.FieldSize));
            }
        }

        private void SetupMenus()
        {
            fourXsixteen.Checked = (_tetris.Difficulty == GameDifficulty.Easy);
            eightXsixteen.Checked = (_tetris.Difficulty == GameDifficulty.Medium);
            twelveXsixteen.Checked = (_tetris.Difficulty == GameDifficulty.Hard);
        }
        private void LoadGame()
        {
            if (_tetris.Map.Columns == 4)
            {
                _tetris.Difficulty = GameDifficulty.Easy;
                _tetris.ShapeGameModel = new ShapeGameModel(0, 0, GameDifficulty.Easy);
                _gameTime = 0;
            }
            else if (_tetris.Map.Columns == 8)
            {
                _tetris.Difficulty = GameDifficulty.Medium;
                _tetris.ShapeGameModel = new ShapeGameModel(3, 0, GameDifficulty.Medium);
                _gameTime = 0;
            }
            else
            {
                _tetris.Difficulty = GameDifficulty.Hard;
                _tetris.ShapeGameModel = new ShapeGameModel(5, 0, GameDifficulty.Hard);
                _gameTime = 0;
            }
        }


        private void UpdateStatusBar(object? sender, EventArgs e)
        {
            stripStatusLabel.Text = (++_gameTime).ToString();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void fourXsixteen_Click(object sender, EventArgs e)
        {
            _tetris.Difficulty = GameDifficulty.Easy;
        }

        private void eightXsixteen_Click(object sender, EventArgs e)
        {
            _tetris.Difficulty = GameDifficulty.Medium;
        }

        private void twelveXsixteen_Click(object sender, EventArgs e)
        {
            _tetris.Difficulty = GameDifficulty.Hard;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            _tetris.NewGame();
            for (int i = 0; i < _tetris.Map.Rows; i++)
            {
                for (int j = 0; j < _tetris.Map.Columns; j++)
                {
                    _tetris.Map.SetValue(i, j, 0);
                }
            }
            _gameTime = 0;

            SetupMenus();
        }

        private async void saveGame_Click(object sender, EventArgs e)
        {
            Boolean restartTimer = _gameTimer.Enabled;
            _gameTimer.Stop();
            _timerForStatusBar.Stop();
            _tetris.ResetArea();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // játé mentése
                    await _tetris.SaveGameAsync(saveFileDialog1.FileName);
                }
                catch (TetrisDataEcxeption)
                {
                    MessageBox.Show("Can not download the game!" + Environment.NewLine + "The file path is uncorrect or the library can't be written.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (restartTimer)
            {
                _gameTimer.Start();
                _timerForStatusBar.Start();
            }
        }

        private async void loadGame_Click(object sender, EventArgs e)
        {
            Boolean restartTimer = _gameTimer.Enabled;
            _gameTimer.Stop();
            _timerForStatusBar.Stop();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _tetris.LoadGameAsync(openFileDialog1.FileName);
                    saveGame.Enabled = true;
                    LoadGame();
                }
                catch (TetrisDataEcxeption)
                {
                    MessageBox.Show("Can not download the game!" + Environment.NewLine + "The file path is uncorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _tetris.NewGame();
                    saveGame.Enabled = true;
                }

            }

            if (restartTimer)
            {
                _gameTimer.Start();
                _timerForStatusBar.Start();
            }
        }

        private void gameExit_Click(object sender, EventArgs e)
        {
            Boolean restartTimer = _gameTimer.Enabled;
            _gameTimer.Stop();

            if (MessageBox.Show("Tou sure you want to leave the game?", "Tetris", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                if (restartTimer)
                {
                    _gameTimer.Start();
                }
            }
        }

        private void newGame_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_gameTimer.Enabled)
            {
                pauseButton.Text = "Resume";
                _gameTimer.Stop();
                _timerForStatusBar.Stop();
            }
            else
            {
                pauseButton.Text = "Stop";
                _gameTimer.Start();
                _timerForStatusBar.Start();
            }
        }

        private void loadGame_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }
        #endregion
    }
}