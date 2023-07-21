using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Presistence;

namespace Tetris.Model
{
    public class TetrisGameModel
    {
        #region Variables
        private ITetrisDataAccess _dataAccess;

        private ShapeGameModel _shapeGameModel = null!;
        
        private TetrisMap _map = null!;
        
        private GameDifficulty _difficulty;
        #endregion

        #region Properties
        public ShapeGameModel ShapeGameModel { get { return _shapeGameModel; } set { _shapeGameModel = value; } }
        public TetrisMap Map { get { return _map; } set { _map = value; } }
        public GameDifficulty Difficulty { get { return _difficulty; } set { _difficulty = value; } }
        #endregion

        #region Constructor
        public TetrisGameModel(GameDifficulty difficulty, ITetrisDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            if (difficulty == GameDifficulty.Easy)
            {
                _map = new TetrisMap(difficulty);
                _shapeGameModel = new ShapeGameModel(0, 0, difficulty);
            }

            if (difficulty == GameDifficulty.Medium)
            {
                _map = new TetrisMap(difficulty);
                _shapeGameModel = new ShapeGameModel(3, 0, difficulty);
            }

            if (difficulty == GameDifficulty.Hard)
            {
                _map = new TetrisMap(difficulty);
                _shapeGameModel = new ShapeGameModel(5, 0, difficulty);
            }

            _difficulty = difficulty;
        }
        #endregion

        #region Public methods
        public void Merge()
        {
            for (int i = _shapeGameModel.PositionY; i < _shapeGameModel.PositionY + _shapeGameModel.Shape.ShapeSize; i++)
            {
                for (int j = _shapeGameModel.PositionX; j < _shapeGameModel.PositionX + _shapeGameModel.Shape.ShapeSize; j++)
                {
                    if (_shapeGameModel.Shape.GetValue(i - _shapeGameModel.PositionY, j - _shapeGameModel.PositionX) != 0) // ноликом позначаються ті міста де пусто тому ми дивомося чи 0 там чи ні і якщо там не не ноль то длдаємо до нашоі карти частину фігури
                        _map.SetValue(i, j, _shapeGameModel.Shape.GetValue(i - _shapeGameModel.PositionY, j - _shapeGameModel.PositionX));
                }
            }
        }

        public void ResetArea() // якщо  там є якесь ще значення крім нуля, то ми його стираємо адже карта змінюється
        {
            for (int i = _shapeGameModel.PositionY; i < _shapeGameModel.PositionY + _shapeGameModel.Shape.ShapeSize; i++)
            {
                for (int j = _shapeGameModel.PositionX; j < _shapeGameModel.PositionX + _shapeGameModel.Shape.ShapeSize; j++)
                {
                    if (_shapeGameModel.Shape.GetValue(i - _shapeGameModel.PositionY, j - _shapeGameModel.PositionX) != 0)
                        _map.SetValue(i, j, 0);
                }
            }
        }

        public bool Collide() // дивимося чи знизу є фігура або чи ми досягнули кінця 
        {
            for (int i = _shapeGameModel.PositionY; i < _shapeGameModel.PositionY + _shapeGameModel.Shape.ShapeSize; i++)
            {
                for (int j = _shapeGameModel.PositionX; j < _shapeGameModel.PositionX + _shapeGameModel.Shape.ShapeSize; j++)
                {
                    if (_shapeGameModel.Shape.GetValue(i - _shapeGameModel.PositionY, j - _shapeGameModel.PositionX) != 0)
                    {
                        if (i + 1 == _map.Rows)
                            return true;
                        
                        if (_map.GetValue(i + 1, j) != 0)
                            return true;
                    }
                }
            }
            return false;
        }

        public bool CollideHorizontally(string direction)
        {
            int directionToCheck = direction == "right" ? 1 : -1;

            for (int i = _shapeGameModel.PositionY; i < _shapeGameModel.PositionY + _shapeGameModel.Shape.ShapeSize; i++)
            {
                for (int j = _shapeGameModel.PositionX; j < _shapeGameModel.PositionX + _shapeGameModel.Shape.ShapeSize; j++)
                {
                    if (_shapeGameModel.Shape.GetValue(i - _shapeGameModel.PositionY, j - _shapeGameModel.PositionX) != 0)
                    {
                        if (j + 1 * directionToCheck > _map.Columns-1 || j + 1 * directionToCheck < 0)
                        {
                            return true;
                        }

                        if (_map.GetValue(i, j + 1 * directionToCheck) != 0)
                        {

                            if (j - _shapeGameModel.PositionX + 1 * directionToCheck >= _shapeGameModel.Shape.ShapeSize || j - _shapeGameModel.PositionX + 1 * directionToCheck < 0)
                            {
                                return true;
                            }

                            if (_shapeGameModel.Shape.GetValue(i - _shapeGameModel.PositionY, j - _shapeGameModel.PositionX + 1 * directionToCheck) == 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool IsIntersects()
        {
            for (int i = _shapeGameModel.PositionY; i < _shapeGameModel.PositionY + _shapeGameModel.Shape.ShapeSize; i++)
            {
                for (int j = _shapeGameModel.PositionX; j < _shapeGameModel.PositionX + _shapeGameModel.Shape.ShapeSize; j++)
                {
                    if (j >= 0 && j <= _map.Columns - 1 && i >= 0 && i <= _map.Rows - 1)
                    {
                        if (_map.GetValue(i, j) != 0 && _shapeGameModel.Shape.GetValue(i - _shapeGameModel.PositionY, j - _shapeGameModel.PositionX) == 0)
                            return true;
                    }
                }
            }
            return false;
        }

        public void SliceMap()
        {
            int fields = 0;
            int curRemovedLines = 0;

            for (int i = 0; i < _map.Rows; i++)
            {
                fields = 0;
                for (int j = 0; j < _map.Columns; j++)
                {
                    if (_map.GetValue(i, j) != 0)
                        fields++;
                }

                if (fields == _map.Columns)
                {
                    curRemovedLines++;

                    for (int k = i; k >= 1; k--)
                    {
                        for (int o = 0; o < _map.Columns; o++)
                        {
                            _map.SetValue(k, o, _map.GetValue(k - 1, o));
                        }
                    }
                }
            }
        }

        public void NewGame()
        {
            switch (_difficulty)
            {
                case GameDifficulty.Easy:
                    _map = new TetrisMap(_difficulty);
                    _shapeGameModel = new ShapeGameModel(0, 0, _difficulty);
                    break;
                case GameDifficulty.Medium:
                    _map = new TetrisMap(_difficulty);
                    _shapeGameModel = new ShapeGameModel(3, 0, _difficulty);
                    break;
                case GameDifficulty.Hard:
                    _map = new TetrisMap(_difficulty);
                    _shapeGameModel = new ShapeGameModel(5, 0, _difficulty);
                    break;
            }
        }
        public async Task LoadGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            _map = await _dataAccess.LoadAsync(path);
        }
        public async Task SaveGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _map);
        }
        #endregion
    }
}
