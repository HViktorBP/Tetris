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

        private TetrisGameModel _tetrisGame = null!;

        private Timer _timerForStatusBar = null!;

        private Timer _gameTimer = null!;

        private int _gameTime;

        #endregion

        #region Properties
        public TetrisGameModel TetrisGame { get { return _tetrisGame; } }
        public Timer GameTimer { get { return _gameTimer; } }
        #endregion

        #region Constructor
        public Tetris()
        {
            InitializeComponent();
            KeyUp += new KeyEventHandler(Keyboard);
            _dataAccess = new TetrisDataAccess();
            _tetrisGame = new TetrisGameModel(GameDifficulty.Easy, _dataAccess);

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

        public Tetris(GameDifficulty difficulty, ITetrisDataAccess _dataAccess)
        {
            InitializeComponent();
            KeyUp += new KeyEventHandler(Keyboard);
            _dataAccess = new TetrisDataAccess();
            _tetrisGame = new TetrisGameModel(difficulty, _dataAccess);
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
                    if (!_tetrisGame.IsIntersects())
                    {
                        _tetrisGame.ResetArea();
                        _tetrisGame.ShapeGameModel.RotateShape();
                        _tetrisGame.Merge();
                        Refresh();
                    }
                    break;
                case Keys.Right:
                    if (!_tetrisGame.CollideHorizontally("right")) // jobb
                    {
                        _tetrisGame.ResetArea(); // видалаємо все
                        _tetrisGame.ShapeGameModel.MoveRight(); // рухаємо
                        _tetrisGame.Merge();
                        Refresh();
                    }
                    break;
                case Keys.Left:
                    if (!_tetrisGame.CollideHorizontally("left")) // bal
                    {
                        _tetrisGame.ResetArea();
                        _tetrisGame.ShapeGameModel.MoveLeft();
                        _tetrisGame.Merge();
                        Refresh();
                    }
                    break;
            }
        }

        private void UpdateMap(object? sender, EventArgs e)
        {
            _tetrisGame.ResetArea();
            if (!_tetrisGame.Collide())
            {
                _tetrisGame.ShapeGameModel.MoveDown();
                _tetrisGame.Merge();
            }
            else
            {
                _tetrisGame.Merge();
                _tetrisGame.SliceMap();

                if (_tetrisGame.Difficulty == GameDifficulty.Easy)
                    _tetrisGame.ShapeGameModel = new ShapeGameModel(0, 0, GameDifficulty.Easy);

                if (_tetrisGame.Difficulty == GameDifficulty.Medium)
                    _tetrisGame.ShapeGameModel = new ShapeGameModel(3, 0, GameDifficulty.Medium);

                if (_tetrisGame.Difficulty == GameDifficulty.Hard)
                    _tetrisGame.ShapeGameModel = new ShapeGameModel(5, 0, GameDifficulty.Hard);


                if (_tetrisGame.Collide())
                {
                    _gameTimer.Stop();
                    _timerForStatusBar.Stop();

                    MessageBox.Show("Game over. Time spent on a game: " + _gameTime / 60 + " hour " + _gameTime / 3600 + " minutes and " + _gameTime % 60 + " seconds.",
                        "Tetris",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
            Refresh();
        }

        private void DrawMap(Graphics e)
        {
            for (int i = 2; i < _tetrisGame.Map.Rows; i++)
            {
                for (int j = 0; j < _tetrisGame.Map.Columns; j++)
                {
                    if (_tetrisGame.Map.GetValue(i, j) == 1)
                    {
                        e.FillRectangle(Brushes.Red, new Rectangle(50 + j * (_tetrisGame.Map.FieldSize) + 1, 50 + i * (_tetrisGame.Map.FieldSize) + 1, _tetrisGame.Map.FieldSize - 1, _tetrisGame.Map.FieldSize - 1));
                    }
                    if (_tetrisGame.Map.GetValue(i, j) == 2)
                    {
                        e.FillRectangle(Brushes.Yellow, new Rectangle(50 + j * (_tetrisGame.Map.FieldSize) + 1, 50 + i * (_tetrisGame.Map.FieldSize) + 1, _tetrisGame.Map.FieldSize - 1, _tetrisGame.Map.FieldSize - 1));
                    }
                    if (_tetrisGame.Map.GetValue(i, j) == 3)
                    {
                        e.FillRectangle(Brushes.Black, new Rectangle(50 + j * (_tetrisGame.Map.FieldSize) + 1, 50 + i * (_tetrisGame.Map.FieldSize) + 1, _tetrisGame.Map.FieldSize - 1, _tetrisGame.Map.FieldSize - 1));
                    }
                    if (_tetrisGame.Map.GetValue(i, j) == 4)
                    {
                        e.FillRectangle(Brushes.Blue, new Rectangle(50 + j * (_tetrisGame.Map.FieldSize) + 1, 50 + i * (_tetrisGame.Map.FieldSize) + 1, _tetrisGame.Map.FieldSize - 1, _tetrisGame.Map.FieldSize - 1));
                    }
                    if (_tetrisGame.Map.GetValue(i, j) == 5)
                    {
                        e.FillRectangle(Brushes.Orange, new Rectangle(50 + j * (_tetrisGame.Map.FieldSize) + 1, 50 + i * (_tetrisGame.Map.FieldSize) + 1, _tetrisGame.Map.FieldSize - 1, _tetrisGame.Map.FieldSize - 1));
                    }
                }
            }
        }

        private void DrawGrid(Graphics g)
        {
            for (int i = 2; i <= _tetrisGame.Map.Rows; i++)
            {
                g.DrawLine(Pens.White, new Point(50, 50 + i * _tetrisGame.Map.FieldSize), new Point(50 + _tetrisGame.Map.Columns * _tetrisGame.Map.FieldSize, 50 + i * _tetrisGame.Map.FieldSize));
            }

            for (int i = 0; i <= _tetrisGame.Map.Columns; i++)
            {
                if (_tetrisGame.Difficulty == GameDifficulty.Easy)
                {
                    g.DrawLine(Pens.White, new Point(50 + i * _tetrisGame.Map.FieldSize, 130), new Point(50 + i * _tetrisGame.Map.FieldSize, 50 + _tetrisGame.Map.Rows * _tetrisGame.Map.FieldSize));
                }
                else if (_tetrisGame.Difficulty == GameDifficulty.Medium)
                {
                    g.DrawLine(Pens.White, new Point(50 + i * _tetrisGame.Map.FieldSize, 120), new Point(50 + i * _tetrisGame.Map.FieldSize, 50 + _tetrisGame.Map.Rows * _tetrisGame.Map.FieldSize));
                }
                else
                {
                    g.DrawLine(Pens.White, new Point(50 + i * _tetrisGame.Map.FieldSize, 110), new Point(50 + i * _tetrisGame.Map.FieldSize, 50 + _tetrisGame.Map.Rows * _tetrisGame.Map.FieldSize));
                }
            }
        }

        private void SetupMenus()
        {
            easyDiff.Checked = (_tetrisGame.Difficulty == GameDifficulty.Easy);
            mediumDiff.Checked = (_tetrisGame.Difficulty == GameDifficulty.Medium);
            hardDiff.Checked = (_tetrisGame.Difficulty == GameDifficulty.Hard);
        }

        private void UpdateStatusBar(object? sender, EventArgs e)
        {
            ++_gameTime;
            int minute = _gameTime / 60;
            int hour = _gameTime / 3600;
            int sec = _gameTime % 60;
            Timer.Text = (hour < 10 ? "0" + hour : hour) + ":" + (minute < 10 ? "0" + minute : minute) + ":" + (sec < 10 ? "0" + sec : sec);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            _tetrisGame.NewGame();
            for (int i = 0; i < _tetrisGame.Map.Rows; i++)
            {
                for (int j = 0; j < _tetrisGame.Map.Columns; j++)
                {
                    _tetrisGame.Map.SetValue(i, j, 0);
                }
            }
            _gameTime = 0;

            SetupMenus();
            SettingUpTetrisWindow();
        }

        private async void saveGame_Click(object sender, EventArgs e)
        {
            Boolean restartTimer = _gameTimer.Enabled;
            _gameTimer.Stop();
            _timerForStatusBar.Stop();
            _tetrisGame.ResetArea();

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _tetrisGame.SaveGameAsync(saveFile.FileName);
                }
                catch (TetrisDataEcxeption)
                {
                    MessageBox.Show("Can not save the game!" + Environment.NewLine + "The file path is uncorrect or the library can't be written.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _tetrisGame.LoadGameAsync(openFile.FileName);
                    saveGame.Enabled = true;
                    LoadGame();
                    SettingUpTetrisWindow();
                }
                catch (TetrisDataEcxeption)
                {
                    MessageBox.Show("Can not download the game!" + Environment.NewLine + "The file path is uncorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _tetrisGame.NewGame();
                    saveGame.Enabled = true;
                }
            }

            if (restartTimer)
            {
                _gameTimer.Start();
                _timerForStatusBar.Start();
            }
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

        private void Tetris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Boolean restartTimer = _gameTimer.Enabled;
            _gameTimer.Stop();

            if (MessageBox.Show("You sure you want to leave the game?", "Tetris", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void easyDiff_Click(object sender, EventArgs e)
        {
            _tetrisGame.Difficulty = GameDifficulty.Easy;
            FormSettingsForNewGame();
        }

        private void mediumDiff_Click(object sender, EventArgs e)
        {
            _tetrisGame.Difficulty = GameDifficulty.Medium;
            FormSettingsForNewGame();
        }

        private void hardDiff_Click(object sender, EventArgs e)
        {
            _tetrisGame.Difficulty = GameDifficulty.Hard;
            FormSettingsForNewGame();
        }

        private void FormSettingsForNewGame()
        {
            Hide();
            _tetrisGame.NewGame();
            SettingUpTetrisWindow();
            SetupMenus();
            _gameTime = 0;
            Show();
        }

        private void newGame_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void loadGame_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void Tetris_SizeChanged(object sender, EventArgs e)
        {
            if (_tetrisGame.Difficulty == GameDifficulty.Easy)
            {
                tetrisLabel.Location = new Point(5, 40);
            }
            else if (_tetrisGame.Difficulty == GameDifficulty.Medium)
            {
                tetrisLabel.Location = new Point(65, 35);
            }
            else
            {
                tetrisLabel.Location = new Point(106, 30);
            }
        }
        #endregion

        #region Public methods
        public void LoadGame()
        {
            if (_tetrisGame.Map.Columns == 4)
            {
                _tetrisGame.Difficulty = GameDifficulty.Easy;
                _tetrisGame.ShapeGameModel = new ShapeGameModel(0, 0, GameDifficulty.Easy);
                _gameTime = 0;
            }
            else if (_tetrisGame.Map.Columns == 8)
            {
                _tetrisGame.Difficulty = GameDifficulty.Medium;
                _tetrisGame.ShapeGameModel = new ShapeGameModel(3, 0, GameDifficulty.Medium);
                _gameTime = 0;
            }
            else
            {
                _tetrisGame.Difficulty = GameDifficulty.Hard;
                _tetrisGame.ShapeGameModel = new ShapeGameModel(5, 0, GameDifficulty.Hard);
                _gameTime = 0;
            }

            SetupMenus();
        }

        public void SettingUpTetrisWindow()
        {
            if (_tetrisGame.Difficulty == GameDifficulty.Easy)
            {
                Width = 277;
                Height = 875;
            }
            else if (_tetrisGame.Difficulty == GameDifficulty.Medium)
            {
                Width = 400;
                Height = 775;
            }
            else
            {
                Width = 475;
                Height = 700;
            }
        }
        #endregion
    }
}