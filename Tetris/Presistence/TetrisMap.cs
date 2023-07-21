using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.Presistence
{
    public class TetrisMap
    {
        #region Variables
        private int[,] _map = null!;

        private int _columns;
        
        private int _rows;
        
        private int _fieldSize;
        #endregion

        #region Properties
        public int Columns { get { return _columns; } }
        public int Rows { get { return _rows; } }
        public int FieldSize { get { return _fieldSize; } }
        #endregion

        #region Constructor
        public TetrisMap(GameDifficulty difficulty)
        {
            if (difficulty == GameDifficulty.Easy)
            {
                _map = new int[16, 4];
                _fieldSize = 40;
            }

            if (difficulty == GameDifficulty.Medium)
            {
                _map = new int[16, 8];
                _fieldSize = 35;
            }

            if (difficulty == GameDifficulty.Hard)
            {
                _map = new int[16, 12];
                _fieldSize = 30;
            }

            _columns = _map.GetLength(1);
            _rows = _map.GetLength(0);
        }
        #endregion

        #region Public methods
        public void SetValue(int i, int j, int k)
        {
            _map[i, j] = k;
        }

        public int GetValue(int i, int j)
        {
            return _map[i, j];
        }
        #endregion
    }
}
