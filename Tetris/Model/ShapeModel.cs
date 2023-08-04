using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class ShapeModel
    {
        #region Variables
        private int _shapeSize;

        private int[,] _currentRotation = null!;

        private int[,] _defaultRotation = null!;

        private int[,] _rotation90Degree = null!;

        private int[,] _rotation180Degree = null!;

        private int[,] _rotation270Degree = null!;
        #endregion

        #region Properties
        public int ShapeSize { get { return _shapeSize; } }
        #endregion

        #region Constructor
        public ShapeModel() {
            GenerateShape();
        }
        #endregion

        #region Private methods
        private void GenerateShape()
        {
            Random temp = new Random();
            switch (temp.Next(1, 6))
            {
                case 1:
                    _shapeSize = 4;
                    _currentRotation = _defaultRotation = new int[4, 4]
                    {
                        {0, 0, 0, 0 },
                        {1, 1, 1, 1 },
                        {0, 0, 0, 0 },
                        {0, 0, 0, 0 },
                    };
                    _rotation90Degree = new int[4, 4]
                    {
                        {0, 0, 1, 0 },
                        {0, 0, 1, 0 },
                        {0, 0, 1, 0 },
                        {0, 0, 1, 0 },
                    };
                    _rotation180Degree = new int[4, 4]
                    {
                        {0, 0, 0, 0 },
                        {0, 0, 0, 0 },
                        {1, 1, 1, 1 },
                        {0, 0, 0, 0 },
                    };
                    _rotation270Degree = new int[4, 4]
                    {
                        {0, 1, 0, 0 },
                        {0, 1, 0, 0 },
                        {0, 1, 0, 0 },
                        {0, 1, 0, 0 },
                    };
                    break;
                case 2:
                    _shapeSize = 2;
                    _currentRotation = _defaultRotation = _rotation90Degree = _rotation180Degree = _rotation270Degree = new int[2, 2]
                    {
                        {2, 2},
                        {2, 2},
                    };
                    break;
                case 3:
                    _shapeSize = 3;
                    _currentRotation = _defaultRotation = new int[3, 3]
                    {
                        {3, 0, 0},
                        {3, 3, 3},
                        {0, 0, 0},
                    };
                    _rotation90Degree = new int[3, 3]
                    {
                        {0, 3, 3},
                        {0, 3, 0},
                        {0, 3, 0},
                    };
                    _rotation180Degree = new int[3, 3]
                    {
                        {0, 0, 0},
                        {3, 3, 3},
                        {0, 0, 3},
                    };
                    _rotation270Degree = new int[3, 3]
                    {
                        {0, 3, 0},
                        {0, 3, 0},
                        {3, 3, 0},
                    };
                    break;
                case 4:
                    _shapeSize = 3;
                    _currentRotation = _defaultRotation = new int[3, 3]
                    {
                        {0, 4, 0},
                        {4, 4, 4},
                        {0, 0, 0},
                    };
                    _rotation90Degree = new int[3, 3]
                    {
                        {0, 4, 0},
                        {0, 4, 4},
                        {0, 4, 0},
                    };
                    _rotation180Degree = new int[3, 3]
                    {
                        {0, 0, 0},
                        {4, 4, 4},
                        {0, 4, 0},
                    };
                    _rotation270Degree = new int[3, 3]
                    {
                        {0, 4, 0},
                        {4, 4, 0},
                        {0, 4, 0},
                    };
                    break;
                case 5:
                    _shapeSize = 3;
                    _currentRotation = _defaultRotation = new int[3, 3]
                    {
                        {0, 5, 5},
                        {5, 5, 0},
                        {0, 0, 0},
                    };
                    _rotation90Degree = new int[3, 3]
                    {
                        {0, 5, 0},
                        {0, 5, 5},
                        {0, 0, 5},
                    };
                    _rotation180Degree = new int[3, 3]
                    {
                        {0, 0, 0},
                        {0, 5, 5},
                        {5, 5, 0},
                    };
                    _rotation270Degree = new int[3, 3]
                    {
                        {5, 0, 0},
                        {5, 5, 0},
                        {0, 5, 0},
                    };
                    break;
            }
        }
        #endregion

        #region Public methods
        public void ChangeRotation()
        {
            switch (ShapeGameModel.RotationCount)
            {
                case 1:
                    _currentRotation = _defaultRotation;
                    break;
                case 2:
                    _currentRotation = _rotation90Degree;
                    break;
                case 3:
                    _currentRotation = _rotation180Degree;
                    break;
                case 4:
                    _currentRotation = _rotation270Degree;
                    break;
            }
        }

        public int GetValue(int i, int j)
        {
            return _currentRotation[i, j];
        }
        #endregion
    }
}
