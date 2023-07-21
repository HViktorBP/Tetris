using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class ShapeGameModel
    {
        #region Variables
        private GameDifficulty _difficulty;

        private int _positionX;

        private int _positionY;

        private static int _rotationCount;
        
        private ShapeModel _shape = null!;
        #endregion

        #region Properties
        public int PositionX { get { return _positionX; } }
        public int PositionY { get { return _positionY; } }
        public static int RotationCount { get { return _rotationCount; } }
        public ShapeModel Shape { get { return _shape; } }
        #endregion

        #region Constructor
        public ShapeGameModel(int x, int y, GameDifficulty difficulty)
        {
            _positionX = x;
            _positionY = y;
            _difficulty = difficulty;
            _rotationCount = 1;
            _shape = new ShapeModel();
        }
        #endregion

        #region Private methods
        private void MoveUp() { _positionY--; }
        #endregion

        #region Public methods
        public void MoveDown() { _positionY++; }

        public void MoveRight() { _positionX++; }

        public void MoveLeft() { _positionX--; }

        public void RotateShape()
        {
            _rotationCount++;
            if (_rotationCount == 5)
            {
                _rotationCount = 1;
            }

            _shape.ChangeRotation();

            int offset1 = 0;
            int offset2 = 0;
            if (_difficulty == GameDifficulty.Easy)
            {
                offset1 = (4 - (_positionX + _shape.ShapeSize));
                offset2 = (16 - (_positionY + _shape.ShapeSize));
            }

            if (_difficulty == GameDifficulty.Medium)
            {
                offset1 = (8 - (_positionX + _shape.ShapeSize));
                offset2 = (16 - (_positionY + _shape.ShapeSize));
            }

            if (_difficulty == GameDifficulty.Hard)
            {
                offset1 = (12 - (_positionX + _shape.ShapeSize));
                offset2 = (16 - (_positionY + _shape.ShapeSize));
            }

            if (offset1 < 0)
            {
                for (int i = 0; i < Math.Abs(offset1); i++)
                    MoveLeft();
            }

            if (_positionX < 0)
            {
                for (int i = 0; i < Math.Abs(_positionX) + 1; i++)
                    MoveRight();
            }

            if (offset2 < 0)
            {
                for (int i = 0; i < Math.Abs(offset2); i++)
                    MoveUp();
            }

            if (_positionY < 0)
            {
                for (int i = 0; i < Math.Abs(_positionY) + 1; i++)
                    MoveDown();
            }
        }
        #endregion
    }
}
